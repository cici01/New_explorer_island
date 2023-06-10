using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class HeroInfo
    {
        public int idHero = 0;
        public Sprite spTile = null;
    }

    [CreateAssetMenu(fileName = "HeroConfig", menuName = "AssetConfig/Hero", order = 1)]
    public class HeroConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public HeroInfo[] m_szHeroInfo = null;
        private Dictionary<int, HeroInfo> m_dicHeroInfo = new Dictionary<int, HeroInfo>();

        public void OnAfterDeserialize()
        {
            m_dicHeroInfo.Clear();
            if (m_szHeroInfo != null)
            {
                foreach (HeroInfo heroInfo in m_szHeroInfo)
                {
                    if (!m_dicHeroInfo.ContainsKey(heroInfo.idHero))
                    {
                        m_dicHeroInfo.Add(heroInfo.idHero, heroInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public HeroInfo GetHeroInfo(int idHero)
        {
            if (m_dicHeroInfo.ContainsKey(idHero))
            {
                return m_dicHeroInfo[idHero];
            }
            return null;
        }
    }
}
