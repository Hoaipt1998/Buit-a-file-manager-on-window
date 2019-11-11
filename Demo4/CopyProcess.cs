
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public enum CopyType
    {
        Copy,
        Move
    };

    public partial class CopyProcess : Form
    {
        CopyType copyType = CopyType.Copy;

        List<Item> srcItems = new List<Item>();
        string strdstPath = "";

        List<Item> itemstoCopy = new List<Item>();
        List<string> strCopyTo = new List<string>();
        int currentItemIdx = 0;

        int filesCount = 0;
        long filesSize = 0;
        long SizeCopyed = 0;

        WebClient wc = new WebClient();

        bool flagCancel = false;
        public CopyProcess()
        {
            InitializeComponent();


        }
        public CopyProcess(List<Item> items, string path, CopyType type)
        {

            InitializeComponent();
            srcItems = items;
            strdstPath = path;

            copyType = type;

            foreach (Item i in srcItems)
            {
                if (i.GetType() == typeof(MyFile))
                {
                    filesCount += 1;

                    filesSize += long.Parse(i.StrSize);
                    txtTotalSize.Text = getShortenSize(filesSize);

                    itemstoCopy.Add((MyFile)i);
                    strCopyTo.Add(strdstPath + i.StrName + i.StrExt);

                    ListViewItem temp = new ListViewItem(i.strParentPath + i.StrName + i.StrExt);
                    temp.SubItems.Add(strdstPath + i.StrName + i.StrExt);
                    temp.SubItems.Add((long.Parse(i.StrSize).ToString("n0")));
                    listView1.Items.Add(temp);
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(i.strParentPath + i.StrName + "\\");

                    itemstoCopy.Add((Folder)i);
                    strCopyTo.Add(strdstPath + i.StrName + "\\");

                    ListViewItem temp = new ListViewItem(i.strParentPath + i.StrName + i.StrExt);
                    temp.SubItems.Add(strdstPath + i.StrName + "\\");
                    temp.SubItems.Add("<DIR>");
                    listView1.Items.Add(temp);

                    TraversalTree(di, strdstPath + i.StrName + "\\");
                }
            }

            wc.DownloadProgressChanged += DownloadProgress;
            wc.DownloadFileCompleted += DownloadComplete;

            LanguageChanged();

            DoCopy();
        }

        private void LanguageChanged()
        {
            if (copyType == CopyType.Copy)
            {
                Text = MultiLanguage.GetText("Copy_text");
                txtOf.Text = MultiLanguage.GetText("text_of");
                columnHeader1.Text = MultiLanguage.GetText("source_item");
                columnHeader2.Text = MultiLanguage.GetText("copy_to_text");
                Size.Text = MultiLanguage.GetText("clmSize_text");
                columnHeader3.Text = MultiLanguage.GetText("status_text");
                btnCancel.Text = MultiLanguage.GetText("Cancel_text");
            }
            else
            {
                Text = MultiLanguage.GetText("move_text");
                txtOf.Text = MultiLanguage.GetText("text_of");
                columnHeader1.Text = MultiLanguage.GetText("source_item");
                columnHeader2.Text = MultiLanguage.GetText("copy_to_text");
                Size.Text = MultiLanguage.GetText("clmSize_text");
                columnHeader3.Text = MultiLanguage.GetText("status_text");
                btnCancel.Text = MultiLanguage.GetText("Cancel_text");
            }
        }

        private void TraversalTree(DirectoryInfo di, string CopyTo)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            if (di.Exists == false) //Kiem tra xem duong dan co ton tai khong 
                return;

            try
            {
                files = di.GetFiles();

            }
            catch
            {

            }

            if (files != null)
            {
                foreach (System.IO.FileInfo file in files)
                {
                    filesCount += 1;
                    filesSize += file.Length;
                    txtTotalSize.Text = getShortenSize(filesSize);


                    itemstoCopy.Add(new MyFile(file, file.DirectoryName + "\\"));
                    strCopyTo.Add(CopyTo + file.Name);

                    ListViewItem temp = new ListViewItem(file.FullName);
                    temp.SubItems.Add(CopyTo + file.Name);
                    temp.SubItems.Add(file.Length.ToString());

                    listView1.Items.Add(temp);

                }
            }


            subDirs = di.GetDirectories();

            foreach (System.IO.DirectoryInfo folder in subDirs)
            {
                itemstoCopy.Add(new Folder(folder, folder.FullName));
                strCopyTo.Add(CopyTo + folder.Name + "\\");

                ListViewItem temp = new ListViewItem(folder.FullName);
                temp.SubItems.Add(CopyTo + folder.Name + "\\");
                listView1.Items.Add(temp);
                temp.SubItems.Add("<DIR>");

                TraversalTree(folder, CopyTo + folder.Name + "\\");
            }
        }
        private void backgroundRetrieveItem_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Item i in srcItems)
            {
                if (i.GetType() == typeof(MyFile))
                {
                    filesCount += 1;

                    filesSize += long.Parse(i.StrSize);
                    txtTotalSize.Text = getShortenSize(filesSize);



                    itemstoCopy.Add((MyFile)i);
                    strCopyTo.Add(strdstPath + i.StrName + i.StrExt);

                    ListViewItem temp = new ListViewItem(i.strParentPath + i.StrName + i.StrExt);
                    temp.SubItems.Add(strdstPath + i.StrName + i.StrExt);
                    temp.SubItems.Add(i.StrSize);
                    listView1.Items.Add(temp);



                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(i.strParentPath + i.StrName + "\\");

                    itemstoCopy.Add((Folder)i);
                    strCopyTo.Add(strdstPath + i.StrName + "\\");

                    ListViewItem temp = new ListViewItem(i.strParentPath + i.StrName + i.StrExt);
                    temp.SubItems.Add(strdstPath + i.StrName + "\\");
                    temp.SubItems.Add("<DIR>");
                    listView1.Items.Add(temp);

                    TraversalTree(di, strdstPath + i.StrName + "\\");
                }
            }
        }
        private async void DoCopy()
        {

            for (int i = 0; i < itemstoCopy.Count; i++)
            {

                if (flagCancel == true)
                    break;

                if (itemstoCopy[i].GetType() == typeof(MyFile))
                {
                    FileInfo temp = new FileInfo(strCopyTo + itemstoCopy[i].StrName + itemstoCopy[i].StrExt);
                    if (temp.Exists == true)
                    {

                    }
                    else
                    {
                        /* Copy file */
                        //File.Copy(itemstoCopy[i].strParentPath + itemstoCopy[i].StrName + itemstoCopy[i].StrExt, strCopyTo[i]);                           

                        try
                        {
                            await wc.DownloadFileTaskAsync(new Uri(itemstoCopy[i].strParentPath + itemstoCopy[i].StrName + itemstoCopy[i].StrExt), strCopyTo[i]);
                        }
                        catch
                        {
                            //Neu cancel
                            while (currentItemIdx < listView1.Items.Count)
                            {
                                listView1.Items[currentItemIdx].SubItems.Add(MultiLanguage.GetText("cancel!"));
                            }
                        }
                    }
                }
                else
                {
                    DirectoryInfo temp = new DirectoryInfo(strCopyTo[i]);
                    if (temp.Exists == false)
                        Directory.CreateDirectory(strCopyTo[i]);

                    listView1.Items[currentItemIdx].SubItems.Add(MultiLanguage.GetText("done!"));
                    listView1.Items[currentItemIdx].Selected = true;
                    currentItemIdx++;
                }
            }



        }



        long TotalFileSize;

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {



            if (e.Cancelled != true)
            {
                if (itemstoCopy[currentItemIdx].StrSize == (0).ToString())
                {
                    if (currentItemIdx == itemstoCopy.Count - 1)
                    {
                        progressBar1.Value = 100;
                        txtProgress1.Text = "0 bytes of 0 bytes";

                        progressBar2.Value = 100;

                        listView1.Items[currentItemIdx].SubItems.Add(MultiLanguage.GetText("done!"));
                        listView1.Items[currentItemIdx].Selected = true;

                        if (copyType == CopyType.Move)
                        {
                            itemstoCopy[currentItemIdx].Delete();
                        }
                    }
                    else
                    {

                        listView1.Items[currentItemIdx].SubItems.Add(MultiLanguage.GetText("done!"));
                        listView1.Items[currentItemIdx].Selected = true;

                        if (copyType == CopyType.Move)
                        {
                            itemstoCopy[currentItemIdx].Delete();
                        }

                        currentItemIdx++;
                    }
                }
                else
                {
                    SizeCopyed += TotalFileSize;

                    progressBar2.Value = (int)((SizeCopyed / filesSize * 100));



                    listView1.Items[currentItemIdx].SubItems.Add(MultiLanguage.GetText("done!"));
                    listView1.Items[currentItemIdx].Selected = true;

                    if (copyType == CopyType.Move)
                    {
                        itemstoCopy[currentItemIdx].Delete();
                    }
                    currentItemIdx++;
                }


                txtTotalSizeFrom.Text = getShortenSize(SizeCopyed);
            }
            else
            {
                /*Xoa file chep nua chung */
                FileInfo temp = new FileInfo(strCopyTo[currentItemIdx]);
                if (temp.Exists == true)
                    temp.Delete();


                listView1.Items[currentItemIdx].SubItems.Add(MultiLanguage.GetText("cancel"));
                listView1.Items[currentItemIdx].Selected = true;
                currentItemIdx++;
            }

            if (itemstoCopy.Count == currentItemIdx)
                Close();
        }

        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            if (flagCancel == true)
            {
                WebClient temp = (WebClient)sender;
                temp.CancelAsync();
            }
            txtFile.Text = itemstoCopy[currentItemIdx].StrName;

            double TotalPercent = Math.Round((((SizeCopyed + e.BytesReceived * 1.0) / filesSize) * 100), 2);
            this.Text = MultiLanguage.GetText("Copy_text") + " " + TotalPercent + " % " + MultiLanguage.GetText("done");
            txtTotalProcess.Text = TotalPercent.ToString() + " %";

            TotalFileSize = (e.TotalBytesToReceive);

            progressBar1.Value = e.ProgressPercentage;
            txtProgress1.Text = getShortenSize(e.BytesReceived) + " " + MultiLanguage.GetText("text_of") + " " + getShortenSize(e.TotalBytesToReceive);


            progressBar2.Value = (int)Math.Round(Convert.ToDecimal(TotalPercent));
            txtTotalSizeFrom.Text = getShortenSize(SizeCopyed + e.BytesReceived);

            txtFileProgress.Text = e.ProgressPercentage.ToString() + " %";


        }

        private string getShortenSize(long bytes)
        {

            if (bytes > 1000000000)
            {
                string strSize = Math.Round((Convert.ToDouble(bytes) / 1000000000), 2).ToString("n0");
                return strSize + " Gbytes";
            }
            else
            {
                if (bytes > 1000000)
                {
                    string strSize = Math.Round((Convert.ToDouble(bytes) / 1000000), 2).ToString("n0");
                    return strSize + " Mbytes";
                }
                else
                {
                    if (bytes > 1000)
                    {
                        string strSize = Math.Round((Convert.ToDouble(bytes) / 1000), 2).ToString("n0");
                        return strSize + " Kbytes";
                    }
                    else
                    {
                        string strSize = Math.Round((Convert.ToDouble(bytes)), 2).ToString("n0");
                        return strSize + " bytes";
                    }

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (wc.IsBusy == true)
            {
                //wc.CancelAsync();
                flagCancel = true;
            }
            else
            {

            }


        }

    }
}
