using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

namespace Game
{
    public class CSVHelper
    {
        private List<string> m_lstField = new List<string>();       //字段名
        public List<string> lstField { get { return m_lstField; } }
        private List<string> m_lstNote = new List<string>();        //注释
        private List<string[]> m_lstData = new List<string[]>();    //数据

        public void LoadCsv(string strText)
        {
            string[] szStr = strText.Split('\n');
            //第一行字段名，第二行中文注释
            if (szStr.Length < 2)
            {
                Debug.LogError("CSVHelper.LoadCsv error: low length");
                return;
            }

            m_lstField.Clear();
            string str = szStr[0].Trim();
            string[] szData = str.Split(',');
            m_lstField.AddRange(szData);
            m_lstField.RemoveAt(0); //去掉第一列备注列

            m_lstNote.Clear();
            str = szStr[1].Trim();
            szData = str.Split(',');
            m_lstNote.AddRange(szData);
            m_lstNote.RemoveAt(0);

            m_lstData.Clear();
            for (int i = 2; i < szStr.Length; ++i)
            {
                str = szStr[i].Trim();
                if (str.Length == 0)
                {
                    continue;
                }
                szData = str.Split(',');

                string[] szTemp = new string[szData.Length - 1];
                for (int j = 0; j < szTemp.Length; ++j)
                {
                    szTemp[j] = szData[j + 1];
                }
                m_lstData.Add(szTemp);
            }
        }

        public int GetCount()
        {
            return m_lstData.Count;
        }

        public int GetColumn()
        {
            return m_lstField.Count;
        }

        public T GetData<T>(int indexLine, int indexData)
        {
            string[] szData = m_lstData[indexLine];
            string strData = szData[indexData];
            object objData = Convert.ChangeType(strData, typeof(T));
            return (T)objData;
        }

        public void AppendData(string[] szData)
        {
            m_lstData.Add(szData);
        }

        public void SaveCsv(string strPath)
        {
            if (string.IsNullOrEmpty(strPath))
            {
                Debug.Log("CSVHelper.SaveCsv error, path == null.");
                return;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m_lstField.Count; ++i)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }
                sb.Append(m_lstField[i]);
            }
            sb.AppendLine();

            for (int i = 0; i < m_lstNote.Count; ++i)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }
                sb.Append(m_lstNote[i]);
            }
            sb.AppendLine();

            for (int i = 0; i < m_lstData.Count; ++i)
            {
                string[] szStr = m_lstData[i];
                for (int j = 0; j < szStr.Length; ++j)
                {
                    if (j != 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(szStr[j]);
                }
                sb.AppendLine();
            }
            File.WriteAllText(strPath, sb.ToString());
        }
    }
}
