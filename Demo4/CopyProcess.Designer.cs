namespace Demo4
{
    partial class CopyProcess
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
            this.txtFileProgress = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalProcess = new System.Windows.Forms.Label();
            this.txtTotalSize = new System.Windows.Forms.Label();
            this.txtOf = new System.Windows.Forms.Label();
            this.txtTt = new System.Windows.Forms.Label();
            this.txtProgress1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.backgroundProcess = new System.ComponentModel.BackgroundWorker();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTotalSizeFrom = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundRetrieveItem = new System.ComponentModel.BackgroundWorker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtFileProgress
            // 
            this.txtFileProgress.AutoSize = true;
            this.txtFileProgress.BackColor = System.Drawing.Color.Honeydew;
            this.txtFileProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtFileProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFileProgress.Location = new System.Drawing.Point(316, 26);
            this.txtFileProgress.Name = "txtFileProgress";
            this.txtFileProgress.Size = new System.Drawing.Size(21, 13);
            this.txtFileProgress.TabIndex = 25;
            this.txtFileProgress.Text = "0%";
            // 
            // txtFile
            // 
            this.txtFile.AutoSize = true;
            this.txtFile.Location = new System.Drawing.Point(43, 5);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(34, 13);
            this.txtFile.TabIndex = 24;
            this.txtFile.Text = "txtFile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Item:";
            // 
            // txtTotalProcess
            // 
            this.txtTotalProcess.AutoSize = true;
            this.txtTotalProcess.BackColor = System.Drawing.Color.Honeydew;
            this.txtTotalProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTotalProcess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTotalProcess.Location = new System.Drawing.Point(316, 86);
            this.txtTotalProcess.Name = "txtTotalProcess";
            this.txtTotalProcess.Size = new System.Drawing.Size(21, 13);
            this.txtTotalProcess.TabIndex = 22;
            this.txtTotalProcess.Text = "0%";
            // 
            // txtTotalSize
            // 
            this.txtTotalSize.AutoSize = true;
            this.txtTotalSize.Location = new System.Drawing.Point(122, 65);
            this.txtTotalSize.Name = "txtTotalSize";
            this.txtTotalSize.Size = new System.Drawing.Size(29, 13);
            this.txtTotalSize.TabIndex = 21;
            this.txtTotalSize.Text = "0 Kb";
            // 
            // txtOf
            // 
            this.txtOf.AutoSize = true;
            this.txtOf.Location = new System.Drawing.Point(110, 65);
            this.txtOf.Name = "txtOf";
            this.txtOf.Size = new System.Drawing.Size(16, 13);
            this.txtOf.TabIndex = 20;
            this.txtOf.Text = "of";
            // 
            // txtTt
            // 
            this.txtTt.AutoSize = true;
            this.txtTt.Location = new System.Drawing.Point(12, 65);
            this.txtTt.Name = "txtTt";
            this.txtTt.Size = new System.Drawing.Size(34, 13);
            this.txtTt.TabIndex = 19;
            this.txtTt.Text = "Total:";
            // 
            // txtProgress1
            // 
            this.txtProgress1.AutoSize = true;
            this.txtProgress1.Location = new System.Drawing.Point(568, 5);
            this.txtProgress1.Name = "txtProgress1";
            this.txtProgress1.Size = new System.Drawing.Size(64, 13);
            this.txtProgress1.TabIndex = 18;
            this.txtProgress1.Text = "0 kb of 0 kb";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(610, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancle";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundProcess
            // 
            this.backgroundProcess.WorkerReportsProgress = true;
            this.backgroundProcess.WorkerSupportsCancellation = true;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Copy to:";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Source items:";
            this.columnHeader1.Width = 280;
            // 
            // txtTotalSizeFrom
            // 
            this.txtTotalSizeFrom.AutoSize = true;
            this.txtTotalSizeFrom.Location = new System.Drawing.Point(43, 65);
            this.txtTotalSizeFrom.Name = "txtTotalSizeFrom";
            this.txtTotalSizeFrom.Size = new System.Drawing.Size(29, 13);
            this.txtTotalSizeFrom.TabIndex = 15;
            this.txtTotalSizeFrom.Text = "0 Kb";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 81);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(673, 23);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 21);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(673, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.Size,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 226);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 224);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.button1_Click);
            // 
            // CopyProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtFileProgress);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalProcess);
            this.Controls.Add(this.txtTotalSize);
            this.Controls.Add(this.txtOf);
            this.Controls.Add(this.txtTt);
            this.Controls.Add(this.txtProgress1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTotalSizeFrom);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listView1);
            this.Name = "CopyProcess";
            this.Text = "CopyProcess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtFileProgress;
        private System.Windows.Forms.Label txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtTotalProcess;
        private System.Windows.Forms.Label txtTotalSize;
        private System.Windows.Forms.Label txtOf;
        private System.Windows.Forms.Label txtTt;
        private System.Windows.Forms.Label txtProgress1;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundProcess;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label txtTotalSizeFrom;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundRetrieveItem;
        private System.Windows.Forms.ListView listView1;
    }
}