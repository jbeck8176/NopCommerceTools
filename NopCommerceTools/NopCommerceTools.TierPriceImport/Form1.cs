using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NopCommerceTools.TierPriceImport
{
    public partial class Form1 : Form
    {
        public List<string> fileData = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            ofd.Filter = "CSV Files (.csv)|*.csv";
            ofd.FilterIndex = 1;

            ofd.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileData = System.IO.File.ReadAllLines(ofd.FileName).ToList();
            }

            if (Data.Services.TierPricingImportService.ValidateTierPricingCSV(fileData))
            {
                btnLoadFile.Enabled = false;
                lblFileLoadResult.ForeColor = Color.Green;
                lblFileLoadResult.Text = "Import file loaded successfully.";
                btnRunImport.Enabled = true;
            }
            else
            {
                fileData = new List<string>();
                lblFileLoadResult.ForeColor = Color.Red;
                lblFileLoadResult.Text = "Invalid file loaded, please try again.";
            }
        }

        private async void btnRunImport_Click(object sender, EventArgs e)
        {
            btnRunImport.Enabled = false;
            await DoWorkAsync();
        }

        public async Task DoWorkAsync()
        {
            // Wire up progress reporting.
            // Creating a new instance of Progress
            // will capture the SynchronizationContext
            // any any calls to IProgress.Report
            // will be posted to that context.
            Progress<int> progress = new Progress<int>();

            progress.ProgressChanged += (sender, progressPercentage) =>
            {
                // This callback will run on the thread which
                // created the Progress<int> instance.
                // You can update your UI here.
                this.progressBar1.Value = progressPercentage;
            };

            await Task.Run(() => this.ProcessTierPricingFileData(fileData, progress));
        }

        private void ProcessTierPricingFileData(List<string> data, IProgress<int> progress)
        {
            int doneSoFar = 0;
            int lastReportedProgress = -1;

            var tipSvc = new Data.Services.TierPricingImportService(new Data.Models.NopCommerceDataContext());

            var parsedData = tipSvc.ParseCSVData(data);

            foreach (var itemBatch in parsedData.GroupBy(x=>x.Sku))
            {
                //process the list into objects
                tipSvc.ProcessTierPricingForItem(itemBatch.ToList());

                doneSoFar += itemBatch.Count();

                var progressPercentage = (int)((double)doneSoFar / parsedData.Count * 100);
            }
        }
    }
}

