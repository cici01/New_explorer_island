using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class SpriteInfo
    {
        public int idSprite = 0;
        public Sprite sprite = null;
    }

    [CreateAssetMenu(fileName = "SpriteConfig", menuName = "AssetConfig/Sprite", order = 1)]
    public class SpriteConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public SpriteInfo[] m_szSpriteInfo = null;
        private Dictionary<int, SpriteInfo> m_dicSpriteInfo = new Dictionary<int, SpriteInfo>();

        public void OnAfterDeserialize()
        {
            m_dicSpriteInfo.Clear();
            if (m_szSpriteInfo != null)
            {
                foreach (SpriteInfo spriteInfo in m_szSpriteInfo)
                {
                    if (!m_dicSpriteInfo.ContainsKey(spriteInfo.idSprite))
                    {
                        m_dicSpriteInfo.Add(spriteInfo.idSprite, spriteInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public SpriteInfo GetSpriteInfo(int idSprite)
        {
            if (m_dicSpriteInfo.ContainsKey(idSprite))
            {
                return m_dicSpriteInfo[idSprite];
            }
            return null;
        }
    }
}
