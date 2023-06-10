using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class StringConfig
    {
        private Dictionary<int, string> m_dicString = new Dictionary<int, string>();

        public void Load(int nFileIndex, string strText)
        {
            CSVHelper csvHelper = new CSVHelper();
            csvHelper.LoadCsv(strText);
            int nCount = csvHelper.GetCount();
            int nColumn = csvHelper.GetColumn();
            for (int i = 0; i < nCount; ++i)
            {
                int id = csvHelper.GetData<int>(i, 0);
                for (int j = 1; j < nColumn; ++j)
                {
                    string str = csvHelper.GetData<string>(i, j);
                    int nIndex = 1000000 * nFileIndex + 10000 * j + id;
                    m_dicString.Add(nIndex, str);
                }
            }
        }

        public string GetString(int nIndex)
        {
            if (m_dicString.ContainsKey(nIndex))
            {
                return m_dicString[nIndex];
            }
            return "";
        }

        public string FormatString(int nIndex, params object[] objs)
        {
            string strFormat = this.GetString(nIndex);
            if (strFormat.Length > 0)
            {
                return string.Format(strFormat, objs);
            }
            return "";
        }
    }
}
