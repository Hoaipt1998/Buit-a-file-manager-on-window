using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo4
{
    public class Folder : Item
    {


        public Folder(DirectoryInfo folder, string strPath)
        {
            strParentPath = strPath;
            strName = folder.Name.ToString();
            strExt = "";
            strSize = "<DIR>";
            strAttr = ConvertFileAttributesToString(folder.Attributes);
            strDate = folder.LastWriteTime.ToString();
        }
        public override string OnClick(ListView lv, Action<string> LoadDirectory)
        {

            LoadDirectory(strParentPath + strName + "\\");

            return strParentPath + strName + "\\";
        }

        public static string GetParentDirectory(string dir)
        {
            if (dir == "")
                return "";

            DirectoryInfo temp = new DirectoryInfo(dir);
            if (temp.Parent != null)
            {

                if ((temp.Parent.FullName.ToString() + @"\").Substring(2, 2) == "\\\\")
                {
                    return temp.Parent.FullName.ToString();
                }
                else
                    return temp.Parent.FullName.ToString() + @"\";
            }
            else
                return null;
        }
        public override string getIcon(ImageList img)
        {
            return "Folder";
        }
        public static DirectoryInfo GetDirectoryInfo(string dir)
        {
            return new DirectoryInfo(dir);
        }

        public override void EditWithNotepad()
        {
            MessageBox.Show("No file selected");
        }

        public override void Delete()
        {

            try
            {
                Directory.Delete(strParentPath + strName + "\\", true);
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show(e.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}