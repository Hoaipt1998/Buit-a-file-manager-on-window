
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
    public partial class RenameTool : Form
    {
        List<Item> Items;
        public RenameTool()
        {
            InitializeComponent();

        }

        public RenameTool(List<Item> selectedFile)
        {
            InitializeComponent();

            btnUndo.Enabled = false;

            Items = selectedFile;
            foreach (Item i in Items)
            {
                if (i.GetType() == typeof(FileInfo)) 
                listView1.Items.Add(Path.GetFileNameWithoutExtension(i.StrName) + i.StrExt);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(Path.GetFileNameWithoutExtension(i.StrName) + i.StrExt);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(i.StrSize);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(i.StrDate);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(i.strParentPath);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string newName = txtName.Text;
                newName = newName.Replace("[N]", Items[i].StrName);
                newName = newName.Replace("[YMD]", DateTime.Parse(Items[i].StrDate).ToShortDateString());
                newName = newName.Replace("[hms]", DateTime.Parse(Items[i].StrDate).ToShortTimeString());

                newName += textBox1.Text;
                newName = newName.Replace("[Ext]", Items[i].StrExt);
                newName = newName.Replace("[C]", i.ToString());

                listView1.Items[i].SubItems[1].Text = newName;
            }
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            txtName.Text += "[N]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Text += "[YMD]";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Text += "[hms]";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtName.Text += "[C]";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "[Ext]";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "[C]";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {

                    if (Items[i].GetType() == typeof(MyFile))
                    {
                        if (new FileInfo(Items[i].strParentPath + Items[i].StrName + Items[i].StrExt).Exists == false)
                        {
                            MessageBox.Show("Tap tin " + Items[i].strParentPath + Items[i].StrName + Items[i].StrExt + " khong ton tai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            continue;
                        }

                        if (new FileInfo(Items[i].strParentPath + listView1.Items[i].SubItems[1].Text).Exists == true)
                        {
                            MessageBox.Show("Tap tin " + Items[i].strParentPath + listView1.Items[i].SubItems[1].Text + " da ton tai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            continue;
                        }

                        new FileInfo(Items[i].strParentPath + Items[i].StrName + Items[i].StrExt).MoveTo(Items[i].strParentPath + listView1.Items[i].SubItems[1].Text);
                    }
                    else
                    {
                        if (new DirectoryInfo(Items[i].strParentPath + Items[i].StrName + Items[i].StrExt).Exists == false)
                        {
                            MessageBox.Show("Thu muc " + Items[i].strParentPath + Items[i].StrName + Items[i].StrExt + " khong ton tai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            continue;
                        }

                        if (new FileInfo(Items[i].strParentPath + listView1.Items[i].SubItems[1].Text).Exists == true)
                        {
                            MessageBox.Show("Thu muc " + Items[i].strParentPath + listView1.Items[i].SubItems[1].Text + " da ton tai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            continue;
                        }

                        new DirectoryInfo(Items[i].strParentPath + Items[i].StrName + Items[i].StrExt).MoveTo(Items[i].strParentPath + listView1.Items[i].SubItems[1].Text);

                    }

                }
                MessageBox.Show("Doi ten thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUndo.Enabled = true;
                btnStart.Enabled = false;
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {

                    if (Items[i].GetType() == typeof(MyFile))
                    {
                        new FileInfo(Items[i].strParentPath + listView1.Items[i].SubItems[1].Text).MoveTo(Items[i].strParentPath + Items[i].StrName + Items[i].StrExt);

                    }
                    else
                    {
                        new DirectoryInfo(Items[i].strParentPath + listView1.Items[i].SubItems[1].Text).MoveTo(Items[i].strParentPath + Items[i].StrName + Items[i].StrExt);

                    }

                }
                MessageBox.Show("Tro lai thanh cong", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUndo.Enabled = false;
                btnStart.Enabled = true;
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void RenameTool_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
