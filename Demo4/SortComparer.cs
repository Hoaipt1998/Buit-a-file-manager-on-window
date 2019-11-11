using Demo4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demo4
{



    public enum SortBy
    {
        NameASC,
        NameDESC,
        ExtASC,
        ExtDESC,
        SizeASC,
        SizeDESC,
        DateASC,
        DateDESC
    }


    class SortByNameASC : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return ((x.StrName.CompareTo(y.StrName)));

        }
    }
    class SortByNameDESC : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return ((y.StrName.CompareTo(x.StrName)));

        }
    }
    class SortByExtASC : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {

            return ((x.StrExt.CompareTo(y.StrExt)));

        }
    }
    class SortByExtDESC : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return ((y.StrExt.CompareTo(x.StrExt)));

        }
    }
    class SortBySizeASC : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.GetType() == typeof(Folder) || y.GetType() == typeof(Folder))
                return 0;

            Int64 temp1 = Int64.Parse(x.StrSize);
            Int64 temp2 = Int64.Parse(y.StrSize);
            return (temp1.CompareTo(temp2));

        }
    }
    class SortBySizeDESC : IComparer<Item>
    {

        public int Compare(Item x, Item y)
        {
            if (x.GetType() == typeof(Folder) || y.GetType() == typeof(Folder))
                return 0;

            Int64 temp1 = Int64.Parse(x.StrSize);
            Int64 temp2 = Int64.Parse(y.StrSize);
            return (temp2.CompareTo(temp1));

        }
    }
    class SortByDateASC : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {

            DateTime temp1 = Convert.ToDateTime(x.StrDate);
            DateTime temp2 = Convert.ToDateTime(y.StrDate);
            return (temp1.CompareTo(temp2));

        }
    }
    class SortByDateDESC : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            DateTime temp1 = Convert.ToDateTime(x.StrDate);
            DateTime temp2 = Convert.ToDateTime(y.StrDate);
            return (temp2.CompareTo(temp1));

        }
    }
}


