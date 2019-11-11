using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo4
{
    public class HistoryList
    {
        private List<string> listBack = new List<string>();
        private List<string> listFoward = new List<string>();
        private bool CancelAdd = false;
        private bool CancelFwClr = false;

        public HistoryList()
        {
            listBack.Clear();
            listFoward.Clear();
        }
        public void Clear()
        {
            listBack.Clear();
            listFoward.Clear();
        }
        public void CancelNextAdd()
        {
            CancelAdd = true;
        }
        public void CancelFowardClear()
        {
            CancelFwClr = true;
        }
        public void InsertDirectoryToListBack(string Path)
        {
            AddListBack(Path);
            if (CancelFwClr == true)
                CancelFwClr = false;
            else
                listFoward.Clear();
        }

        public void AddListBack(string Path)
        {
            if (CancelAdd == true)
            {
                CancelAdd = false;
            }
            else
                listBack.Add(Path);

        }
        public void AddListFoward(string Path)
        {
            listFoward.Add(Path);
        }
        public int CountBack()
        {
            return listBack.Count;
        }
        public int CountFoward()
        {
            return listFoward.Count;
        }
        public string Back(ItemsViewer us)
        {
            if (listBack.Count != 0)
            {
                string res = listBack[listBack.Count() - 1];
                listFoward.Add(us.StrCurrentPath);
                listBack.RemoveAt(listBack.Count() - 1);
                return res;
            }
            return null;
        }
        public string Next(ItemsViewer us)
        {
            if (listFoward.Count != 0)
            {
                string res = listFoward[listFoward.Count() - 1];
                listBack.Add(us.StrCurrentPath);
                listFoward.RemoveAt(listFoward.Count() - 1);
                return res;
            }
            return null;
        }
    }
}