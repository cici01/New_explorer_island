using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Game
{
    public class ConfigManager : MonoBehaviour
    {
        public List<ScriptableObject> m_lstConfig = new List<ScriptableObject>();

        private static ConfigManager s_instance = null;

        //csv
        private StringConfig m_stringConfig = new StringConfig();
        public StringConfig str { get { return m_stringConfig; } }

        public static ConfigManager Instance()
        {
            return s_instance;
        }

        private void Awake()
        {
            s_instance = this;
        }

        public void Init()
        {
            StartCoroutine(LoadString());
        }

        private IEnumerator LoadString()
        {
            LanguageConfig languageConfig = this.GetConfig<LanguageConfig>();
            LanguageInfo languageInfo = languageConfig.GetLanguageInfo("cn");
            if (languageInfo == null)
            {
                yield break;
            }

            string strFilePath = FileUtility.GetStreamingAssetsPath(@"/Config/CSV/language/");
            for (int i = 0; i < languageInfo.szFileName.Length; ++i)
            {
                string strName = languageInfo.szFileName[i];
                string[] szName = strName.Split('$');
                int nFileIndex = Convert.ToInt32(szName[0]);
                UnityWebRequest request = UnityWebRequest.Get(strFilePath + strName);
                yield return request.SendWebRequest();
                StringReader stringReader = new StringReader(request.downloadHandler.text);
                stringReader.Read();    //skip BOM
                m_stringConfig.Load(nFileIndex, stringReader.ReadToEnd());
            }
        }

        public T GetConfig<T>() where T : ScriptableObject
        {
            foreach (ScriptableObject so in m_lstConfig)
            {
                if (so is T)
                {
                    return so as T;
                }
            }
            return null;
        }
    }
}
