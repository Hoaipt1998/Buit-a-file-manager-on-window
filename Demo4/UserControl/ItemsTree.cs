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

namespace Demo4
{
    public partial class ItemsTree : UserControl
    {
        private Dictionary<string, TreeNode> dict = new Dictionary<string, TreeNode>();

        public ItemsTree()
        {
            InitializeComponent();

            init();
        }

        private void init()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                try
                {

                    PopulateTreeView(drive.Name.ToString(), treeView1, drive.DriveType);
                }
                catch
                {

                }
            }
        }

        public void PopulateTreeView(string strPath, TreeView treeView, DriveType drivetype)
        {
            string[] strFolders = System.IO.Directory.GetDirectories(strPath);

            //treeView1.Nodes.Clear();
            TreeNode root = treeView1.Nodes.Add(strPath);

            if (drivetype != DriveType.Removable)
            {

                if (imageList1.Images.ContainsKey(strPath.Substring(0, 1)))
                {
                    root.ImageKey = strPath.Substring(0, 1);
                    root.SelectedImageKey = strPath.Substring(0, 1);
                }
                else
                {
                    root.ImageIndex = 1;
                    root.SelectedImageIndex = 1;
                }
            }
            else
            {

                root.ImageIndex = 2;
                root.SelectedImageIndex = 2;

            }

            dict.Add(strPath, root);

            root.Tag = strPath;
            for (int i = 0; i < strFolders.Length; i++)
            {
                DirectoryInfo folder = new DirectoryInfo(strFolders[i]);
                if (folder.Attributes == (FileAttributes.System | FileAttributes.Hidden | FileAttributes.Directory) || folder.Attributes == (FileAttributes.Hidden | FileAttributes.Directory) || folder.Attributes == (System.IO.FileAttributes.Hidden | System.IO.FileAttributes.System | System.IO.FileAttributes.Directory | System.IO.FileAttributes.ReparsePoint | System.IO.FileAttributes.NotContentIndexed))
                    continue;

                AddFolderToTreeView(root, strFolders[i]);

            }
        }

        private void AddFolderToTreeView(TreeNode parent, string strFullPathFolder)
        {
            string strFolder = System.IO.Path.GetFileName(strFullPathFolder);
            TreeNode node = parent.Nodes.Add(strFolder);
            node.Tag = strFullPathFolder + "\\";
            dict.Add((string)node.Tag, node);

            try
            {
                string[] temp = System.IO.Directory.GetDirectories(strFullPathFolder);
                if (temp.Length > 0)
                    node.Nodes.Add("dummynode", "dummynode");
            }
            catch (Exception)
            {

            }

        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (NeedToPopulateChildren(node))
            {
                node.Nodes.Clear(); // clead dummy

                string[] strFolders = System.IO.Directory.GetDirectories((string)node.Tag);

                for (int i = 0; i < strFolders.Length; i++)
                {
                    AddFolderToTreeView(node, strFolders[i]);

                }
            }

        }

        private bool NeedToPopulateChildren(TreeNode node)
        {
            if (node.Nodes.Count == 1)
                if (node.Nodes[0].Text == "dummynode")
                    return true;
            return false;
        }

        public void SelectNodeFormDirectory(string strFullPath)
        {
            try
            {
                if (dict.ContainsKey(strFullPath))
                {
                    TreeNode node = dict[strFullPath];
                    treeView1.SelectedNode = node;
                    node.Expand();
                    treeView1.Focus();
                }
                else
                {
                    ExpandToFullPath(strFullPath);

                }

            }
            catch
            {

            }
        }

        private void ExpandToFullPath(string strFullPath)
        {
            if (strFullPath == "")
                return;

            string[] SplitBy = { @"\" };
            string[] temp = strFullPath.Split(SplitBy, StringSplitOptions.None);
            string PathExpand = temp[0] + @"\" + temp[1] + "\\";
            for (int i = 2; i < temp.Length; i++)
            {
                SelectNodeFormDirectory(PathExpand);

                PathExpand += (temp[i] + "\\");
            }
        }



        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView tv = (TreeView)sender;

            ItemsViewer ParentForm = (ItemsViewer)this.Parent.Parent.Parent;
            ItemsList itemslist = (ItemsList)ParentForm.Controls.Find("itemsList1", true).GetValue(0);

            if (new DirectoryInfo(tv.SelectedNode.Tag.ToString()).Exists == false)
            {
                tv.SelectedNode.Remove();
                return;
            }

            itemslist.LoadDirectory(tv.SelectedNode.Tag.ToString());
        }



        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    try
                    {
                        DirectoryInfo[] temp1 = new DirectoryInfo[1];
                        temp1[0] = new DirectoryInfo(e.Node.Tag.ToString());
                        ShellContextMenu a = new ShellContextMenu();
                        a.ShowContextMenu(temp1, MousePosition);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {


        }

        internal void Renamed(string oldFullPath, string newFullPath, string oldName, string newName)
        {
            //while(dict.Keys.Contains(oldFullPath))
            //{
            //    dict.Keys.ToList
            //}
            foreach (string key in dict.Keys.ToList())
            {
                if (key.Contains(oldFullPath))
                {
                    //Node goc
                    if (key == (oldFullPath + "\\"))
                    {
                        TreeNode node;
                        if (newName.Split(new string[] { "\\" }, StringSplitOptions.None).Length == 1)
                            node = dict[key].Parent.Nodes.Add(newName.Split(new string[] { "\\" }, StringSplitOptions.None)[0]);
                        else
                            node = dict[key].Parent.Nodes.Add(newName.Split(new string[] { "\\" }, StringSplitOptions.None)[1]);

                        node.Tag = newFullPath + "\\";

                        if (dict[key].Nodes.Count > 0)
                            node.Nodes.Add("dummynode", "dummynode");

                        dict[key].Remove();
                        dict.Remove(key);
                        dict.Add(node.Tag.ToString(), node);
                    }
                    else
                    {
                        dict[key].Remove();
                        dict.Remove(key);
                    }

                }
            }
            //foreach ( KeyValuePair<string, TreeNode> replacement in dict)
            //{
            //    if(replacement.Key.Contains(oldFullPath))
            //    {
            //        //replacement.Value.Remove();

            //        // dict.Remove(replacement.Key.ToString());
            //        //dict[replacement.Key]

            //        //replacement.Value.Parent.Nodes.Add()
            //        //replacement.Value.Remove();

            //        TreeNode node = replacement.Value.Parent.Nodes.Add(newName);
            //        node.Tag = newFullPath + "\\";
            //        dict.Add((string)node.Tag, node);
            //        replacement.Value.Remove();

            //        //replacement.Key = replacement.Key.Replace(oldFullPath, newFullPath);
            //        //replacement.Value.Text = replacement.Value.Text.Replace(oldName, newName);
            //        //replacement.Value.Tag = ((string)replacement.Value.Tag).Replace(oldFullPath, newFullPath);


            //    }
            //}
        }

        public void AddDrive(string drive, DriveType drivetype)
        {
            PopulateTreeView(drive, treeView1, drivetype);
        }

        public void RemoveDrive(string drive)
        {
            if (dict.Keys.Contains(drive))
            {
                dict[drive].Remove();
                dict.Remove(drive);

                foreach (string key in dict.Keys.ToList())
                    if (key.Contains(drive))
                        dict.Remove(key);
            }
        }

        internal void Remove(string fullPath)
        {
            if (dict.ContainsKey(fullPath + "\\"))
            {
                dict[fullPath + "\\"].Remove();
                dict.Remove(fullPath + "\\");

                foreach (string key in dict.Keys.ToList())
                    if (key.Contains(fullPath + "\\"))
                        dict.Remove(key);
            }
        }

        internal void CreatedNode(string fullPath)
        {
            string strPath = new DirectoryInfo(fullPath).Parent.FullName;
            if (strPath.Substring(strPath.Length - 1, 1) != "\\")
                strPath += "\\";


            if (dict.ContainsKey(strPath))
            {
                if (dict[strPath].Nodes.Count == 1)
                {
                    if (dict[strPath].Nodes[0].Text == "dummynode")
                        return;
                    else
                    {
                        TreeNode temp = dict[strPath].Nodes.Add(new DirectoryInfo(fullPath).Name);
                        temp.Tag = fullPath + "\\";
                        dict.Add(fullPath + "\\", temp);
                    }
                }
                else
                {
                    TreeNode temp = dict[strPath].Nodes.Add(new DirectoryInfo(fullPath).Name);
                    temp.Tag = fullPath + "\\";
                    dict.Add(fullPath + "\\", temp);
                }
            }
        }
    }
}
