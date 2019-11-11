namespace Demo4
{
    partial class ItemsViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.itemsTree1 = new Demo4.ItemsTree();
            this.itemsList1 = new Demo4.ItemsList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDrive = new System.Windows.Forms.Label();
            this.cbDrive = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFileSelectCount = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.serviceController2 = new System.ServiceProcess.ServiceController();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAddress
            // 
            this.tbAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbAddress.Location = new System.Drawing.Point(0, 0);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(403, 20);
            this.tbAddress.TabIndex = 1;
            this.tbAddress.Visible = false;
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.Location = new System.Drawing.Point(0, 0);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(51, 15);
            this.lbAddress.TabIndex = 0;
            this.lbAddress.Text = "Address";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Controls.Add(this.lbAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 21);
            this.panel1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.itemsTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.itemsList1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(494, 544);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 14;
            // 
            // itemsTree1
            // 
            this.itemsTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTree1.Location = new System.Drawing.Point(0, 0);
            this.itemsTree1.Name = "itemsTree1";
            this.itemsTree1.Size = new System.Drawing.Size(93, 544);
            this.itemsTree1.TabIndex = 0;
            // 
            // itemsList1
            // 
            this.itemsList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsList1.Location = new System.Drawing.Point(0, 44);
            this.itemsList1.Name = "itemsList1";
            this.itemsList1.Size = new System.Drawing.Size(397, 500);
            this.itemsList1.SortIdx1 = 0;
            this.itemsList1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lbDrive);
            this.panel2.Controls.Add(this.cbDrive);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 23);
            this.panel2.TabIndex = 10;
            // 
            // lbDrive
            // 
            this.lbDrive.AutoSize = true;
            this.lbDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDrive.Location = new System.Drawing.Point(115, 0);
            this.lbDrive.Name = "lbDrive";
            this.lbDrive.Size = new System.Drawing.Size(40, 13);
            this.lbDrive.TabIndex = 1;
            this.lbDrive.Text = "lbDrive";
            // 
            // cbDrive
            // 
            this.cbDrive.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrive.FormattingEnabled = true;
            this.cbDrive.Location = new System.Drawing.Point(0, 0);
            this.cbDrive.Name = "cbDrive";
            this.cbDrive.Size = new System.Drawing.Size(115, 21);
            this.cbDrive.TabIndex = 0;
            this.cbDrive.SelectedIndexChanged += new System.EventHandler(this.cbDrive_SelectedIndexChanged_1);
            this.cbDrive.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblFileSelectCount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 544);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 20);
            this.panel3.TabIndex = 15;
            // 
            // lblFileSelectCount
            // 
            this.lblFileSelectCount.AutoSize = true;
            this.lblFileSelectCount.Location = new System.Drawing.Point(15, 3);
            this.lblFileSelectCount.Name = "lblFileSelectCount";
            this.lblFileSelectCount.Size = new System.Drawing.Size(35, 13);
            this.lblFileSelectCount.TabIndex = 2;
            this.lblFileSelectCount.Text = "label1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.NotifyFilter = ((System.IO.NotifyFilters)((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
            | System.IO.NotifyFilters.Size) 
            | System.IO.NotifyFilters.LastWrite)));
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ItemsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Name = "ItemsViewer";
            this.Size = new System.Drawing.Size(494, 564);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbDrive;
        private System.Windows.Forms.ComboBox cbDrive;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblFileSelectCount;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.ServiceProcess.ServiceController serviceController2;
        private ItemsTree itemsTree1;
        private ItemsList itemsList1;
    }
}
