namespace D365FOSecurityConverter
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_inputFile = new System.Windows.Forms.TextBox();
            this.btn_inputFileBrowse = new System.Windows.Forms.Button();
            this.tb_outputFolder = new System.Windows.Forms.TextBox();
            this.btn_outputFolderBrowse = new System.Windows.Forms.Button();
            this.btn_process = new System.Windows.Forms.Button();
            this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output Location:";
            // 
            // tb_inputFile
            // 
            this.tb_inputFile.Location = new System.Drawing.Point(106, 13);
            this.tb_inputFile.Name = "tb_inputFile";
            this.tb_inputFile.Size = new System.Drawing.Size(547, 20);
            this.tb_inputFile.TabIndex = 2;
            // 
            // btn_inputFileBrowse
            // 
            this.btn_inputFileBrowse.Location = new System.Drawing.Point(106, 39);
            this.btn_inputFileBrowse.Name = "btn_inputFileBrowse";
            this.btn_inputFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_inputFileBrowse.TabIndex = 3;
            this.btn_inputFileBrowse.Text = "Browse";
            this.btn_inputFileBrowse.UseVisualStyleBackColor = true;
            this.btn_inputFileBrowse.Click += new System.EventHandler(this.btnInputFileBrowse_Click);
            // 
            // tb_outputFolder
            // 
            this.tb_outputFolder.Location = new System.Drawing.Point(106, 66);
            this.tb_outputFolder.Name = "tb_outputFolder";
            this.tb_outputFolder.Size = new System.Drawing.Size(547, 20);
            this.tb_outputFolder.TabIndex = 4;
            // 
            // btn_outputFolderBrowse
            // 
            this.btn_outputFolderBrowse.Location = new System.Drawing.Point(106, 93);
            this.btn_outputFolderBrowse.Name = "btn_outputFolderBrowse";
            this.btn_outputFolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_outputFolderBrowse.TabIndex = 5;
            this.btn_outputFolderBrowse.Text = "Browse";
            this.btn_outputFolderBrowse.UseVisualStyleBackColor = true;
            this.btn_outputFolderBrowse.Click += new System.EventHandler(this.btnOutputFolderBrowse_Click);
            // 
            // btn_process
            // 
            this.btn_process.Location = new System.Drawing.Point(578, 114);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(75, 23);
            this.btn_process.TabIndex = 6;
            this.btn_process.Text = "Process";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // inputFileDialog
            // 
            this.inputFileDialog.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 149);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.btn_outputFolderBrowse);
            this.Controls.Add(this.tb_outputFolder);
            this.Controls.Add(this.btn_inputFileBrowse);
            this.Controls.Add(this.tb_inputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "D365FO Security Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_inputFile;
        private System.Windows.Forms.Button btn_inputFileBrowse;
        private System.Windows.Forms.TextBox tb_outputFolder;
        private System.Windows.Forms.Button btn_outputFolderBrowse;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.OpenFileDialog inputFileDialog;
        private System.Windows.Forms.FolderBrowserDialog outputFolderDialog;
    }
}

