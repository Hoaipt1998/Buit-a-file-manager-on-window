namespace Demo4
{
    partial class frmSearch
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Folder", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("File", System.Windows.Forms.HorizontalAlignment.Left);
            this.tbOlderThan = new System.Windows.Forms.TextBox();
            this.cbNotOlderThan = new System.Windows.Forms.ComboBox();
            this.tbNotOlderThan = new System.Windows.Forms.TextBox();
            this.chkNotOlderThan = new System.Windows.Forms.CheckBox();
            this.cbFileSize1 = new System.Windows.Forms.ComboBox();
            this.tbFileSize = new System.Windows.Forms.TextBox();
            this.cbFileSize = new System.Windows.Forms.ComboBox();
            this.chkFileSize = new System.Windows.Forms.CheckBox();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.tab1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSearchIn = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearchFor = new System.Windows.Forms.Label();
            this.tbSearchFor = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.chkSub = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbOlderThan = new System.Windows.Forms.ComboBox();
            this.chkOlderThan = new System.Windows.Forms.CheckBox();
            this.chkDateBetween = new System.Windows.Forms.CheckBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtAnd = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnGoToFile = new System.Windows.Forms.Button();
            this.btnNewSearch = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearchResult = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tab1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOlderThan
            // 
            this.tbOlderThan.Location = new System.Drawing.Point(126, 57);
            this.tbOlderThan.Name = "tbOlderThan";
            this.tbOlderThan.Size = new System.Drawing.Size(111, 20);
            this.tbOlderThan.TabIndex = 15;
            // 
            // cbNotOlderThan
            // 
            this.cbNotOlderThan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotOlderThan.FormattingEnabled = true;
            this.cbNotOlderThan.Items.AddRange(new object[] {
            "Minute(s)",
            "hour(s)",
            "day(s)",
            "week(s)",
            "month(s)",
            "year(s)"});
            this.cbNotOlderThan.Location = new System.Drawing.Point(244, 31);
            this.cbNotOlderThan.Name = "cbNotOlderThan";
            this.cbNotOlderThan.Size = new System.Drawing.Size(76, 21);
            this.cbNotOlderThan.TabIndex = 13;
            this.cbNotOlderThan.SelectedIndexChanged += new System.EventHandler(this.cbNotOlderThan_SelectedIndexChanged);
            // 
            // tbNotOlderThan
            // 
            this.tbNotOlderThan.Location = new System.Drawing.Point(126, 31);
            this.tbNotOlderThan.Name = "tbNotOlderThan";
            this.tbNotOlderThan.Size = new System.Drawing.Size(111, 20);
            this.tbNotOlderThan.TabIndex = 12;
            // 
            // chkNotOlderThan
            // 
            this.chkNotOlderThan.AutoSize = true;
            this.chkNotOlderThan.Location = new System.Drawing.Point(12, 32);
            this.chkNotOlderThan.Name = "chkNotOlderThan";
            this.chkNotOlderThan.Size = new System.Drawing.Size(99, 17);
            this.chkNotOlderThan.TabIndex = 11;
            this.chkNotOlderThan.Text = "Not older than: ";
            this.chkNotOlderThan.UseVisualStyleBackColor = true;
            this.chkNotOlderThan.CheckedChanged += new System.EventHandler(this.chkNotOlderThan_CheckedChanged);
            // 
            // cbFileSize1
            // 
            this.cbFileSize1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileSize1.FormattingEnabled = true;
            this.cbFileSize1.Items.AddRange(new object[] {
            "bytes",
            "kbytes",
            "Mbytes",
            "Gbytes"});
            this.cbFileSize1.Location = new System.Drawing.Point(378, 81);
            this.cbFileSize1.Name = "cbFileSize1";
            this.cbFileSize1.Size = new System.Drawing.Size(76, 21);
            this.cbFileSize1.TabIndex = 10;
            // 
            // tbFileSize
            // 
            this.tbFileSize.Location = new System.Drawing.Point(178, 82);
            this.tbFileSize.Name = "tbFileSize";
            this.tbFileSize.Size = new System.Drawing.Size(187, 20);
            this.tbFileSize.TabIndex = 9;
            // 
            // cbFileSize
            // 
            this.cbFileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileSize.FormattingEnabled = true;
            this.cbFileSize.Items.AddRange(new object[] {
            "=",
            ">",
            "<"});
            this.cbFileSize.Location = new System.Drawing.Point(109, 81);
            this.cbFileSize.Name = "cbFileSize";
            this.cbFileSize.Size = new System.Drawing.Size(63, 21);
            this.cbFileSize.TabIndex = 8;
            this.cbFileSize.SelectionChangeCommitted += new System.EventHandler(this.cbFileSize_SelectionChangeCommitted);
            // 
            // chkFileSize
            // 
            this.chkFileSize.AutoSize = true;
            this.chkFileSize.Location = new System.Drawing.Point(12, 83);
            this.chkFileSize.Name = "chkFileSize";
            this.chkFileSize.Size = new System.Drawing.Size(63, 17);
            this.chkFileSize.TabIndex = 7;
            this.chkFileSize.Text = "File size";
            this.chkFileSize.UseVisualStyleBackColor = true;
            this.chkFileSize.CheckedChanged += new System.EventHandler(this.chkFileSize_CheckedChanged);
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(309, 6);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(129, 20);
            this.dateTo.TabIndex = 5;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tabPage1);
            this.tab1.Controls.Add(this.tabPage2);
            this.tab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab1.Location = new System.Drawing.Point(0, 0);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(692, 156);
            this.tab1.TabIndex = 10;
            this.tab1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearch_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSearchIn);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.txtSearchFor);
            this.tabPage1.Controls.Add(this.tbSearchFor);
            this.tabPage1.Controls.Add(this.tbPath);
            this.tabPage1.Controls.Add(this.chkSub);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(684, 130);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSearchIn
            // 
            this.txtSearchIn.AutoSize = true;
            this.txtSearchIn.Location = new System.Drawing.Point(12, 51);
            this.txtSearchIn.Name = "txtSearchIn";
            this.txtSearchIn.Size = new System.Drawing.Size(55, 13);
            this.txtSearchIn.TabIndex = 3;
            this.txtSearchIn.Text = "Search in:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearchFor
            // 
            this.txtSearchFor.AutoSize = true;
            this.txtSearchFor.Location = new System.Drawing.Point(12, 25);
            this.txtSearchFor.Name = "txtSearchFor";
            this.txtSearchFor.Size = new System.Drawing.Size(59, 13);
            this.txtSearchFor.TabIndex = 2;
            this.txtSearchFor.Text = "Search for:";
            // 
            // tbSearchFor
            // 
            this.tbSearchFor.Location = new System.Drawing.Point(97, 22);
            this.tbSearchFor.Name = "tbSearchFor";
            this.tbSearchFor.Size = new System.Drawing.Size(336, 20);
            this.tbSearchFor.TabIndex = 0;
            this.tbSearchFor.Text = "*";
            this.tbSearchFor.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(97, 48);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(300, 20);
            this.tbPath.TabIndex = 1;
            // 
            // chkSub
            // 
            this.chkSub.AutoSize = true;
            this.chkSub.Checked = true;
            this.chkSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSub.Location = new System.Drawing.Point(97, 90);
            this.chkSub.Name = "chkSub";
            this.chkSub.Size = new System.Drawing.Size(77, 17);
            this.chkSub.TabIndex = 9;
            this.chkSub.Text = "Sub Folder";
            this.chkSub.UseVisualStyleBackColor = true;
            this.chkSub.Click += new System.EventHandler(this.chkSub_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbOlderThan);
            this.tabPage2.Controls.Add(this.tbOlderThan);
            this.tabPage2.Controls.Add(this.chkOlderThan);
            this.tabPage2.Controls.Add(this.cbNotOlderThan);
            this.tabPage2.Controls.Add(this.tbNotOlderThan);
            this.tabPage2.Controls.Add(this.chkNotOlderThan);
            this.tabPage2.Controls.Add(this.cbFileSize1);
            this.tabPage2.Controls.Add(this.tbFileSize);
            this.tabPage2.Controls.Add(this.cbFileSize);
            this.tabPage2.Controls.Add(this.chkFileSize);
            this.tabPage2.Controls.Add(this.chkDateBetween);
            this.tabPage2.Controls.Add(this.dateTo);
            this.tabPage2.Controls.Add(this.dateFrom);
            this.tabPage2.Controls.Add(this.txtAnd);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(684, 130);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbOlderThan
            // 
            this.cbOlderThan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOlderThan.FormattingEnabled = true;
            this.cbOlderThan.Items.AddRange(new object[] {
            "Minute(s)",
            "hour(s)",
            "day(s)",
            "week(s)",
            "month(s)",
            "year(s)"});
            this.cbOlderThan.Location = new System.Drawing.Point(244, 56);
            this.cbOlderThan.Name = "cbOlderThan";
            this.cbOlderThan.Size = new System.Drawing.Size(76, 21);
            this.cbOlderThan.TabIndex = 16;
            // 
            // chkOlderThan
            // 
            this.chkOlderThan.AutoSize = true;
            this.chkOlderThan.Location = new System.Drawing.Point(12, 57);
            this.chkOlderThan.Name = "chkOlderThan";
            this.chkOlderThan.Size = new System.Drawing.Size(81, 17);
            this.chkOlderThan.TabIndex = 14;
            this.chkOlderThan.Text = "Older than: ";
            this.chkOlderThan.UseVisualStyleBackColor = true;
            this.chkOlderThan.CheckedChanged += new System.EventHandler(this.chkOlderThan_CheckedChanged);
            // 
            // chkDateBetween
            // 
            this.chkDateBetween.AutoSize = true;
            this.chkDateBetween.Location = new System.Drawing.Point(12, 8);
            this.chkDateBetween.Name = "chkDateBetween";
            this.chkDateBetween.Size = new System.Drawing.Size(96, 17);
            this.chkDateBetween.TabIndex = 6;
            this.chkDateBetween.Text = "Date between:";
            this.chkDateBetween.UseVisualStyleBackColor = true;
            this.chkDateBetween.CheckedChanged += new System.EventHandler(this.chkDateBetween_CheckedChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(137, 6);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(129, 20);
            this.dateFrom.TabIndex = 2;
            // 
            // txtAnd
            // 
            this.txtAnd.AutoSize = true;
            this.txtAnd.Location = new System.Drawing.Point(273, 10);
            this.txtAnd.Name = "txtAnd";
            this.txtAnd.Size = new System.Drawing.Size(25, 13);
            this.txtAnd.TabIndex = 4;
            this.txtAnd.Text = "and";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(15, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Start Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBottom.Controls.Add(this.listView1);
            this.panelBottom.Controls.Add(this.panel4);
            this.panelBottom.Controls.Add(this.panel3);
            this.panelBottom.Controls.Add(this.panel2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 160);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(800, 290);
            this.panelBottom.TabIndex = 11;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup3.Header = "Folder";
            listViewGroup3.Name = "Folder";
            listViewGroup4.Header = "File";
            listViewGroup4.Name = "File";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 16);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(796, 226);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.btnView_Click);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearch_KeyDown);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // clmName
            // 
            this.clmName.Width = 600;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnGoToFile);
            this.panel4.Controls.Add(this.btnNewSearch);
            this.panel4.Controls.Add(this.btnEdit);
            this.panel4.Controls.Add(this.btnView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 242);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(796, 23);
            this.panel4.TabIndex = 12;
            // 
            // btnGoToFile
            // 
            this.btnGoToFile.Location = new System.Drawing.Point(383, 0);
            this.btnGoToFile.Name = "btnGoToFile";
            this.btnGoToFile.Size = new System.Drawing.Size(93, 23);
            this.btnGoToFile.TabIndex = 3;
            this.btnGoToFile.Text = "Go to file";
            this.btnGoToFile.UseVisualStyleBackColor = true;
            this.btnGoToFile.ClientSizeChanged += new System.EventHandler(this.btnGoToFile_Click);
            // 
            // btnNewSearch
            // 
            this.btnNewSearch.Location = new System.Drawing.Point(276, 0);
            this.btnNewSearch.Name = "btnNewSearch";
            this.btnNewSearch.Size = new System.Drawing.Size(93, 23);
            this.btnNewSearch.TabIndex = 2;
            this.btnNewSearch.Text = "New Search";
            this.btnNewSearch.UseVisualStyleBackColor = true;
            this.btnNewSearch.Click += new System.EventHandler(this.btnNewSearch_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(166, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "F4 Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(29, 0);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(93, 23);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "F3 View";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSearchResult);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 16);
            this.panel3.TabIndex = 11;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // txtSearchResult
            // 
            this.txtSearchResult.AutoSize = true;
            this.txtSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchResult.Location = new System.Drawing.Point(0, 0);
            this.txtSearchResult.Name = "txtSearchResult";
            this.txtSearchResult.Size = new System.Drawing.Size(80, 13);
            this.txtSearchResult.TabIndex = 10;
            this.txtSearchResult.Text = " Search Result:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 21);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(692, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(104, 156);
            this.panel5.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.tab1);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.MinimumSize = new System.Drawing.Size(584, 160);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(800, 160);
            this.panel6.TabIndex = 12;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel6);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearch_FormClosing);
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearch_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSearch_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSearch_KeyUp);
            this.tab1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbOlderThan;
        private System.Windows.Forms.ComboBox cbNotOlderThan;
        private System.Windows.Forms.TextBox tbNotOlderThan;
        private System.Windows.Forms.CheckBox chkNotOlderThan;
        private System.Windows.Forms.ComboBox cbFileSize1;
        private System.Windows.Forms.TextBox tbFileSize;
        private System.Windows.Forms.ComboBox cbFileSize;
        private System.Windows.Forms.CheckBox chkFileSize;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.TabControl tab1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label txtSearchIn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtSearchFor;
        private System.Windows.Forms.TextBox tbSearchFor;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.CheckBox chkSub;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbOlderThan;
        private System.Windows.Forms.CheckBox chkOlderThan;
        private System.Windows.Forms.CheckBox chkDateBetween;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label txtAnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnGoToFile;
        private System.Windows.Forms.Button btnNewSearch;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtSearchResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader clmName;
    }
}