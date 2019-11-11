
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public partial class frmCopy : Form
    {
        List<Item> sourceItems = new List<Item>();
        string targetDirectory = "";

        List<Item> selectedItems = new List<Item>();

        CopyType copyType;

        public frmCopy()
        {
            InitializeComponent();

        }

        public frmCopy(List<Item> items, string path = "", CopyType copyType = CopyType.Copy)
        {
            InitializeComponent();
            checkedListBox1.Items.Clear();

            this.copyType = copyType;

            if (items.Count == 0)
            {
                MessageBox.Show("No file selected");
                Close();
            }

            sourceItems = items;
            targetDirectory = path;

            textBox1.Text = targetDirectory;
            AddItemsToList();

            LanguageChange();
        }

        private void LanguageChange()
        {
            if (copyType == CopyType.Copy)
            {
                Text = MultiLanguage.GetText("Copy_text");
                lblItems.Text = MultiLanguage.GetText("Items_text");
                lblTo.Text = MultiLanguage.GetText("copy_to_text");

                btnOK.Text = MultiLanguage.GetText("OK_text");
                btnCancel.Text = MultiLanguage.GetText("Cancel_text");
            }
            else

            {
                Text = MultiLanguage.GetText("move_text");
                lblItems.Text = MultiLanguage.GetText("Items_text");
                lblTo.Text = MultiLanguage.GetText("move_to_text");

                btnOK.Text = MultiLanguage.GetText("OK_text");
                btnCancel.Text = MultiLanguage.GetText("Cancel_text");
            }

        }

        public frmCopy(Item item, string path = "", CopyType copyType = CopyType.Copy)
        {
            InitializeComponent();
            checkedListBox1.Items.Clear();

            this.copyType = copyType;

            sourceItems.Add(item);
            targetDirectory = path;

            textBox1.Text = targetDirectory;
            AddItemsToList();

            LanguageChange();
        }
        private void AddItemsToList()
        {
            foreach (Item item in sourceItems)
            {
                checkedListBox1.Items.Add(item.strParentPath + item.StrName + item.StrExt);
                checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, true);
            }
            checkedListBox1.Sorted = true;
        }
        private void Copy()
        {

        }

        private void btnChangeTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog temp = new FolderBrowserDialog();
            temp.ShowDialog();
            targetDirectory = temp.SelectedPath;

            if (targetDirectory.Substring(targetDirectory.Length - 1, 1) != "\\")
                targetDirectory += "\\";

            textBox1.Text = targetDirectory;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (targetDirectory == "")
            {
                MessageBox.Show("No path selected!");
                return;
            }

            selectedItems.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                    selectedItems.Add(sourceItems[i]);
            }

            if (selectedItems.Count == 0)
                MessageBox.Show("No items selected!");
            else
            {
                CopyProcess cp = new CopyProcess(selectedItems, textBox1.Text, copyType);
                cp.Show();
            }
            Close();
        }
    }
}
