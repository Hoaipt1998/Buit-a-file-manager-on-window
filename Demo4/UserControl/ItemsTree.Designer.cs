namespace Demo4
{
    partial class ItemsTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsTree));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder");
            this.imageList1.Images.SetKeyName(1, "drive.png");
            this.imageList1.Images.SetKeyName(2, "usb_drive.png");
            this.imageList1.Images.SetKeyName(3, "A");
            this.imageList1.Images.SetKeyName(4, "B");
            this.imageList1.Images.SetKeyName(5, "C");
            this.imageList1.Images.SetKeyName(6, "D");
            this.imageList1.Images.SetKeyName(7, "E");
            this.imageList1.Images.SetKeyName(8, "F");
            this.imageList1.Images.SetKeyName(9, "G");
            this.imageList1.Images.SetKeyName(10, "H");
            this.imageList1.Images.SetKeyName(11, "I");
            this.imageList1.Images.SetKeyName(12, "J");
            this.imageList1.Images.SetKeyName(13, "K");
            this.imageList1.Images.SetKeyName(14, "L");
            this.imageList1.Images.SetKeyName(15, "M");
            this.imageList1.Images.SetKeyName(16, "N");
            this.imageList1.Images.SetKeyName(17, "O");
            this.imageList1.Images.SetKeyName(18, "P");
            this.imageList1.Images.SetKeyName(19, "Q");
            this.imageList1.Images.SetKeyName(20, "H");
            this.imageList1.Images.SetKeyName(21, "S");
            this.imageList1.Images.SetKeyName(22, "T");
            this.imageList1.Images.SetKeyName(23, "U");
            this.imageList1.Images.SetKeyName(24, "V");
            this.imageList1.Images.SetKeyName(25, "W");
            this.imageList1.Images.SetKeyName(26, "X");
            this.imageList1.Images.SetKeyName(27, "Y");
            this.imageList1.Images.SetKeyName(28, "Z");
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(347, 438);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // ItemsTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Name = "ItemsTree";
            this.Size = new System.Drawing.Size(347, 438);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView1;
    }
}
