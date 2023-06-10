using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class UIInfo
    {
        public EM_UIType eType = EM_UIType.eUT_None;
        public EM_UILayer eLayer = EM_UILayer.eUL_LayerBottom;
        public GameObject pbWindow = null;
    }

    [CreateAssetMenu(fileName = "UIConfig", menuName = "AssetConfig/UI", order = 1)]
    public class UIConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public UIInfo[] m_szUIInfo = null;
        private Dictionary<EM_UIType, UIInfo> m_dicUIInfo = new Dictionary<EM_UIType, UIInfo>();

        public void OnAfterDeserialize()
        {
            m_dicUIInfo.Clear();
            if (m_szUIInfo != null)
            {
                foreach (UIInfo uiInfo in m_szUIInfo)
                {
                    if (!m_dicUIInfo.ContainsKey(uiInfo.eType))
                    {
                        m_dicUIInfo.Add(uiInfo.eType, uiInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public UIInfo GetUIInfo(EM_UIType eType)
        {
            if (m_dicUIInfo.ContainsKey(eType))
            {
                return m_dicUIInfo[eType];
            }
            return null;
        }
    }
}
