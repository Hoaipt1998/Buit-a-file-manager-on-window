using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    class MultiLanguage
    {




        public static Dictionary<string, Dictionary<string, string>> Languages;
        public static string selectedLanguage;

        public MultiLanguage()
        {

        }

        public static  void init()
        {
            selectedLanguage = "English";
            Languages = new Dictionary<string, Dictionary<string, string>>();

            //Lay ngon ngu mac dinh


            Dictionary<string, string> dictLanguageEnglish = new Dictionary<string, string>();
            foreach (DictionaryEntry i in new ResourceManager("Demo4.Resources.Language", typeof(frmMain).Assembly).GetResourceSet(CultureInfo.CreateSpecificCulture("en"), true, true))
            {

                dictLanguageEnglish.Add(i.Key.ToString(), i.Value.ToString());

            }
            Languages.Add("English", dictLanguageEnglish);



            Dictionary<string, string> dictLanguageVietnamese = new Dictionary<string, string>();

            foreach (DictionaryEntry i in new ResourceManager("Demo4.Resources.Language", typeof(frmMain).Assembly).GetResourceSet(CultureInfo.CreateSpecificCulture("vi"), true, true))
            {

                dictLanguageVietnamese.Add(i.Key.ToString(), i.Value.ToString());

            }
            Languages.Add("Tiếng Việt", dictLanguageVietnamese);


            //Lay tat ca ngon ngu trong folder Language
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Language\\";
            path = path.Substring(6);

            // MessageBox.Show(path)                ;
            foreach (FileInfo file in new DirectoryInfo(path).GetFiles())
            {
                if (file.Extension == ".lang")
                {
                    Dictionary<string, string> dictLanguage = new Dictionary<string, string>();

                    string[] lines = File.ReadAllLines(file.FullName);
                    foreach (var line in lines)
                    {
                        dictLanguage.Add(line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)[0], line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)[1]);

                    }

                    Languages.Add(Path.GetFileNameWithoutExtension(file.FullName), dictLanguage);
                }
            }



        }

        internal static List<string> GetAllLanguage()
        {
            return Languages.Keys.ToList();
        }

        public static string GetText(string strKey)
        {
            // return MultiLanguage.res_man.GetString(strKey, MultiLanguage.cul);

            if (Languages[selectedLanguage].ContainsKey(strKey) == true)
                return Languages[selectedLanguage][strKey];
            else
                return strKey;
        }


    }
}
