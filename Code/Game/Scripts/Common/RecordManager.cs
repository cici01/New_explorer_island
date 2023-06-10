using UnityEngine;
using System.Collections;

namespace Game
{
    public class RecordManager
    {
        private static RecordManager s_instance = null;
        private string m_strRecordKey = null;

        public int record
        {
            set
            {
                m_strRecordKey = "Record" + value + "_";
            }
        }

        public static RecordManager Instance()
        {
            if (s_instance == null)
            {
                s_instance = new RecordManager();
            }
            return s_instance;
        }

        public void SetInt(string strKey, int nValue)
        {
            string str = m_strRecordKey + strKey;
            PlayerPrefs.SetInt(str, nValue);

            str = m_strRecordKey + "SaveTime";
            System.DateTime dtNow = System.DateTime.Now;
            PlayerPrefs.SetString(str, dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public void SetString(string strKey, string strValue)
        {
            string str = m_strRecordKey + strKey;
            PlayerPrefs.SetString(str, strValue);

            str = m_strRecordKey + "SaveTime";
            System.DateTime dtNow = System.DateTime.Now;
            PlayerPrefs.SetString(str, dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public int GetInt(string strKey)
        {
            string str = m_strRecordKey + strKey;
            return PlayerPrefs.GetInt(str, 0);
        }

        public string GetString(string strKey)
        {
            string str = m_strRecordKey + strKey;
            return PlayerPrefs.GetString(str, "");
        }

        public void DeleteKey(string strKey)
        {
            string str = m_strRecordKey + strKey;
            PlayerPrefs.DeleteKey(str);
        }

        public void SetGlobalInt(string strKey, int nValue)
        {
            PlayerPrefs.SetInt(strKey, nValue);
        }

        public int GetGlobalInt(string strKey, int nDefaultValue)
        {
            return PlayerPrefs.GetInt(strKey, nDefaultValue);
        }
    }
}
