namespace Demo4
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnViewTree = new System.Windows.Forms.ToolStripSplitButton();
            this.showTree1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTree2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFoward = new System.Windows.Forms.ToolStripButton();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRename = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMove1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMask = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectAllWithSameExtension = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.showTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTree1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showTree2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.rereadSoureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEqual = new System.Windows.Forms.ToolStripButton();
            this.btnExchange = new System.Windows.Forms.ToolStripButton();
            this.btnViewDetail = new System.Windows.Forms.ToolStripButton();
            this.btnViewList = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.toolstrip1 = new System.Windows.Forms.ToolStrip();
            this.List1 = new Demo4.ItemsViewer();
            this.List2 = new Demo4.ItemsViewer();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolstrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewTree
            // 
            this.btnViewTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewTree.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTree1ToolStripMenuItem,
            this.showTree2ToolStripMenuItem});
            this.btnViewTree.Image = ((System.Drawing.Image)(resources.GetObject("btnViewTree.Image")));
            this.btnViewTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewTree.Name = "btnViewTree";
            this.btnViewTree.Size = new System.Drawing.Size(32, 22);
            this.btnViewTree.Text = "toolStripButton1";
            this.btnViewTree.ButtonClick += new System.EventHandler(this.btnViewTree_ButtonClick);
            // 
            // showTree1ToolStripMenuItem
            // 
            this.showTree1ToolStripMenuItem.Checked = true;
            this.showTree1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTree1ToolStripMenuItem.Name = "showTree1ToolStripMenuItem";
            this.showTree1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showTree1ToolStripMenuItem.Text = "Show Tree 1";
            this.showTree1ToolStripMenuItem.Click += new System.EventHandler(this.showTree1ToolStripMenuItem_Click);
            // 
            // showTree2ToolStripMenuItem
            // 
            this.showTree2ToolStripMenuItem.Checked = true;
            this.showTree2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTree2ToolStripMenuItem.Name = "showTree2ToolStripMenuItem";
            this.showTree2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showTree2ToolStripMenuItem.Text = "Show Tree 2";
            this.showTree2ToolStripMenuItem.Click += new System.EventHandler(this.showTree2ToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "btnSearch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFoward
            // 
            this.btnFoward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFoward.Image = ((System.Drawing.Image)(resources.GetObject("btnFoward.Image")));
            this.btnFoward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFoward.Name = "btnFoward";
            this.btnFoward.Size = new System.Drawing.Size(23, 22);
            this.btnFoward.Text = "btnFoward";
            this.btnFoward.Click += new System.EventHandler(this.btnFoward_Click);
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.Text = "btnBack";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFiles,
            this.menuMask,
            this.menuLanguage,
            this.menuShow,
            this.menuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1160, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFiles
            // 
            this.menuFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRename,
            this.btnCopy1,
            this.btnMove1,
            this.toolStripSeparator15,
            this.btnQuit});
            this.menuFiles.Name = "menuFiles";
            this.menuFiles.ShortcutKeyDisplayString = "F";
            this.menuFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.menuFiles.Size = new System.Drawing.Size(37, 20);
            this.menuFiles.Text = "File";
            // 
            // btnRename
            // 
            this.btnRename.Image = ((System.Drawing.Image)(resources.GetObject("btnRename.Image")));
            this.btnRename.Name = "btnRename";
            this.btnRename.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.btnRename.Size = new System.Drawing.Size(180, 22);
            this.btnRename.Text = "Rename";
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnCopy1
            // 
            this.btnCopy1.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy1.Image")));
            this.btnCopy1.Name = "btnCopy1";
            this.btnCopy1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopy1.Size = new System.Drawing.Size(180, 22);
            this.btnCopy1.Text = "Copy";
            this.btnCopy1.Click += new System.EventHandler(this.btnCopy1_Click);
            // 
            // btnMove1
            // 
            this.btnMove1.Image = ((System.Drawing.Image)(resources.GetObject("btnMove1.Image")));
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.btnMove1.Size = new System.Drawing.Size(180, 22);
            this.btnMove1.Text = "Move";
            this.btnMove1.Click += new System.EventHandler(this.btnMove1_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(177, 6);
            // 
            // btnQuit
            // 
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(180, 22);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // menuMask
            // 
            this.menuMask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectAll,
            this.btnUnselectAll,
            this.btnInvertSelection,
            this.btnSelectAllWithSameExtension,
            this.toolStripSeparator7});
            this.menuMask.Name = "menuMask";
            this.menuMask.ShortcutKeyDisplayString = "M";
            this.menuMask.Size = new System.Drawing.Size(46, 20);
            this.menuMask.Text = "Mark";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnSelectAll.Size = new System.Drawing.Size(235, 22);
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnselectAll.Image")));
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(235, 22);
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnInvertSelection
            // 
            this.btnInvertSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnInvertSelection.Image")));
            this.btnInvertSelection.Name = "btnInvertSelection";
            this.btnInvertSelection.Size = new System.Drawing.Size(235, 22);
            this.btnInvertSelection.Text = "Invert Selection";
            this.btnInvertSelection.Click += new System.EventHandler(this.btnInvertSelection_Click);
            // 
            // btnSelectAllWithSameExtension
            // 
            this.btnSelectAllWithSameExtension.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAllWithSameExtension.Image")));
            this.btnSelectAllWithSameExtension.Name = "btnSelectAllWithSameExtension";
            this.btnSelectAllWithSameExtension.Size = new System.Drawing.Size(235, 22);
            this.btnSelectAllWithSameExtension.Text = "Select All With Same Extension";
            this.btnSelectAllWithSameExtension.Click += new System.EventHandler(this.btnSelectAllWithSameExtension_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(232, 6);
            // 
            // menuLanguage
            // 
            this.menuLanguage.Name = "menuLanguage";
            this.menuLanguage.ShortcutKeyDisplayString = "L";
            this.menuLanguage.Size = new System.Drawing.Size(76, 20);
            this.menuLanguage.Text = "Languages";
            this.menuLanguage.Click += new System.EventHandler(this.menuLanguage_Click);
            // 
            // menuShow
            // 
            this.menuShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowList,
            this.btnShowDetail,
            this.toolStripSeparator16,
            this.showTreeToolStripMenuItem,
            this.toolStripSeparator10,
            this.rereadSoureToolStripMenuItem});
            this.menuShow.Name = "menuShow";
            this.menuShow.ShortcutKeyDisplayString = "S";
            this.menuShow.Size = new System.Drawing.Size(48, 20);
            this.menuShow.Text = "Show";
            // 
            // btnShowList
            // 
            this.btnShowList.Image = ((System.Drawing.Image)(resources.GetObject("btnShowList.Image")));
            this.btnShowList.Name = "btnShowList";
            this.btnShowList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.btnShowList.Size = new System.Drawing.Size(180, 22);
            this.btnShowList.Text = "List";
            this.btnShowList.Click += new System.EventHandler(this.btnShowList_Click);
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnShowDetail.Image")));
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.btnShowDetail.Size = new System.Drawing.Size(180, 22);
            this.btnShowDetail.Text = "Detail";
            this.btnShowDetail.Click += new System.EventHandler(this.btnShowDetail_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(177, 6);
            // 
            // showTreeToolStripMenuItem
            // 
            this.showTreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTree1ToolStripMenuItem1,
            this.showTree2ToolStripMenuItem1});
            this.showTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showTreeToolStripMenuItem.Image")));
            this.showTreeToolStripMenuItem.Name = "showTreeToolStripMenuItem";
            this.showTreeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showTreeToolStripMenuItem.Text = "Show Tree";
            this.showTreeToolStripMenuItem.Click += new System.EventHandler(this.showTreeToolStripMenuItem_Click);
            // 
            // showTree1ToolStripMenuItem1
            // 
            this.showTree1ToolStripMenuItem1.Checked = true;
            this.showTree1ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTree1ToolStripMenuItem1.Name = "showTree1ToolStripMenuItem1";
            this.showTree1ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.showTree1ToolStripMenuItem1.Text = "Show Tree 1";
            this.showTree1ToolStripMenuItem1.Click += new System.EventHandler(this.showTree1ToolStripMenuItem1_Click);
            // 
            // showTree2ToolStripMenuItem1
            // 
            this.showTree2ToolStripMenuItem1.Checked = true;
            this.showTree2ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTree2ToolStripMenuItem1.Name = "showTree2ToolStripMenuItem1";
            this.showTree2ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.showTree2ToolStripMenuItem1.Text = "Show Tree 2";
            this.showTree2ToolStripMenuItem1.Click += new System.EventHandler(this.showTree2ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(177, 6);
            // 
            // rereadSoureToolStripMenuItem
            // 
            this.rereadSoureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rereadSoureToolStripMenuItem.Image")));
            this.rereadSoureToolStripMenuItem.Name = "rereadSoureToolStripMenuItem";
            this.rereadSoureToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.rereadSoureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rereadSoureToolStripMenuItem.Text = "Reread Soure";
            this.rereadSoureToolStripMenuItem.Click += new System.EventHandler(this.rereadSoureToolStripMenuItem_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(52, 20);
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEqual
            // 
            this.btnEqual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEqual.Image = ((System.Drawing.Image)(resources.GetObject("btnEqual.Image")));
            this.btnEqual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(23, 22);
            this.btnEqual.Text = "toolStripButton2";
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // btnExchange
            // 
            this.btnExchange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExchange.Image = ((System.Drawing.Image)(resources.GetObject("btnExchange.Image")));
            this.btnExchange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExchange.Name = "btnExchange";
            this.btnExchange.Size = new System.Drawing.Size(23, 22);
            this.btnExchange.Text = "toolStripButton1";
            this.btnExchange.Click += new System.EventHandler(this.btnExchange_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnViewDetail.Image")));
            this.btnViewDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(23, 22);
            this.btnViewDetail.Text = "toolStripButton2";
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnViewList
            // 
            this.btnViewList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewList.Image = ((System.Drawing.Image)(resources.GetObject("btnViewList.Image")));
            this.btnViewList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewList.Name = "btnViewList";
            this.btnViewList.Size = new System.Drawing.Size(23, 22);
            this.btnViewList.Text = "toolStripButton1";
            this.btnViewList.Click += new System.EventHandler(this.btnViewList_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.List1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.List2);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 589);
            this.splitContainer1.SplitterDistance = 580;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnNewFolder);
            this.panel1.Controls.Add(this.btnMove);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 638);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 20);
            this.panel1.TabIndex = 7;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // btnExit
            // 
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(905, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(165, 20);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Alt + F4 - Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(753, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 20);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "F8 - Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNewFolder.Location = new System.Drawing.Point(591, 0);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(162, 20);
            this.btnNewFolder.TabIndex = 4;
            this.btnNewFolder.Text = "F7 - New Folder";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // btnMove
            // 
            this.btnMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMove.Location = new System.Drawing.Point(445, 0);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(146, 20);
            this.btnMove.TabIndex = 5;
            this.btnMove.Text = "F6 - Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopy.Location = new System.Drawing.Point(297, 0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(148, 20);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "F5 - Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEdit.Location = new System.Drawing.Point(153, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(144, 20);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "F4 - Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnView
            // 
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(0, 0);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(153, 20);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "F3 - View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // toolstrip1
            // 
            this.toolstrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReload,
            this.toolStripSeparator2,
            this.btnBack,
            this.btnFoward,
            this.toolStripSeparator1,
            this.btnSearch,
            this.toolStripSeparator4,
            this.btnViewTree,
            this.btnViewList,
            this.btnViewDetail,
            this.btnExchange,
            this.btnEqual,
            this.toolStripSeparator3});
            this.toolstrip1.Location = new System.Drawing.Point(0, 0);
            this.toolstrip1.Name = "toolstrip1";
            this.toolstrip1.Size = new System.Drawing.Size(1160, 25);
            this.toolstrip1.TabIndex = 5;
            this.toolstrip1.Text = "toolStrip1";
            this.toolstrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolstrip1_ItemClicked);
            // 
            // List1
            // 
            this.List1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List1.Location = new System.Drawing.Point(0, 0);
            this.List1.Name = "List1";
            this.List1.Size = new System.Drawing.Size(580, 589);
            this.List1.StrCurrentPath = "";
            this.List1.TabIndex = 0;
            this.List1.Enter += new System.EventHandler(this.List1_Enter);
            this.List1.Resize += new System.EventHandler(this.List1_Resize);
            // 
            // List2
            // 
            this.List2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List2.Location = new System.Drawing.Point(0, 0);
            this.List2.Name = "List2";
            this.List2.Size = new System.Drawing.Size(576, 589);
            this.List2.StrCurrentPath = "";
            this.List2.TabIndex = 0;
            this.List2.Enter += new System.EventHandler(this.List2_Enter);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "toolStripButton1";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 658);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolstrip1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolstrip1.ResumeLayout(false);
            this.toolstrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSplitButton btnViewTree;
        private System.Windows.Forms.ToolStripMenuItem showTree1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTree2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFoward;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFiles;
        private System.Windows.Forms.ToolStripMenuItem btnRename;
        private System.Windows.Forms.ToolStripMenuItem btnCopy1;
        private System.Windows.Forms.ToolStripMenuItem btnMove1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
        private System.Windows.Forms.ToolStripMenuItem menuMask;
        private System.Windows.Forms.ToolStripMenuItem btnSelectAll;
        private System.Windows.Forms.ToolStripMenuItem btnUnselectAll;
        private System.Windows.Forms.ToolStripMenuItem btnInvertSelection;
        private System.Windows.Forms.ToolStripMenuItem btnSelectAllWithSameExtension;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuShow;
        private System.Windows.Forms.ToolStripMenuItem btnShowList;
        private System.Windows.Forms.ToolStripMenuItem btnShowDetail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem showTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTree1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showTree2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem rereadSoureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnEqual;
        private System.Windows.Forms.ToolStripButton btnExchange;
        private System.Windows.Forms.ToolStripButton btnViewDetail;
        private System.Windows.Forms.ToolStripButton btnViewList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ToolStrip toolstrip1;
        private ItemsViewer List1;
        private ItemsViewer List2;
        private System.Windows.Forms.ToolStripButton btnReload;
    }
}