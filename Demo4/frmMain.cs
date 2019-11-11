using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public partial class frmMain : Form
    {

        int ListActive = 1; //Kiem tra xem List nao dang active



        frmSearch frmsearch;
        public frmMain()
        {

            InitializeComponent();

            List1.LoadDefaultDirectory("C:\\");
           List2.LoadDefaultDirectory("C:\\");

            LanguageChange();

            BottomPanelSizing();

            AddLanguageToMenu();
        }
        private void BottomPanelSizing()
        {
            Size btnSize = new Size((Width - 40 - 18) / 7, 20);
            btnView.Size = btnSize;
            btnEdit.Size = btnSize;
            btnCopy.Size = btnSize;
            btnMove.Size = btnSize;
            btnNewFolder.Size = btnSize;
            btnDelete.Size = btnSize;
            btnExit.Size = btnSize;


            btnView.Location = new Point(15, 0);
            btnEdit.Location = new Point(btnView.Location.X + btnView.Width + 3, 0);
            btnCopy.Location = new Point(btnEdit.Location.X + btnView.Width + 3, 0);
            btnMove.Location = new Point(btnCopy.Location.X + btnView.Width + 3, 0);
            btnNewFolder.Location = new Point(btnMove.Location.X + btnView.Width + 3, 0);
            btnDelete.Location = new Point(btnNewFolder.Location.X + btnView.Width + 3, 0);
            btnExit.Location = new Point(btnDelete.Location.X + btnView.Width + 3, 0);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.ReloadItems();
            else
                List2.ReloadItems();
        }

        private void List1_Enter(object sender, EventArgs e)
        {
            ListActive = 1;
        }
        private void AddLanguageToMenu()
        {
            foreach (string lang in MultiLanguage.GetAllLanguage())
            {
                ToolStripMenuItem temp = new ToolStripMenuItem(lang);

                menuLanguage.DropDownItems.Add(temp);
                temp.Click += ClickChangeLanguage;
            }
        }
        private void ClickChangeLanguage(object sender, EventArgs e)
        {
            MultiLanguage.selectedLanguage = ((ToolStripMenuItem)sender).Text;

            this.LanguageChange();
        }

        private void List2_Enter(object sender, EventArgs e)
        {
            ListActive = 2;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.Back();
            else
                List2.Back();
        }

        private void btnFoward_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.Foward();
            else
                List2.Foward();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (frmsearch == null)
                frmsearch = new frmSearch(List1.StrCurrentPath, List1);
            else
            {
                frmsearch.SetPath(List1.StrCurrentPath);
            }


            frmsearch.ShowDialog();
            frmsearch.Focus();
        }

        private void btnViewTree_ButtonClick(object sender, EventArgs e)
        {
            if (ListActive == 1)
            {
                if (showTree1ToolStripMenuItem.Checked == true)
                {
                    List1.HideTreeView();
                    showTree1ToolStripMenuItem.Checked = false;
                    showTree1ToolStripMenuItem1.Checked = false;
                }
                else
                {
                    List1.ShowTreeView();
                    showTree1ToolStripMenuItem.Checked = true;
                    showTree1ToolStripMenuItem1.Checked = true;
                }
            }
            else
            {
                if (showTree2ToolStripMenuItem.Checked == true)
                {
                    List2.HideTreeView();
                    showTree2ToolStripMenuItem.Checked = false;
                    showTree2ToolStripMenuItem1.Checked = false;
                }
                else
                {
                    List2.ShowTreeView();
                    showTree2ToolStripMenuItem.Checked = true;
                    showTree2ToolStripMenuItem1.Checked = false;
                }
            }
        }

        private void showTree1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (showTree1ToolStripMenuItem.Checked == true)
            {
                showTree1ToolStripMenuItem.Checked = false;
                showTree1ToolStripMenuItem1.Checked = false;
                List1.HideTreeView();
            }
            else
            {
                showTree1ToolStripMenuItem.Checked = true;
                showTree1ToolStripMenuItem1.Checked = true;
                List1.ShowTreeView();
            }
        }

        private void showTree2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (showTree2ToolStripMenuItem.Checked == true)
            {
                List2.HideTreeView();
                showTree2ToolStripMenuItem.Checked = false;
                showTree2ToolStripMenuItem1.Checked = false;
            }
            else
            {
                List2.ShowTreeView();
                showTree2ToolStripMenuItem.Checked = true;
                showTree2ToolStripMenuItem1.Checked = true;
            }
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
            {
                List1.ViewMode(ViewStyle.List);
            }
            else
            {
                List2.ViewMode(ViewStyle.List);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
            {
                List1.ViewMode(ViewStyle.Details);
            }
            else
            {
                List2.ViewMode(ViewStyle.Details);
            }
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            SwitchList();
        }
        private void SwitchList()
        {
            if (List1.Parent == splitContainer1.Panel1)
            {
                List1.Parent = splitContainer1.Panel2;
                List2.Parent = splitContainer1.Panel1;
            }
            else
            {
                List1.Parent = splitContainer1.Panel1;
                List2.Parent = splitContainer1.Panel2;
            }

        }

        private void TargetEqualSource()
        {
            if (ListActive == 1)
            {
                List2.LoadDirectory(List1.StrCurrentPath);
            }
            else
            {
                List1.LoadDirectory(List2.StrCurrentPath);
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            TargetEqualSource();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
            {
                List1.RenameFocusItem();
            }
            else
            {
                List2.RenameFocusItem();
            }
        }

        private void btnCopy1_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.Copy();
            else
                List2.Copy();
        }

        private void btnMove1_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.MoveItems();
            else
                List2.MoveItems();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.SelectAllItems();
            else
                List2.SelectAllItems();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.UnselectAllItems();
            else
                List2.UnselectAllItems();
        }

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.InvertSelection();
            else
                List2.InvertSelection();
        }

        private void btnSelectAllWithSameExtension_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.SelectAllWithSameExtension();
            else
                List2.SelectAllWithSameExtension();
        }

        private void menuLanguage_Click(object sender, EventArgs e)
        {

        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
            {
                List1.ViewMode(ViewStyle.List);
            }
            else
            {
                List2.ViewMode(ViewStyle.List);
            }
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
            {
                List1.ViewMode(ViewStyle.Details);
            }
            else
            {
                List2.ViewMode(ViewStyle.Details);
            }
        }

        private void showTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
            {
                if (showTree1ToolStripMenuItem.Checked == true)
                {
                    List1.HideTreeView();
                    showTree1ToolStripMenuItem.Checked = false;
                    showTree1ToolStripMenuItem1.Checked = false;
                }
                else
                {
                    List1.ShowTreeView();
                    showTree1ToolStripMenuItem.Checked = true;
                    showTree1ToolStripMenuItem1.Checked = true;
                }
            }
            else
            {
                if (showTree2ToolStripMenuItem.Checked == true)
                {
                    List2.HideTreeView();
                    showTree2ToolStripMenuItem.Checked = false;
                    showTree2ToolStripMenuItem1.Checked = false;
                }
                else
                {
                    List2.ShowTreeView();
                    showTree2ToolStripMenuItem.Checked = true;
                    showTree2ToolStripMenuItem1.Checked = false;
                }
            }
        }

        private void showTree1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (showTree1ToolStripMenuItem1.Checked == true)
            {
                showTree1ToolStripMenuItem.Checked = false;
                showTree1ToolStripMenuItem1.Checked = false;
                List1.HideTreeView();
            }
            else
            {
                showTree1ToolStripMenuItem.Checked = true;
                showTree1ToolStripMenuItem1.Checked = true;
                List1.ShowTreeView();
            }
        }

        private void showTree2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (showTree2ToolStripMenuItem1.Checked == true)
            {
                List2.HideTreeView();
                showTree2ToolStripMenuItem.Checked = false;
                showTree2ToolStripMenuItem1.Checked = false;
            }
            else
            {
                List2.ShowTreeView();
                showTree2ToolStripMenuItem.Checked = true;
                showTree2ToolStripMenuItem1.Checked = true;
            }
        }

        private void rereadSoureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.ReloadItems();
            else
                List2.ReloadItems();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            About k = new About();
            k.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.ViewFocusItem();
            else
                List2.ViewFocusItem();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.EditFocusItem();
            else
                List2.EditFocusItem();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.Copy();
            else
                List2.Copy();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.MoveItems();
            else
                List2.MoveItems();
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.NewFolderInCurrentPath();
            else
                List2.NewFolderInCurrentPath();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ListActive == 1)
                List1.Delete();
            else
                List2.Delete();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void InitSize()
        {
            int btnWidth = panel1.Width / 7;
            btnView.Size = new Size(btnWidth, btnEdit.Size.Height);
            btnEdit.Size = new Size(btnWidth, btnEdit.Size.Height);
            btnCopy.Size = new Size(btnWidth, btnEdit.Size.Height);
            btnMove.Size = new Size(btnWidth, btnEdit.Size.Height);
            btnNewFolder.Size = new Size(btnWidth, btnEdit.Size.Height);
            btnDelete.Size = new Size(btnWidth, btnEdit.Size.Height);
            btnExit.Size = new Size(btnWidth, btnEdit.Size.Height);
        }

        private void toolstrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void List1_Resize(object sender, EventArgs e)
        {

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            InitSize();
        }
        private void LanguageChange()
        {

            this.Text = MultiLanguage.GetText("frmMain_text");

            btnView.Text = MultiLanguage.GetText("btnView_text");
            btnEdit.Text = MultiLanguage.GetText("btnEdit_text");
            btnCopy.Text = MultiLanguage.GetText("btnCopy_text");
            btnMove.Text = MultiLanguage.GetText("btnMove_text");
            btnNewFolder.Text = MultiLanguage.GetText("btnNewFolder_text");
            btnDelete.Text = MultiLanguage.GetText("btnDelete_text");
            btnExit.Text = MultiLanguage.GetText("btnExit_text");
            menuFiles.Text = MultiLanguage.GetText("menuFile_text");
            menuMask.Text = MultiLanguage.GetText("menuMark_text");
            btnBack.Text = MultiLanguage.GetText("btnBack_text");
            btnReload.Text = MultiLanguage.GetText("btnReload_text");
            btnFoward.Text = MultiLanguage.GetText("btnFoward_text");
            btnSearch.Text = MultiLanguage.GetText("btnSearch_text");
            btnSelectAll.Text = MultiLanguage.GetText("btnSelectAll_text");
            btnUnselectAll.Text = MultiLanguage.GetText("btnUnselectAll_text");
            btnInvertSelection.Text = MultiLanguage.GetText("btnInvertSelection_text");
            btnSelectAllWithSameExtension.Text = MultiLanguage.GetText("btnSelectAllWithSameExt_text");
         
            btnViewTree.Text = MultiLanguage.GetText("btnShowTree_text");
            showTreeToolStripMenuItem.Text = MultiLanguage.GetText("btnShowTree_text");
            showTree1ToolStripMenuItem.Text = MultiLanguage.GetText("btnShowTree1_text");
            showTree2ToolStripMenuItem.Text = MultiLanguage.GetText("btnShowTree2_text");
            showTree1ToolStripMenuItem1.Text = MultiLanguage.GetText("btnShowTree1_text");
            showTree2ToolStripMenuItem1.Text = MultiLanguage.GetText("btnShowTree2_text");
            rereadSoureToolStripMenuItem.Text = MultiLanguage.GetText("btnReload_text");
       
            menuAbout.Text = MultiLanguage.GetText("menuAbout_text");
            //btnNotepad.Text = MultiLanguage.GetText("btnNotepad_text");
            menuLanguage.Text = MultiLanguage.GetText("menu_language_text");
            menuShow.Text = MultiLanguage.GetText("menu_show_text");
            btnViewDetail.Text = MultiLanguage.GetText("view_detail_text");
            btnViewList.Text = MultiLanguage.GetText("view_list_text");
            btnShowDetail.Text = MultiLanguage.GetText("view_detail_text");
            btnShowList.Text = MultiLanguage.GetText("view_list_text");

            btnRename.Text = MultiLanguage.GetText("btnRename_text");
            btnCopy1.Text = MultiLanguage.GetText("Copy_text");
            btnMove1.Text = MultiLanguage.GetText("move_text");
     
            btnExchange.Text = MultiLanguage.GetText("btnExchange_text");
            btnEqual.Text = MultiLanguage.GetText("btnEqual_text");
       
            List1.LanguageChange();
            List2.LanguageChange();

            if (frmsearch != null)
                frmsearch.LanguageChange();
        }


    }
}
