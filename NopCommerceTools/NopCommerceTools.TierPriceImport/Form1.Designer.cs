namespace NopCommerceTools.TierPriceImport
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileLoadResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunImport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(15, 36);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(133, 23);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Step 1: load the CSV file";
            // 
            // lblFileLoadResult
            // 
            this.lblFileLoadResult.AutoSize = true;
            this.lblFileLoadResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileLoadResult.ForeColor = System.Drawing.Color.Lime;
            this.lblFileLoadResult.Location = new System.Drawing.Point(12, 62);
            this.lblFileLoadResult.Name = "lblFileLoadResult";
            this.lblFileLoadResult.Size = new System.Drawing.Size(0, 13);
            this.lblFileLoadResult.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Step 1: load the CSV file";
            // 
            // btnRunImport
            // 
            this.btnRunImport.Enabled = false;
            this.btnRunImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunImport.Location = new System.Drawing.Point(17, 121);
            this.btnRunImport.Name = "btnRunImport";
            this.btnRunImport.Size = new System.Drawing.Size(131, 49);
            this.btnRunImport.TabIndex = 4;
            this.btnRunImport.Text = "Run Import";
            this.btnRunImport.UseVisualStyleBackColor = true;
            this.btnRunImport.Click += new System.EventHandler(this.btnRunImport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 188);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(267, 39);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 440);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRunImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFileLoadResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadFile);
            this.Name = "Form1";
            this.Text = "NopCommerce Tier Pricing Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileLoadResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRunImport;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

