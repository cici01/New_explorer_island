using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class LanguageInfo
    {
        public string strAbbr = null;   //缩写
        public string[] szFileName = null;
    }

    [CreateAssetMenu(fileName = "LanguageConfig", menuName = "AssetConfig/Language", order = 1)]
    public class LanguageConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public LanguageInfo[] m_szLanguageInfo = null;
        private Dictionary<string, LanguageInfo> m_dicLanguageInfo = new Dictionary<string, LanguageInfo>();

        public void OnAfterDeserialize()
        {
            m_dicLanguageInfo.Clear();
            if (m_szLanguageInfo != null)
            {
                foreach (LanguageInfo languageInfo in m_szLanguageInfo)
                {
                    if (string.IsNullOrEmpty(languageInfo.strAbbr))
                    {
                        continue;
                    }

                    if (!m_dicLanguageInfo.ContainsKey(languageInfo.strAbbr))
                    {
                        m_dicLanguageInfo.Add(languageInfo.strAbbr, languageInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public LanguageInfo GetLanguageInfo(string strAbbr)
        {
            if (m_dicLanguageInfo.ContainsKey(strAbbr))
            {
                return m_dicLanguageInfo[strAbbr];
            }
            return null;
        }
    }
}
