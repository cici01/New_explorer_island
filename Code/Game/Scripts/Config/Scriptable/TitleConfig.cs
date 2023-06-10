using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class TitleInfo
    {
        public int idTitle = 0;
        public int idSpriteBg = 0;
    }

    [CreateAssetMenu(fileName = "TitleConfig", menuName = "AssetConfig/Title", order = 1)]
    public class TitleConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public TitleInfo[] m_szTitleInfo = null;
        private Dictionary<int, TitleInfo> m_dicTitleInfo = new Dictionary<int, TitleInfo>();

        public void OnAfterDeserialize()
        {
            m_dicTitleInfo.Clear();
            if (m_szTitleInfo != null)
            {
                foreach (TitleInfo titleInfo in m_szTitleInfo)
                {
                    if (!m_dicTitleInfo.ContainsKey(titleInfo.idTitle))
                    {
                        m_dicTitleInfo.Add(titleInfo.idTitle, titleInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public TitleInfo GetTitleInfo(int idTitle)
        {
            if (m_dicTitleInfo.ContainsKey(idTitle))
            {
                return m_dicTitleInfo[idTitle];
            }
            return null;
        }
    }
}
