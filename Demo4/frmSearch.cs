using Demo4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public partial class frmSearch : Form
    {
        //List<Item> result = new List<Item>();

        bool flagSubFolder = true;

        string strPath = "";

        bool flagDateBetween = false;
        bool flagFileSize = false;
        int FileSizeOp = 0;
        bool flagNotOlderThan = false;
        bool flagOlderThan = false;

        ItemsViewer parenList;

        #region Constructor
        private void Init()
        {
            dateFrom.Enabled = false;
            dateTo.Enabled = false;

            cbFileSize.Enabled = false;
            cbFileSize.SelectedItem = cbFileSize.Items[0];

            cbFileSize1.Enabled = false;
            cbFileSize1.SelectedItem = cbFileSize1.Items[0];

            tbNotOlderThan.Enabled = false;
            cbNotOlderThan.Enabled = false;
            cbNotOlderThan.SelectedIndex = 2;

            tbOlderThan.Enabled = false;
            cbOlderThan.Enabled = false;
            cbOlderThan.SelectedIndex = 2;

            BottomPanelSizing();



        }

        public frmSearch()
        {

            InitializeComponent();
            Init();
            listView1.DoubleBuffered(true);
            tbPath.Text = "C:\\";

            HideBottomPanel();
        }
        public frmSearch(string strPath, ItemsViewer List)
        {

            InitializeComponent();

            LanguageChange();

            Init();
            listView1.DoubleBuffered(true);
            tbPath.Text = strPath;
            parenList = List;

            HideBottomPanel();
        }

        internal void SetPath(string strPath)
        {
            tbPath.Text = strPath;
        }

        #endregion

        #region Sizing

        private void HideBottomPanel()
        {
            MaximumSize = new Size(int.MaxValue, 200);
            panelBottom.Visible = false;
            Height = Height - panelBottom.Height;


        }

        private void ShowBottomPanel()
        {
            MaximumSize = new Size(int.MaxValue, int.MaxValue);

            panelBottom.Visible = true;
            if (Height == 199)
                Height = Height + 261;


        }

        private void BottomPanelSizing()
        {
            btnView.Size = new Size((Width - 60 - 30) / 4, 23);
            btnEdit.Size = new Size((Width - 60 - 30) / 4, 23);
            btnNewSearch.Size = new Size((Width - 60 - 30) / 4, 23);
            btnGoToFile.Size = new Size((Width - 60 - 30) / 4, 23);

            btnView.Location = new Point(30, 0);
            btnEdit.Location = new Point(btnView.Location.X + btnView.Width + 10, 0);
            btnNewSearch.Location = new Point(btnEdit.Location.X + btnView.Width + 10, 0);
            btnGoToFile.Location = new Point(btnNewSearch.Location.X + btnView.Width + 10, 0);
        }

        private void frmSearch_Resize(object sender, EventArgs e)
        {
            BottomPanelSizing();

            tbSearchFor.Width = Width - 600 + 340;
            tbPath.Width = Width - 600 + 305;
            button1.Location = new Point(Width - 600 + 403, button1.Location.Y);
        }
        #endregion




        #region SearchEvent
        public bool strContains(string str, string pattern)
        {
            return new Regex(
                "^" + Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", ".") + "$",
                RegexOptions.IgnoreCase | RegexOptions.Singleline
            ).IsMatch(str);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(strPath);

            TraversalTree(di);

            if ((backgroundWorker1.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Text = MultiLanguage.GetText("frmSearch_btnSearch_text");
            label3.Text = "[" + listView1.Groups[1].Items.Count + " " + MultiLanguage.GetText("files_text") + " " + MultiLanguage.GetText("and_text") + " " + listView1.Groups[0].Items.Count + " " + MultiLanguage.GetText("directories_text") + " " + MultiLanguage.GetText("frmSearch_found_text") + "]";

            btnView.Enabled = true;
            btnEdit.Enabled = true;
            btnNewSearch.Enabled = true;
            btnGoToFile.Enabled = true;

            if (e.Cancelled == true)
            {
                label3.Text += MultiLanguage.GetText("frmSearch_searchabout_text");
            }

            listView1.Items.Insert(0, label3.Text);


        }

        private void TraversalTree(DirectoryInfo di)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            label3.Text = di.FullName;
            if (di.Exists == false) //Kiem tra xem duong dan co ton tai khong 
                return;

            string strKey = tbSearchFor.Text;
            try
            {
                files = di.GetFiles();
            }
            catch
            {

            }

            if (files != null)
            {
                foreach (System.IO.FileInfo file in files)
                {
                    if (strContains(file.Name, strKey))
                    {


                        if (checkFileCondition(file))
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = file.FullName;
                            item.Group = listView1.Groups["File"];
                            item.Tag = file;
                            listView1.Items.Add(item);

                        }

                    }
                }
            }

            subDirs = di.GetDirectories();

            foreach (System.IO.DirectoryInfo folder in subDirs)
            {
                if (folder.Attributes.HasFlag(FileAttributes.System) || folder.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;

                if (strContains(folder.Name, strKey))
                {


                    if (checkFolderCondition(folder))
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = folder.FullName;
                        item.Group = listView1.Groups["Folder"];
                        item.Tag = folder;
                        listView1.Items.Add(item);

                    }

                }

                if (backgroundWorker1.CancellationPending == true)
                    return;

                if (flagSubFolder == true)
                    TraversalTree(folder);
            }
        }

        private bool checkFileCondition(FileInfo file)
        {
            int bitDate = 1;
            int bitFileSize = 1;
            int bitNotOlderThan = 1;
            int bitOlderThan = 1;

            if (flagDateBetween == true)
            {
                if (file.LastWriteTime > dateFrom.Value && file.LastWriteTime < dateTo.Value)
                {

                }
                else
                {
                    bitDate = 0;
                }
            }

            if (flagFileSize == true)
            {
                long compareSize = long.Parse(tbFileSize.Text);
                switch (cbFileSize1.SelectedIndex)
                {
                    case 0: break;
                    case 1: compareSize *= 1000; break;
                    case 2: compareSize *= 1000000; break;
                    case 3: compareSize *= 1000000000; break;
                }
                {
                    switch (FileSizeOp)
                    {
                        case 0:
                            {
                                if (file.Length != compareSize)
                                    bitFileSize = 0;
                                break;
                            }
                        case 1:
                            {
                                if (file.Length <= compareSize)
                                    bitFileSize = 0;
                                break;
                            }
                        case 2:
                            {
                                if (file.Length >= compareSize)
                                    bitFileSize = 0;
                                break;
                            }
                    }
                }
            }

            if (flagNotOlderThan == true)
            {
                TimeSpan compareTime = new TimeSpan();
                switch (cbNotOlderThan.SelectedIndex)
                {
                    case 0: compareTime = TimeSpan.FromMinutes(double.Parse(tbNotOlderThan.Text)); break;
                    case 1: compareTime = TimeSpan.FromHours(double.Parse(tbNotOlderThan.Text)); break;
                    case 2: compareTime = TimeSpan.FromDays(double.Parse(tbNotOlderThan.Text)); break;
                    case 3: compareTime = TimeSpan.FromDays(double.Parse(tbNotOlderThan.Text) * 7); break;
                    case 4: compareTime = TimeSpan.FromDays((double.Parse(tbNotOlderThan.Text) * 30)); break;
                    case 5: compareTime = TimeSpan.FromDays(double.Parse(tbNotOlderThan.Text) * 365); break;
                }
                if (DateTime.Now.Subtract(file.LastWriteTime) > compareTime)
                    bitNotOlderThan = 0;
            }

            if (flagOlderThan == true)
            {
                TimeSpan compareTime = new TimeSpan();
                switch (cbOlderThan.SelectedIndex)
                {
                    case 0: compareTime = TimeSpan.FromMinutes(double.Parse(tbOlderThan.Text)); break;
                    case 1: compareTime = TimeSpan.FromHours(double.Parse(tbOlderThan.Text)); break;
                    case 2: compareTime = TimeSpan.FromDays(double.Parse(tbOlderThan.Text)); break;
                    case 3: compareTime = TimeSpan.FromDays(double.Parse(tbOlderThan.Text) * 7); break;
                    case 4: compareTime = TimeSpan.FromDays((double.Parse(tbOlderThan.Text) * 30)); break;
                    case 5: compareTime = TimeSpan.FromDays(double.Parse(tbOlderThan.Text) * 365); break;
                }
                if (DateTime.Now.Subtract(file.LastWriteTime) < compareTime)
                    bitOlderThan = 0;
            }

            if (bitDate == 1 && bitFileSize == 1 && bitNotOlderThan == 1 && bitOlderThan == 1)
                return true;
            else
                return false;
        }

        private bool checkFolderCondition(DirectoryInfo folder)
        {
            int bitDate = 1;
            int bitFileSize = 1;
            int bitNotOlderThan = 1;
            int bitOlderThan = 1;

            if (flagDateBetween == true)
            {
                if (folder.LastWriteTime > dateFrom.Value && folder.LastWriteTime < dateTo.Value)
                {

                }
                else
                {
                    bitDate = 0;
                }
            }

            if (flagFileSize == true)
            {
                if ((double.Parse(tbFileSize.Text) != 0) || (FileSizeOp != 0))
                    bitFileSize = 0;
            }

            if (flagNotOlderThan == true)
            {
                TimeSpan compareTime = new TimeSpan();
                switch (cbNotOlderThan.SelectedIndex)
                {
                    case 0: compareTime = TimeSpan.FromMinutes(double.Parse(tbNotOlderThan.Text)); break;
                    case 1: compareTime = TimeSpan.FromHours(double.Parse(tbNotOlderThan.Text)); break;
                    case 2: compareTime = TimeSpan.FromDays(double.Parse(tbNotOlderThan.Text)); break;
                    case 3: compareTime = TimeSpan.FromDays(double.Parse(tbNotOlderThan.Text) * 7.0); break;
                    case 4: compareTime = TimeSpan.FromDays(double.Parse(tbNotOlderThan.Text) * 30.0); break;
                    case 5: compareTime = TimeSpan.FromDays(double.Parse(tbNotOlderThan.Text) * 365.0); break;
                }
                if (DateTime.Now.Subtract(folder.LastWriteTime) > compareTime)
                    bitNotOlderThan = 0;
            }

            if (flagOlderThan == true)
            {
                TimeSpan compareTime = new TimeSpan();
                switch (cbOlderThan.SelectedIndex)
                {
                    case 0: compareTime = TimeSpan.FromMinutes(double.Parse(tbOlderThan.Text)); break;
                    case 1: compareTime = TimeSpan.FromHours(double.Parse(tbOlderThan.Text)); break;
                    case 2: compareTime = TimeSpan.FromDays(double.Parse(tbOlderThan.Text)); break;
                    case 3: compareTime = TimeSpan.FromDays(double.Parse(tbOlderThan.Text) * 7); break;
                    case 4: compareTime = TimeSpan.FromDays((double.Parse(tbOlderThan.Text) * 30)); break;
                    case 5: compareTime = TimeSpan.FromDays(double.Parse(tbOlderThan.Text) * 365); break;
                }
                if (DateTime.Now.Subtract(folder.LastWriteTime) < compareTime)
                    bitOlderThan = 0;
            }

            if (bitDate == 1 && bitFileSize == 1 && bitNotOlderThan == 1 && bitOlderThan == 1)
                return true;
            else
                return false;
        }

        #endregion

        #region ControlEventHandle
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                ShowBottomPanel();

                btnView.Enabled = false;
                btnEdit.Enabled = false;
                btnNewSearch.Enabled = false;
                btnGoToFile.Enabled = false;

                listView1.Items.Clear();

                backgroundWorker1.RunWorkerAsync();

                btnSearch.Text = MultiLanguage.GetText("frmSearch_btnSearch_text_stop");

            }
            else
            {

                backgroundWorker1.CancelAsync();

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == true)
                backgroundWorker1.CancelAsync();
            else
            {
                Close();
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems[0].Tag != null)
            {
                if (listView1.SelectedItems[0].Tag.GetType() == typeof(FileInfo))
                {
                    FileInfo a = (FileInfo)listView1.SelectedItems[0].Tag;
                    label3.Text = a.LastWriteTime.ToShortDateString() + " " + a.LastWriteTime.ToLongTimeString() + ", " + a.Length + " bytes";

                }
                else
                {
                    DirectoryInfo a = (DirectoryInfo)listView1.SelectedItems[0].Tag;
                    label3.Text = a.LastWriteTime.ToShortDateString() + " " + a.LastWriteTime.ToLongTimeString() + ", 0 bytes";
                }
            }
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems[0].Tag != null)
            {

                if (listView1.SelectedItems[0].Tag.GetType() == typeof(FileInfo))
                {
                    FileInfo temp = (FileInfo)listView1.SelectedItems[0].Tag;
                    Item res = new MyFile(temp, temp.DirectoryName[temp.DirectoryName.Length - 1].ToString() == "\\" ? temp.DirectoryName : temp.DirectoryName + "\\");

                    //Process p = new Process();
                    //FileInfo a = (FileInfo)listView1.SelectedItems[0].Tag;
                    //p.StartInfo.WorkingDirectory = a.Directory.ToString();
                    //p.StartInfo.FileName = a.Name;
                    //p.Start();

                    //MessageBox.Show(res.strParentPath);
                    parenList.SelectItemFormPath(res);
                }
                else
                {
                    DirectoryInfo a = (DirectoryInfo)listView1.SelectedItems[0].Tag;
                    Item res = new Folder(a, a.FullName[a.FullName.Length - 1].ToString() == "\\" ? a.FullName : a.FullName + "\\");
                    parenList.SelectItemFormPath(res);
                }
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog temp = new FolderBrowserDialog();
            temp.ShowDialog();
            if (temp.SelectedPath != "")
                tbPath.Text = temp.SelectedPath;
        }
        private void chkSub_Click(object sender, EventArgs e)
        {
            if (chkSub.Checked == true)
            {
                flagSubFolder = true;

            }
            else
            {
                flagSubFolder = false;

            }
        }
        private void tbPath_TextChanged(object sender, EventArgs e)
        {
            strPath = tbPath.Text;
        }
        private void chkFileSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFileSize.Checked == true)
            {
                flagFileSize = true;
                cbFileSize.Enabled = true;
                tbFileSize.Enabled = true;
                cbFileSize1.Enabled = true;

            }
            else
            {
                flagFileSize = false;
                cbFileSize.Enabled = false;
                tbFileSize.Enabled = false;
                cbFileSize1.Enabled = false;
            }
        }
        private void cbFileSize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FileSizeOp = cbFileSize.SelectedIndex;
        }
        private void chkNotOlderThan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotOlderThan.Checked == true)
            {
                flagNotOlderThan = true;
                chkDateBetween.Checked = false;
                tbNotOlderThan.Enabled = true;
                cbNotOlderThan.Enabled = true;
            }
            else
            {
                flagNotOlderThan = false;
                tbNotOlderThan.Enabled = false;
                cbNotOlderThan.Enabled = false;
            }
        }
        private void chkOlderThan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOlderThan.Checked == true)
            {
                flagOlderThan = true;
                chkDateBetween.Checked = false;
                tbOlderThan.Enabled = true;
                cbOlderThan.Enabled = true;
            }
            else
            {
                flagOlderThan = false;
                tbOlderThan.Enabled = false;
                cbOlderThan.Enabled = false;
            }
        }
        private void chkDateBetween_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateBetween.Checked == true)
            {
                flagDateBetween = true;
                dateFrom.Enabled = true;
                dateTo.Enabled = true;
                chkNotOlderThan.Checked = false;
                chkOlderThan.Checked = false;
            }
            else
            {
                flagDateBetween = false;
                dateFrom.Enabled = false;
                dateTo.Enabled = false;
            }
        }

        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewEvent();
        }

        private void ViewEvent()
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            if (listView1.SelectedItems[0].Tag != null)
            {

                if (listView1.SelectedItems[0].Tag.GetType() == typeof(FileInfo))
                {
                    Process p = new Process();
                    FileInfo a = (FileInfo)listView1.SelectedItems[0].Tag;
                    p.StartInfo.WorkingDirectory = a.Directory.ToString();
                    p.StartInfo.FileName = a.Name;
                    p.Start();


                }
                else
                {
                    DirectoryInfo a = (DirectoryInfo)listView1.SelectedItems[0].Tag;
                    Item res = new Folder(a, a.FullName[a.FullName.Length - 1].ToString() == "\\" ? a.FullName : a.FullName + "\\");
                    parenList.SelectItemFormPath(res);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void EditEvent()
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            if (listView1.SelectedItems[0].Tag != null)
            {

                if (listView1.SelectedItems[0].Tag.GetType() == typeof(FileInfo))
                {
                    FileInfo temp = (FileInfo)listView1.SelectedItems[0].Tag;
                    Item res = new MyFile(temp, temp.DirectoryName[temp.DirectoryName.Length - 1].ToString() == "\\" ? temp.DirectoryName : temp.DirectoryName + "\\");

                    //Process p = new Process();
                    //FileInfo a = (FileInfo)listView1.SelectedItems[0].Tag;
                    //p.StartInfo.WorkingDirectory = a.Directory.ToString();
                    //p.StartInfo.FileName = a.Name;
                    //p.Start();

                    //MessageBox.Show(res.strParentPath);
                    res.EditWithNotepad();
                }
                else
                {

                }
            }
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            HideBottomPanel();
            listView1.Items.Clear();
            tbSearchFor.Text = "*";
        }

        #endregion

        #region Language
        internal void LanguageChange()
        {
            Text = MultiLanguage.GetText("frmSearch_text");

            btnSearch.Text = MultiLanguage.GetText("frmSearch_btnSearch_text");
            btnCancel.Text = MultiLanguage.GetText("frmSearch_btnCancle_text");
            tab1.TabPages[0].Text = MultiLanguage.GetText("frmSearch_tabGeneral_text");
            tab1.TabPages[1].Text = MultiLanguage.GetText("frmSearch_tabAdvanced_text");
            txtSearchFor.Text = MultiLanguage.GetText("frmSearch_txtSearchFor_text");
            txtSearchIn.Text = MultiLanguage.GetText("frmSearch_txtSearchIn_text");
            chkSub.Text = MultiLanguage.GetText("frmSearch_chkSubFolder_text");
            txtSearchResult.Text = MultiLanguage.GetText("frmSearch_txtSearchResult_text");
            btnView.Text = MultiLanguage.GetText("btnView_text");
            btnEdit.Text = MultiLanguage.GetText("btnEdit_text");
            btnGoToFile.Text = MultiLanguage.GetText("frmSearch_btnGoToFile_text");
            btnNewSearch.Text = MultiLanguage.GetText("frmSearch_btnNewSearch_text");
            chkDateBetween.Text = MultiLanguage.GetText("frmSearch_chkDateBetween_text");
            txtAnd.Text = MultiLanguage.GetText("and_text");
            chkNotOlderThan.Text = MultiLanguage.GetText("frmSearch_chkNotOlderThan_text");
            chkOlderThan.Text = MultiLanguage.GetText("frmSearch_chkOlderThan_text");
            chkFileSize.Text = MultiLanguage.GetText("frmSearch_chkFileSize_text");

            cbNotOlderThan.Items.Clear();
            cbNotOlderThan.Items.Add(MultiLanguage.GetText("Minutes_text").ToString());
            cbNotOlderThan.Items.Add(MultiLanguage.GetText("Hours_text"));
            cbNotOlderThan.Items.Add(MultiLanguage.GetText("Days_text"));
            cbNotOlderThan.Items.Add(MultiLanguage.GetText("Weeks_text"));
            cbNotOlderThan.Items.Add(MultiLanguage.GetText("Months_text"));
            cbNotOlderThan.Items.Add(MultiLanguage.GetText("Years_text"));

            cbOlderThan.Items.Clear();
            cbOlderThan.Items.Add(MultiLanguage.GetText("Minutes_text").ToString());
            cbOlderThan.Items.Add(MultiLanguage.GetText("Hours_text"));
            cbOlderThan.Items.Add(MultiLanguage.GetText("Days_text"));
            cbOlderThan.Items.Add(MultiLanguage.GetText("Weeks_text"));
            cbOlderThan.Items.Add(MultiLanguage.GetText("Months_text"));
            cbOlderThan.Items.Add(MultiLanguage.GetText("Years_text"));



        }


        #endregion

        private void btnGoToFile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            if (listView1.SelectedItems[0].Tag != null)
            {

                if (listView1.SelectedItems[0].Tag.GetType() == typeof(FileInfo))
                {
                    FileInfo temp = (FileInfo)listView1.SelectedItems[0].Tag;
                    Item res = new MyFile(temp, temp.DirectoryName[temp.DirectoryName.Length - 1].ToString() == "\\" ? temp.DirectoryName : temp.DirectoryName + "\\");

                    //Process p = new Process();
                    //FileInfo a = (FileInfo)listView1.SelectedItems[0].Tag;
                    //p.StartInfo.WorkingDirectory = a.Directory.ToString();
                    //p.StartInfo.FileName = a.Name;
                    //p.Start();

                    //MessageBox.Show(res.strParentPath);
                    parenList.SelectItemFormPath(res);
                }
                else
                {
                    DirectoryInfo a = (DirectoryInfo)listView1.SelectedItems[0].Tag;
                    Item res = new Folder(a, a.FullName[a.FullName.Length - 1].ToString() == "\\" ? a.FullName : a.FullName + "\\");
                    parenList.SelectItemFormPath(res);
                }
                this.Close();
            }
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ViewEvent();
            }
            else if (e.KeyCode == Keys.F4)
            {
                EditEvent();
            }
        }

        private void frmSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }

        private void cbNotOlderThan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
