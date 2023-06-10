using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEditor;

namespace GameEditor
{
    public class LanguageMaker
    {
        [MenuItem("CommonTools/生成字符串管理器cs代码")]
        private static void MakeLanguage()
        {
            string strPath = Application.dataPath + "/../../Code/Game/Scripts/Config/LanguageHelper.cs";
            if (!File.Exists(strPath))
            {
                Debug.Log("CommonTools.MakeLanguage error, path is not exist, path = " + strPath);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("//自动生成此脚本\r\n");
            sb.Append("using UnityEngine;\r\n\r\n");
            sb.Append("namespace Game\r\n");
            sb.Append("{\r\n");
            sb.Append("\tpublic static class LanguageHelper\r\n");
            sb.Append("\t{");
            LoadString(sb);
            sb.Append("\t}\r\n");
            sb.Append("}\r\n");

            using (FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.SetLength(0);
                Encoding utf8nobom = new UTF8Encoding(false);
                using (StreamWriter sw = new StreamWriter(fs, utf8nobom))
                {
                    sw.Write(sb.ToString());
                    sw.Close();
                    sw.Dispose();
                }
                fs.Close();
                fs.Dispose();
                Debug.Log("Write file success >>>>" + strPath);
            }
        }

        private static void LoadString(StringBuilder sb)
        {
            CSVHelper csvHelper = new CSVHelper();
            string strFilePath = FileUtility.GetStreamingAssetsPath(@"/Config/CSV/language/");
            DirectoryInfo directoryInfo = new DirectoryInfo(strFilePath);
            FileInfo[] szFileInfo = directoryInfo.GetFiles("*.csv", SearchOption.AllDirectories);
            for (int i = 0; i < szFileInfo.Length; ++i)
            {
                string strName = szFileInfo[i].Name;
                string strText = File.ReadAllText(strFilePath + strName);
                csvHelper.LoadCsv(strText);
                List<string> lstField = csvHelper.lstField;
                if (lstField.Count < 2)
                {
                    continue;
                }

                string[] szName = strName.Split('$');
                int nFileIndex = Convert.ToInt32(szName[0]);
                string strShortName = szName[1];
                strShortName = strShortName.Substring(0, strShortName.Length - 4);  //去掉“.csv”

                for (int j = 1; j < lstField.Count; ++j)
                {
                    sb.Append("\r\n");
                    sb.Append("\t\tpublic static string get_" + strShortName + "_" + lstField[j] + "(int nIndex)\r\n");
                    sb.Append("\t\t{\r\n");
                    sb.Append("\t\t\tint idStr = " + (1000000 * nFileIndex + 10000 * j) + " + nIndex;\r\n");
                    sb.Append("\t\t\treturn ConfigManager.Instance().str.GetString(idStr);\r\n");
                    sb.Append("\t\t}\r\n");
                }
            }
        }
    }
}
