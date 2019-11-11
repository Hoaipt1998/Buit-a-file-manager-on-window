using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Dolinay;


namespace Demo4
{
    public partial class ItemsViewer : UserControl
    {
        private string strCurrentPath = "";
        public string StrCurrentPath
        {
            get
            {
                return strCurrentPath;

            }

            set
            {
                strCurrentPath = value;
            }
        }
        public HistoryList history = new HistoryList();

        public ItemsViewer()
        {
            InitializeComponent();

            GetDriveInfo(cbDrive);

            history.Clear();

            Dolinay.DriveDetector driveDetector = new Dolinay.DriveDetector();
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);


        }



        internal void LoadDefaultDirectory(string v)
        {
            itemsList1.LoadDirectory(v);
            history.Clear();
        }

        public void SetFileCount(int iFiles, int nFiles, int iDirectory, int nDirectory, long selectedSize, long Size)
        {
            lblFileSelectCount.Text = selectedSize.ToString("n0") + " k / " + Size.ToString("n0") + " k " + MultiLanguage.GetText("in") + " " + iFiles.ToString() + " / " + nFiles.ToString() + " " + MultiLanguage.GetText("files_text") + ", " + iDirectory.ToString() + " / " + nDirectory.ToString() + " " + MultiLanguage.GetText("dirs_text");
        }

        public void Back()
        {
            if (history.CountBack() != 0)
            {
                history.CancelNextAdd();
                history.CancelFowardClear();

                itemsList1.LoadDirectory(history.Back(this));
            }
        }
        public void Foward()
        {
            if (history.CountFoward() != 0)
            {
                history.CancelNextAdd();
                history.CancelFowardClear();

                itemsList1.LoadDirectory(history.Next(this));
            }
        }
        public void SelectAllItems()
        {
            itemsList1.SelectAllItem();
        }
        public void UnselectAllItems()
        {
            itemsList1.UnselectAllItem();
        }
        public void EditFocusItem()
        {
            itemsList1.EditFocusItem();
        }
        public void ViewFocusItem()
        {
            itemsList1.ViewFocusItem();
        }
        public void ReloadItems()
        {
            itemsList1.ReloadItems();
        }
        internal void Copy()
        {
            itemsList1.Copy();
        }
        internal void NewFolderInCurrentPath()
        {
            itemsList1.NewFolderInCurrentPath();
        }
        internal void Delete()
        {
            itemsList1.Delete();
        }
        internal void ShowTreeView()
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel1.Show();
        }
        internal void HideTreeView()
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel1.Hide();
        }
        internal void SelectItemFormPath(Item item)
        {
            this.Focus();
            if (item.GetType() == typeof(MyFile))
            {
                itemsList1.LoadDirectory(item.strParentPath);
                itemsList1.FocusItem(item);

            }
            else
            {
                itemsList1.LoadDirectory(item.strParentPath);
            }
        }

        #region ComboBox
        private void GetDriveInfo(ComboBox comboBox1)
        {
            foreach (System.IO.DriveInfo drive in System.IO.DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.CDRom)
                {
                    if (drive.IsReady != false)
                        comboBox1.Items.Add(drive.Name.ToString());
                }
                else
                    comboBox1.Items.Add(drive.Name.ToString());

            }
        }

        public void SelectDriveFromDirectory(string strCurrentPath)
        {
            if (strCurrentPath != "")
                cbDrive.SelectedIndex = cbDrive.FindStringExact(strCurrentPath.Substring(0, 3));

        }



        private void cbDrive_SelectedIndexChanged(object sender, EventArgs e)
        {

            ToolStripComboBox cb = (ToolStripComboBox)sender;
            itemsList1.LoadDirectory(cb.SelectedItem.ToString());


        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            itemsList1.LoadDirectory(cb.SelectedItem.ToString());

        }

        private void cbDrive_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetDiskInfo();
        }

        string strFreeSpace;
        string strTotalSize;
        string strDriveLabel;
        private void GetDiskInfo()
        {
            System.IO.DriveInfo drive = new DriveInfo(cbDrive.SelectedItem.ToString());
            strFreeSpace = (drive.AvailableFreeSpace / 1000).ToString("n0");
            strTotalSize = (drive.TotalSize / 1000).ToString("n0");
            strDriveLabel = drive.VolumeLabel;

            //int strLen = strFreeSpace.Length;
            //for (int i = 1; i <= (((strLen % 3) == 0) ? ((strLen / 3) - 1) : (strLen / 3)); i++)
            //{
            //    strFreeSpace = strFreeSpace.Insert(strLen - 3 * i, ",");

            //}

            //strLen = strTotalSize.Length;
            //for (int i = 1; i <= (((strLen % 3) == 0) ? ((strLen / 3) - 1) : (strLen / 3)); i++)
            //{
            //    strTotalSize = strTotalSize.Insert(strLen - 3 * i, ",");

            //}

            SetDriveInfoLabel();

        }

        private void SetDriveInfoLabel()
        {
           lbDrive.Text = "[" + strDriveLabel + "]  " + strFreeSpace + " k " + MultiLanguage.GetText("text_of") + " " + strTotalSize + " k " + MultiLanguage.GetText("text_free");
        }

        #endregion

        #region Label

        public void SetAddressLabel(string strPath)
        {
            lbAddress.Text = strPath;
        }

        internal void LanguageChange()
        {
            itemsList1.LanguageChange();
            SetDriveInfoLabel();

            itemsList1.UpdateItemsCount();
        }

        #endregion

        #region DriveDetector
        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            if (cbDrive.Items.Contains(e.Drive))
            {
                cbDrive.Items.Remove(e.Drive);
                itemsTree1.RemoveDrive(e.Drive);

                if (strCurrentPath.Contains(e.Drive))
                    LoadDefaultDirectory("C:\\");

            }

        }

        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            if (cbDrive.Items.Contains(e.Drive) == false)
            {
                cbDrive.Items.Add(e.Drive);
                itemsTree1.AddDrive(e.Drive, DriveType.Removable);
            }
        }

        #endregion

        internal void ViewMode(ViewStyle a)
        {
            itemsList1.ViewMode(a);
        }

        internal void InvertSelection()
        {
            itemsList1.InvertSelection();
        }

        internal void SelectAllWithSameExtension()
        {
            itemsList1.SelectAllWithSameExtension();
        }

        internal void MoveItems()
        {
            itemsList1.MoveItems();
        }

        internal void CopyToClipboard()
        {
            itemsList1.CopyToClipboard();
        }

        internal void CutToClipboard()
        {
            itemsList1.CutToClipboard();
        }

        internal void CopySelectedNameToClipboard()
        {
            itemsList1.CopySelectedNameToClipboard();
        }

        internal void CopyNamesWithPathToClipboard()
        {
            itemsList1.CopyNamesWithPathToClipboard();
        }

        internal void CopyToClipboardWithAllDetail()
        {
            itemsList1.CopyToClipboardWithAllDetail();
        }

        internal void CopyToLipboardWithPathDetails()
        {
            itemsList1.CopyToLipboardWithPathDetails();
        }

        internal void MultiRename()
        {
            itemsList1.MultiRename();
        }

        internal void RenameFocusItem()
        {
            itemsList1.RenameFocusItem();
        }

        internal void LoadDirectory(string strPath)
        {
            itemsList1.LoadDirectory(strPath);
        }

        internal void SplitFile()
        {
           

        }

        private void itemsTree1_Load(object sender, EventArgs e)
        {

        }
    }
}
