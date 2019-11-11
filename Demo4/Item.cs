using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public class Item
    {

        public string strParentPath;

        protected string strName;
        protected string strSize;
        protected string strDate;
        protected string strAttr;
        protected string strExt;

        public string StrName
        {
            get
            {
                return strName;
            }

            set
            {
                strName = value;
            }
        }
        public string StrSize
        {
            get
            {
                return strSize;
            }

            set
            {
                strSize = value;
            }
        }
        public string StrDate
        {
            get
            {
                return strDate;
            }

            set
            {
                strDate = value;
            }
        }
        public string StrAttr
        {
            get
            {
                return strAttr;
            }

            set
            {
                strAttr = value;
            }
        }
        public string StrExt
        {
            get
            {
                return strExt;
            }

            set
            {
                strExt = value;
            }
        }

        protected string ConvertFileAttributesToString(FileAttributes fileAttributes)
        {
            FileAttributes[] fa = new FileAttributes[4]
                        {
                            FileAttributes.Hidden,
                            FileAttributes.Archive,
                            FileAttributes.System,
                            FileAttributes.ReadOnly
                        };
            string[] symbol = new string[4] { "h", "a", "s", "r" };
            string res = "";

            for (int i = 0; i < 4; i++)
                if ((fileAttributes & fa[i]) == fa[i])
                    res += symbol[i];
                else
                    res += "-";


            return res;
        }

        public static List<Item> GetItemsFromPath(string strPath)
        {

            List<Item> res = new List<Item>();


            try
            {



                System.IO.DirectoryInfo i = new System.IO.DirectoryInfo(strPath);
                foreach (System.IO.DirectoryInfo folder in i.GetDirectories())
                {
                    if (folder.Attributes.HasFlag(FileAttributes.System) || folder.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;

                    Folder temp = new Folder(folder, strPath);

                    res.Add(temp);
                }

                foreach (System.IO.FileInfo file in i.GetFiles())
                {
                    MyFile temp = new MyFile(file, strPath);


                    res.Add(temp);
                }


            }
            catch
            {

            }

            return res;
        }

        public virtual string OnClick(ListView lv, Action<string> LoadDirectory)
        {
            return "";
        }
        public virtual string getIcon(ImageList img)
        {
            return "";
        }
        public static void SortListItems(List<Item> items, int SortType)
        {
            if (items.Count() != 0)
            {
                IComparer<Item> icomparer = null;
                switch (SortType)
                {
                    case (int)SortBy.NameASC: icomparer = new SortByNameASC(); break;
                    case (int)SortBy.NameDESC: icomparer = new SortByNameDESC(); break;
                    case (int)SortBy.ExtASC: icomparer = new SortByExtASC(); break;
                    case (int)SortBy.ExtDESC: icomparer = new SortByExtDESC(); break;
                    case (int)SortBy.SizeASC: icomparer = new SortBySizeASC(); break;
                    case (int)SortBy.SizeDESC: icomparer = new SortBySizeDESC(); break;
                    case (int)SortBy.DateASC: icomparer = new SortByDateASC(); break;
                    case (int)SortBy.DateDESC: icomparer = new SortByDateDESC(); break;

                }

                int numberFolder = CountFolderFormPath(items[0].strParentPath);

                items.Sort(0, numberFolder, icomparer);
                items.Sort(numberFolder, items.Count() - numberFolder, icomparer);
            }
        }
        public static int CountFolderFormPath(string Path)
        {
            int res = 0;
            DirectoryInfo i = new DirectoryInfo(Path);
            if (i.Exists == false)
                return -1;

            foreach (DirectoryInfo folder in i.GetDirectories())
            {
                if (folder.Attributes.HasFlag(FileAttributes.System) || folder.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                res++;
            }

            return res;


        }
        public static Item[] GetSortedItemsFromPath(string strPath, int SortType)
        {
            List<Item> res = GetItemsFromPath(strPath);

            SortListItems(res, SortType);

            return res.ToArray();
        }
        public virtual void EditWithNotepad()
        {

        }

        public virtual void Delete()
        {

        }


    }
}
