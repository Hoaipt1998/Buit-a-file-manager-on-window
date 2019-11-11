using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Demo4
{

    public class MyFile : Item
    {
        public MyFile(FileInfo file, string strPath)
        {
            strParentPath = strPath;
            strName = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
            strExt = file.Extension.ToString();
            strSize = file.Length.ToString();
            strAttr = ConvertFileAttributesToString(file.Attributes);
            strDate = file.LastWriteTime.ToString();
        }
        public override string OnClick(ListView lv, Action<string> LoadDirectory)
        {
            Process p = new Process();

            try
            {
                p.StartInfo.WorkingDirectory = strParentPath.ToString();
                p.StartInfo.FileName = strName + strExt;
                p.Start();
            }
            catch { }

            return this.strParentPath;
        }
        public override string getIcon(ImageList img)
        {
            FileInfo file = new FileInfo(strParentPath.ToString() + "\\" + strName + strExt);
            Icon iconForFile = SystemIcons.WinLogo;

            iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
            if (!img.Images.ContainsKey(file.Extension))
            {
                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                img.Images.Add(file.Extension, iconForFile);
            }
            return file.Extension;
        }

        public override void EditWithNotepad()
        {
            Process.Start("notepad.exe", strParentPath.ToString() + "/" + strName + strExt);
        }

        public override void Delete()
        {
            try
            {
                File.Delete(strParentPath.ToString() + strName + strExt);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}