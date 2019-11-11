using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Collections.Specialized;



namespace Demo4
{
    enum ViewStyle
    {
        Details,
        List
    };

    public partial class ItemsList : UserControl
    {


        private int SortIdx = (int)SortBy.NameASC;
        public int SortIdx1
        {
            get
            {
                return SortIdx;
            }

            set
            {
                SortIdx = value;
            }
        }

        private Item[] items;

        private Dictionary<int, Item> selectedItems = new Dictionary<int, Item>();
        public ItemsList()
        {

            InitializeComponent();
            listView1.DoubleBuffered(true);

            ClearAllHeaderImg(listView1);

        }

        public void LoadDirectory(string Path)
        {
            //Kiem tra su thay doi ve cac item trong duong dan



            ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;

            if (Path != "")
            {
                fileSystemWatcher1.Path = Path.Substring(0, 3);

                if (new DirectoryInfo(Path).Exists == false)
                {
                    //LoadDirectory( Path.Substring(0, 3));

                    ParentForm.history.CancelNextAdd();
                    ParentForm.history.CancelFowardClear();

                    string tempPath = Path.Split(new string[] { "\\" }, StringSplitOptions.None)[0] + "\\";
                    for (int i = 1; i < Path.Split(new string[] { "\\" }, StringSplitOptions.None).Length - 2; i++)
                    {
                        tempPath += ParentForm.StrCurrentPath.Split(new string[] { "\\" }, StringSplitOptions.None)[i] + "\\";
                    }
                    LoadDirectory(tempPath);

                    return;
                }
            }

            ItemsTree itemsTree = (ItemsTree)ParentForm.Controls.Find("itemsTree1", true).GetValue(0);


            listView1.Items.Clear();
            PopulateItems(listView1, Path);

            ParentForm.history.InsertDirectoryToListBack(ParentForm.StrCurrentPath);

            ParentForm.SelectDriveFromDirectory(Path);
            itemsTree.SelectNodeFormDirectory(Path);

            ParentForm.StrCurrentPath = Path;
            ParentForm.SetAddressLabel(Path);



            selectedItems.Clear();
            UpdateItemsCount();
        }

        public void UpdateItemsCount()
        {
            int nFiles = 0, nDirectory = 0;
            long nSize = 0;
            int iFiles = 0, iDirectory = 0;
            long selectedSize = 0;
            foreach (Item i in items)
            {


                if (i.GetType() == typeof(MyFile))
                {
                    nFiles++;
                    nSize += long.Parse(i.StrSize);
                }
                else
                {
                    nDirectory++;
                }

            }

            foreach (Item i in selectedItems.Values.ToList())
            {

                if (i.GetType() == typeof(MyFile))
                {
                    selectedSize += long.Parse(i.StrSize);
                    iFiles++;
                }
                else
                {

                    iDirectory++;
                }

            }

            ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;
            ParentForm.SetFileCount(iFiles, nFiles, iDirectory, nDirectory, selectedSize, nSize);

        }

        internal void NewFolderInCurrentPath()
        {
            var a = Microsoft.VisualBasic.Interaction.InputBox(MultiLanguage.GetText("new_folder_text"), MultiLanguage.GetText("folder_name_text"), MultiLanguage.GetText("name_text"));

            if (a != "")
            {
                ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;
                DirectoryInfo temp = new DirectoryInfo(ParentForm.StrCurrentPath + a + "\\");
                if (temp.Exists == true)
                {
                    MessageBox.Show(MultiLanguage.GetText("folder_exist"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    temp.Create();
                    ReloadItems();
                }
            }
        }

        internal void FocusItem(Item item)
        {
            listView1.Select();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text == item.StrName && listView1.Items[i].SubItems[1].Text == item.StrExt)
                {
                    listView1.Items[i].Selected = true;
                    listView1.EnsureVisible(i);
                    return;
                }
            }
        }
        internal void EditFocusItem()
        {
            Item temp = GetCurrentSelectedItem();
            if (temp != null)
            {
                temp.EditWithNotepad();
            }
            else
            {
                MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        internal void ViewFocusItem()
        {
            Item temp = GetCurrentSelectedItem();
            if (temp != null)
            {
                temp.OnClick(listView1, LoadDirectory);
            }
            else
            {
                MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        internal void ReloadItems()
        {
            ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;
            listView1.Items.Clear();


            ParentForm.history.CancelNextAdd();
            ParentForm.history.CancelFowardClear();

            Dictionary<int, Item> tempSelectedItems = new Dictionary<int, Item>(selectedItems);

            LoadDirectory(ParentForm.StrCurrentPath);

            selectedItems = tempSelectedItems;

            ReselectItems();
        }

        internal void Delete()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Delete Item dang duoc Focus
                {
                    DialogResult result = MessageBox.Show(MultiLanguage.GetText("delete?_text") + " \n  + " + temp.StrName, MultiLanguage.GetText("confirmation_text"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        GetCurrentSelectedItem().Delete();
                        ReloadItems();
                        UnselectAllItem();
                    }
                    else
                    {

                    }


                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Delete tu selectedList
            {
                string strItemNameToDelete = "";
                foreach (Item item in selectedItems.Values.ToList())
                {
                    strItemNameToDelete += "  +  " + item.StrName + item.StrExt + "\n";
                }

                DialogResult result = MessageBox.Show(MultiLanguage.GetText("delete?_text") + " \n" + strItemNameToDelete, MultiLanguage.GetText("confirmation_text"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (Item item in selectedItems.Values.ToList())
                    {
                        item.Delete();
                        UnselectAllItem();
                    }
                }

                // MessageBox.Show("Do you really want to move the selected item to recycle bin? \n" + strItemNameToDelete, "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            }
        }
        internal void Copy()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Copy tu Item dang duoc Focus
                {

                    frmCopy cpy = new frmCopy(temp);
                    cpy.ShowDialog();
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Copy tu selectedList
            {
                frmCopy cpy = new frmCopy(selectedItems.Values.ToList());
                cpy.ShowDialog();
            }
        }

        internal void RenameFocusItem()
        {

            Demo4.Item temp = this.GetCurrentSelectedItem();
            if (temp != null) //Rename item dang duoc focus
            {

                var a = Microsoft.VisualBasic.Interaction.InputBox(MultiLanguage.GetText("btnRename_text"), MultiLanguage.GetText("NewName_text"), temp.StrName + temp.StrExt);

                if (a != "")
                {
                    ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;

                    if (temp.GetType() == typeof(MyFile))
                    {

                        if (new FileInfo(ParentForm.StrCurrentPath + a).Exists == true)
                        {
                            MessageBox.Show(MultiLanguage.GetText("file_exist"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            new FileInfo(ParentForm.StrCurrentPath + temp.StrName + temp.StrExt).MoveTo(ParentForm.StrCurrentPath + a);
                        }
                    }
                    else
                    {

                        if (new DirectoryInfo(ParentForm.StrCurrentPath + a + "\\").Exists == true)
                        {
                            MessageBox.Show(MultiLanguage.GetText("folder_exist"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            new DirectoryInfo(ParentForm.StrCurrentPath + temp.StrName + "\\").MoveTo(ParentForm.StrCurrentPath + a + "\\");
                        }
                    }



                }
            }
            else
            {
                MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        internal void MultiRename()
        {
            if (selectedItems.Count == 0)
            {
                Demo4.Item temp = GetCurrentSelectedItem();
                if (temp != null) //Rename item dang duoc focus
                {
                    List<Item> tempList = new List<Item>();
                    tempList.Add(temp);
                    Demo4.RenameTool renametool = new Demo4.RenameTool(tempList);
                    renametool.Show();


                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Rename tu selectedList
            {
                Demo4.RenameTool renametool = new Demo4.RenameTool(selectedItems.Values.ToList());
                renametool.Show();
            }
        }

        internal void CopyNamesWithPathToClipboard()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Copy tu Item dang duoc Focus
                {

                    String Name = "";

                    Name += temp.strParentPath + temp.StrName + temp.StrExt;


                    Clipboard.SetText(Name);
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Copy tu selectedList
            {
                string Name = "";
                foreach (Item i in selectedItems.Values.ToList())
                {
                    Name += i.strParentPath + i.StrName + i.StrExt + "\r\n";
                }
                Clipboard.SetText(Name);
            }
        }

        internal void CopyToLipboardWithPathDetails()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Copy tu Item dang duoc Focus
                {

                    String Name = "";

                    Name += temp.strParentPath + temp.StrName + temp.StrExt + "\t" + temp.StrSize + "\t" + temp.StrDate + "\t" + temp.StrAttr;


                    Clipboard.SetText(Name);
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Copy tu selectedList
            {
                string Name = "";
                foreach (Item i in selectedItems.Values.ToList())
                {
                    Name += i.strParentPath + i.StrName + i.StrExt + "\t" + i.StrSize + "\t" + i.StrDate + "\t" + i.StrAttr + "\r\n";
                }
                Clipboard.SetText(Name);
            }
        }

        internal void CopyToClipboardWithAllDetail()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Copy tu Item dang duoc Focus
                {

                    String Name = "";

                    Name += temp.StrName + temp.StrExt + "\t" + temp.StrSize + "\t" + temp.StrDate + "\t" + temp.StrAttr;


                    Clipboard.SetText(Name);
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Copy tu selectedList
            {
                string Name = "";
                foreach (Item i in selectedItems.Values.ToList())
                {
                    Name += i.StrName + i.StrExt + "\t" + i.StrSize + "\t" + i.StrDate + "\t" + i.StrAttr + "\r\n";
                }
                Clipboard.SetText(Name);
            }
        }

        internal void CopySelectedNameToClipboard()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Copy tu Item dang duoc Focus
                {

                    String Name = "";

                    Name += temp.StrName + temp.StrExt;


                    Clipboard.SetText(Name);
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Copy tu selectedList
            {
                string Name = "";
                foreach (Item i in selectedItems.Values.ToList())
                {
                    Name += i.StrName + i.StrExt + "\r\n";
                }
                Clipboard.SetText(Name);
            }
        }

        internal void CutToClipboard()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Copy tu Item dang duoc Focus
                {
                    byte[] moveEffect = { 2, 0, 0, 0 };
                    MemoryStream dropEffect = new MemoryStream();
                    dropEffect.Write(moveEffect, 0, moveEffect.Length);

                    StringCollection paths = new StringCollection();
                    paths.Add(temp.strParentPath + temp.StrName + temp.StrExt);
                    DataObject data = new DataObject("Preferred DropEffect", dropEffect);
                    data.SetFileDropList(paths);

                    Clipboard.Clear();
                    Clipboard.SetDataObject(data, true);

                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Copy tu selectedList
            {
                StringCollection paths = new StringCollection();
                foreach (Item i in selectedItems.Values.ToList())
                {
                    paths.Add(i.strParentPath + i.StrName + i.StrExt);
                }
                byte[] moveEffect = { 2, 0, 0, 0 };

                MemoryStream dropEffect = new MemoryStream();
                dropEffect.Write(moveEffect, 0, moveEffect.Length);

                DataObject data = new DataObject("Preferred DropEffect", dropEffect);
                data.SetFileDropList(paths);

                Clipboard.Clear();
                Clipboard.SetDataObject(data, true);


            }
        }

        internal void CopyToClipboard()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Copy tu Item dang duoc Focus
                {

                    StringCollection paths = new StringCollection();
                    paths.Add(temp.strParentPath + temp.StrName + temp.StrExt);
                    Clipboard.SetFileDropList(paths);

                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Copy tu selectedList
            {
                StringCollection paths = new StringCollection();
                foreach (Item i in selectedItems.Values.ToList())
                {
                    paths.Add(i.strParentPath + i.StrName + i.StrExt);
                }
                Clipboard.SetFileDropList(paths);
            }
        }

        internal void MoveItems()
        {
            if (selectedItems.Count == 0)
            {
                Item temp = GetCurrentSelectedItem();
                if (temp != null) //Move tu Item dang duoc Focus
                {

                    frmCopy cpy = new frmCopy(temp, "", CopyType.Move);
                    cpy.ShowDialog();
                }
                else
                {
                    MessageBox.Show(MultiLanguage.GetText("no_item_selected"), MultiLanguage.GetText("error_text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else //Move tu selectedList
            {
                frmCopy cpy = new frmCopy(selectedItems.Values.ToList(), "", CopyType.Move);
                cpy.ShowDialog();
            }
        }

        internal void LanguageChange()
        {
            listView1.Columns[0].Text = MultiLanguage.GetText("clmName_text");
            listView1.Columns[1].Text = MultiLanguage.GetText("clmExt_text");
            listView1.Columns[2].Text = MultiLanguage.GetText("clmSize_text");
            listView1.Columns[3].Text = MultiLanguage.GetText("clmDate_text");
            listView1.Columns[4].Text = MultiLanguage.GetText("clmAttr_text");
        }

        private Item GetCurrentSelectedItem()
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                return null;
            }

            int idx = listView1.SelectedIndices[0];

            if (listView1.Items[0].Text == "[...]")
            {
                if (idx == 0)
                {
                    return null;

                }
                else
                {
                    return items[idx - 1];
                }
            }
            else
            {
                return items[idx];
            }
        }





        #region AddItemToListView
        private void PopulateItems(ListView listView1, string Path)
        {
            //Neu duong dan khong ton tai tro ve root


            items = Item.GetSortedItemsFromPath(Path, SortIdx);
            AddGoToParentItem(listView1, Path);
            foreach (Item i in items)
            {
                InsertItemToListView(listView1, i);
            }
        }
        private void AddGoToParentItem(ListView listView1, string Path)
        {
            if (Folder.GetParentDirectory(Path) != null)
            {
                listView1.Items.Add("[...]", 1);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                listView1.Items[0].Name = Folder.GetParentDirectory(Path.ToString());
            }
        }
        private void InsertItemToListView(ListView listView1, Item i)
        {
            listView1.Items.Add(i.StrName);
            int n = listView1.Items.Count;
            listView1.Items[n - 1].SubItems.Add(i.StrExt);

            if (i.StrSize == "<DIR>")
                listView1.Items[n - 1].SubItems.Add(i.StrSize);
            else
                listView1.Items[n - 1].SubItems.Add(long.Parse(i.StrSize).ToString("n0"));

            listView1.Items[n - 1].SubItems.Add(i.StrDate);
            listView1.Items[n - 1].SubItems.Add(i.StrAttr);
            listView1.Items[n - 1].ImageKey = i.getIcon(imageList1);
        }
        #endregion

        #region ItemDoubleClick
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;
            ItemsTree itemsTree = (ItemsTree)ParentForm.Controls.Find("itemsTree1", true).GetValue(0);

            if (e.Button == MouseButtons.Left)
            {

                ListView lv = (ListView)sender;

                int idx = lv.SelectedIndices[0];
                if (idx < 0 || idx > lv.Items.Count - 1)
                    return;

                if (lv.Items[0].Text == "[...]")
                {
                    if (idx == 0)
                    {
                        LoadDirectory((string)lv.Items[0].Name);

                    }
                    else
                    {
                        idx -= 1;
                        items[idx].OnClick(lv, LoadDirectory);
                    }
                }
                else
                {
                    items[idx].OnClick(lv, LoadDirectory);
                }
            }

        }
        #endregion

        #region ColumnClickSort
        private void ClearAllHeaderImg(ListView listView1)
        {
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].ImageKey = "Transparent";

            }
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;

            switch (e.Column)
            {
                case 0:
                    {

                        if (listView1.Columns[e.Column].ImageKey == "ASCIcon")
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "DESCIcon";
                            SortIdx = (int)SortBy.NameDESC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);
                        }
                        else
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "ASCIcon";
                            SortIdx = (int)SortBy.NameASC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);
                        }
                        ReselectItems();
                        break;
                    }
                case 1:
                    {
                        if (listView1.Columns[e.Column].ImageKey == "ASCIcon")
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "DESCIcon";
                            SortIdx = (int)SortBy.ExtDESC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);

                        }
                        else
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "ASCIcon";
                            SortIdx = (int)SortBy.ExtASC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);
                        }
                        ReselectItems();
                        break;
                    }
                case 2:
                    {
                        if (listView1.Columns[e.Column].ImageKey == "ASCIcon")
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "DESCIcon";
                            SortIdx = (int)SortBy.SizeDESC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);
                        }
                        else
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "ASCIcon";
                            SortIdx = (int)SortBy.SizeASC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);
                        }
                        ReselectItems();
                        break;
                    }
                case 3:
                    {
                        if (listView1.Columns[e.Column].ImageKey == "ASCIcon")
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "DESCIcon";
                            SortIdx = (int)SortBy.DateDESC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);
                        }
                        else
                        {
                            ClearAllHeaderImg(listView1);
                            listView1.Columns[e.Column].ImageKey = "ASCIcon";
                            SortIdx = (int)SortBy.DateASC;
                            listView1.Items.Clear();
                            PopulateItems(listView1, ParentForm.StrCurrentPath);
                        }
                        ReselectItems();
                        break;
                    }

            }
        }

        private void ReselectItems()
        {
            List<Item> temp1 = new List<Item>();
            temp1 = selectedItems.Values.ToList();

            List<string> temp2 = new List<string>();
            foreach (Item i in temp1)
            {
                temp2.Add(i.StrName + i.StrExt);
            }

            selectedItems.Clear();

            for (int i = 0; i < items.Length; i++)
            {
                if (temp2.Contains(items[i].StrName + items[i].StrExt))
                {

                    if (listView1.Items[0].Text == "[...]")
                    {
                        SelectItemWithIdx(i + 1);
                    }
                    else
                    {
                        SelectItemWithIdx(i);

                    }
                }
            }
        }
        #endregion

        #region MultiSelect and RightClickEvent

        private bool isTick = false;

        private void SelectItemWithIdx(int idx)
        {

            if (listView1.Items[0].Text == "[...]")
            {
                if (idx == 0 && listView1.Items[0].Text == "[...]")
                {


                }
                else
                {
                    listView1.Items[idx].ForeColor = Color.Red;
                    if (selectedItems.ContainsKey(idx) == false)
                        selectedItems.Add(idx, items[idx - 1]);

                }
            }
            else
            {
                listView1.Items[idx].ForeColor = Color.Red;
                if (selectedItems.ContainsKey(idx) == false)
                    selectedItems.Add(idx, items[idx]);
            }

            UpdateItemsCount();
        }
        private void UnselectItemWithIdx(int idx)
        {

            if (listView1.Items[0].Text == "[...]")
            {
                if (idx == 0)
                {


                }
                else
                {
                    listView1.Items[idx].ForeColor = Color.Black;
                    if (selectedItems.ContainsKey(idx) == true)
                        selectedItems.Remove(idx);
                }
            }
            else
            {
                listView1.Items[idx].ForeColor = Color.Black;
                if (selectedItems.ContainsKey(idx) == true)
                    selectedItems.Remove(idx);
            }

            UpdateItemsCount();
        }

        int currentIdx; //Get current Idx for Shift + Left Click
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                isTick = false;
                timer1.Start();

                progressBar1.Visible = true;
                progressBar1.Location = new Point(e.X + 15, e.Y + 15);
                progressBar1.Value = 0;
                timer2.Start();



            }

            //Shift + Left Click
            if (listView1.SelectedIndices.Count > 0)
                currentIdx = listView1.SelectedIndices[0];
            else
                currentIdx = -1;

        }
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;

            timer1.Stop();
            timer2.Stop();

            progressBar1.Visible = false;

            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedIndices.Count != 0)
                {
                    int idx = listView1.SelectedIndices[0];

                    if (isTick != true)
                    {
                        if (selectedItems.ContainsKey(idx) == false)
                            SelectItemWithIdx(idx);
                        else
                            UnselectItemWithIdx(idx);
                    }
                }

            }
            else
            {
                if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control) //Ctrl + Left Click
                {
                    ListViewItem item = (ListViewItem)listView1.SelectedItems[0];
                    if (selectedItems.ContainsKey(item.Index) == false)
                    {
                        SelectItemWithIdx(item.Index);
                    }
                }
                else
                {

                    if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Shift) == Keys.Shift && currentIdx != -1) //Ctrl + Shift Click
                    {
                        int Idx = listView1.SelectedIndices[0];
                        if (currentIdx < Idx)
                        {
                            for (int i = currentIdx; i <= Idx; i++)
                            {
                                if (selectedItems.ContainsKey(i) == false)
                                {
                                    SelectItemWithIdx(i);
                                }
                            }
                        }
                        else
                        {
                            for (int i = Idx; i <= currentIdx; i++)
                            {
                                if (selectedItems.ContainsKey(i) == false)
                                {
                                    SelectItemWithIdx(i);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Shift && e.KeyCode == Keys.Up) || (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Down))
            {
                if (listView1.SelectedIndices.Count > 0)
                    currentIdx = listView1.SelectedIndices[0];
                else
                    currentIdx = -1;
            }
            else if (e.KeyCode == Keys.F3)
            {
                this.ViewFocusItem();
            }
            else if (e.KeyCode == Keys.F4)
            {
                this.EditFocusItem();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.Copy();
            }
            else if (e.KeyCode == Keys.F6)
            {

            }
            else if (e.KeyCode == Keys.F7)
            {
                this.NewFolderInCurrentPath();
            }
            else if (e.KeyCode == Keys.F8)
            {
                this.Delete();
            }

        }
        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Shift && e.KeyCode == Keys.Up) || (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Down))
            {
                if (currentIdx != -1)
                {
                    if (selectedItems.ContainsKey(currentIdx) == false)
                    {
                        SelectItemWithIdx(currentIdx);
                    }
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            isTick = true;
            progressBar1.Visible = false;

            if (listView1.SelectedIndices.Count != 0)
            {
                if (selectedItems.ContainsKey(listView1.SelectedIndices[0]) == false)
                    SelectItemWithIdx(listView1.SelectedIndices[0]);
            }

            RightHoldEvent();
        }
        //Processbar timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 20;

            if (progressBar1.Value == 100)
            {
                timer2.Stop();
            }

        }

        private void RightHoldEvent()
        {
            List<Item> temp = new List<Item>();
            temp = selectedItems.Values.ToList();

            ShellContextMenu shellcontextmenu = new ShellContextMenu();

            List<DirectoryInfo> dir = new List<DirectoryInfo>();
            List<FileInfo> fi = new List<FileInfo>();


            List<Item> items = selectedItems.Values.ToList();
            try
            {
                if (items.Count == 0)
                {
                    if (GetCurrentSelectedItem() != null)
                    {
                        if (listView1.SelectedItems.GetType() == typeof(MyFile))
                        {
                            fi.Add(new FileInfo(GetCurrentSelectedItem().strParentPath + GetCurrentSelectedItem().StrName + GetCurrentSelectedItem().StrExt));
                        }
                        else
                        {
                            dir.Add(new DirectoryInfo((GetCurrentSelectedItem().strParentPath + (GetCurrentSelectedItem().StrName + "\\"))));
                        }
                    }
                    else
                    {
                        ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;
                        DirectoryInfo[] temp1 = new DirectoryInfo[1];
                        temp1[0] = new DirectoryInfo(ParentForm.StrCurrentPath);
                        shellcontextmenu.ShowContextMenu(temp1, MousePosition);
                    }

                }
                else
                {
                    foreach (Item i in items)
                    {
                        if (i.GetType() == typeof(MyFile))
                        {
                            fi.Add(new FileInfo(i.strParentPath + i.StrName + i.StrExt));
                        }
                        else
                        {
                            dir.Add(new DirectoryInfo(i.strParentPath + i.StrName + "\\"));
                        }
                    }
                }
                shellcontextmenu.ShowContextMenu(fi.ToArray(), dir.ToArray(), MousePosition);
            }
            catch { }
        }

        public void SelectAllItem()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (!selectedItems.ContainsKey(i))
                {
                    SelectItemWithIdx(i);
                }
            }
        }

        public void UnselectAllItem()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (selectedItems.ContainsKey(i))
                {
                    UnselectItemWithIdx(i);
                }
            }
        }
        internal void InvertSelection()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text == "[...]")
                {
                    continue;
                }

                if (selectedItems.Keys.Contains(i))
                {
                    UnselectItemWithIdx(i);
                }
                else
                {
                    SelectItemWithIdx(i);
                }

            }
        }

        internal void SelectAllWithSameExtension()
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (listView1.SelectedItems[0].Text == "[...]")
                    return;

                string selectedExt = "";

                if (listView1.Items[0].Text == "[...]")
                {
                    selectedExt = items[listView1.SelectedIndices[0] - 1].StrExt;
                }
                else
                {
                    selectedExt = items[listView1.SelectedIndices[0]].StrExt;
                }

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == selectedExt)
                        SelectItemWithIdx(i);
                }
            }
        }


        #endregion

        #region DragDropItems
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {

            if (e.Button == MouseButtons.Left) //Khi keo bang chuot trai
            {
                if (selectedItems.Count == 0)
                {
                    Item temp = GetCurrentSelectedItem();
                    if (temp != null) //Drag tu Item dang duoc Focus
                    {
                        List<Item> dragtemp = new List<Item>();
                        dragtemp.Add(temp);

                        Tuple<List<Item>, string> a = new Tuple<List<Item>, string>(dragtemp, Parent.Parent.Parent.Name.ToString());

                        listView1.DoDragDrop(a, DragDropEffects.Move);
                    }
                    else
                    {
                        //Ko lam gi
                    }
                }


                else //Drag tu selectedList
                {
                    Tuple<List<Item>, string> a = new Tuple<List<Item>, string>(selectedItems.Values.ToList(), Parent.Parent.Parent.Name.ToString());

                    listView1.DoDragDrop(a, DragDropEffects.Move);

                }
            }
            else // Cancle RightClickEvent 
            {
                timer1.Stop();
                timer2.Stop();
                progressBar1.Visible = false;

            }
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Tuple<List<Item>, string>)))
            {
                Tuple<List<Item>, string> temp = (Tuple<List<Item>, string>)e.Data.GetData(typeof(Tuple<List<Item>, string>));

                if (temp.Item2 != Parent.Parent.Parent.Name.ToString()) //Kiem tra xem co dang drag tren cung 1 ListView khong
                    e.Effect = DragDropEffects.Move;

            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Tuple<List<Item>, string>)))
            {
                Tuple<List<Item>, string> temp = (Tuple<List<Item>, string>)e.Data.GetData(typeof(Tuple<List<Item>, string>));

                ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;

                frmCopy cpy = new frmCopy(temp.Item1, ParentForm.StrCurrentPath);
                cpy.ShowDialog();

            }
        }




        #endregion

        private void listView1_Resize(object sender, EventArgs e)
        {

            listView1.Columns[0].Width = this.Width - 335;
            listView1.Columns[1].Width = 60;
            listView1.Columns[2].Width = 90;
            listView1.Columns[3].Width = 125;
            listView1.Columns[4].Width = 60;
        }

        internal void ViewMode(ViewStyle a)
        {
            if (a == ViewStyle.Details)
            {
                listView1.View = View.Details;
            }
            else
            {
                listView1.View = View.List;
            }
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            //this.ReloadItems();
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            ItemsTree itemsTree = (ItemsTree)ParentForm.Controls.Find("itemsTree1", true).GetValue(0);
            itemsTree.Renamed(e.OldFullPath, e.FullPath, e.OldName, e.Name);

            //if (((UserControl1)this.Parent.Parent.Parent).StrCurrentPath != "")
            //{
            //    if (new DirectoryInfo(((UserControl1)this.Parent.Parent.Parent).StrCurrentPath).Exists == true)
            //        this.ReloadItems();
            //    else
            //        this.LoadDirectory(((UserControl1)this.Parent.Parent.Parent).StrCurrentPath.Substring(0, 3));
            //}

            this.ReloadItems();
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {

            ItemsTree itemsTree = (ItemsTree)ParentForm.Controls.Find("itemsTree1", true).GetValue(0);
            itemsTree.Remove(e.FullPath);

            this.ReloadItems();
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {

            try
            {
                if (File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Directory))
                {
                    ItemsTree itemsTree = (ItemsTree)Parent.Parent.Parent.Controls[0].Controls[0].Controls.Find("itemsTree1", true).GetValue(0);
                    itemsTree.CreatedNode(e.FullPath);
                }
                this.ReloadItems();
            }
            catch
            {

            }
        }

      

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
