using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class PMInfo
    {
        public string strFunc = null;
        public string strCode = null;
    }

    [CreateAssetMenu(fileName = "PMConfig", menuName = "AssetConfig/PM", order = 1)]
    public class PMConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public PMInfo[] m_szPMInfo = null;

        private List<PMInfo> m_lstPMInfo = new List<PMInfo>();
        public List<PMInfo> lstPMInfo { get { return m_lstPMInfo; } }

        public void OnAfterDeserialize()
        {
            m_lstPMInfo.Clear();
            if (m_szPMInfo != null)
            {
                foreach (PMInfo pmInfo in m_szPMInfo)
                {
                    m_lstPMInfo.Add(pmInfo);
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }
    }
}
