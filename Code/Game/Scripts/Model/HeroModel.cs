using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class HeroData
    {
        public HeroInfo heroInfo = null;
    }

    public class HeroModel : IModel
    {
        private Dictionary<int, HeroData> m_dicHeroData = new Dictionary<int, HeroData>();

        public override void Init()
        {
            this.AddHero(1);
        }

        public void AddHero(int idHero)
        {
            if (m_dicHeroData.ContainsKey(idHero))
            {
                Debug.LogError("HeroModel.AddHero error, had hero, idHero = " + idHero);
                return;
            }

            HeroInfo heroInfo = ConfigManager.Instance().GetConfig<HeroConfig>().GetHeroInfo(idHero);
            if (heroInfo == null)
            {
                Debug.LogError("HeroModel.AddHero error, heroInfo == null, idHero = " + idHero);
                return;
            }

            HeroData heroData = new HeroData();
            heroData.heroInfo = heroInfo;
            m_dicHeroData.Add(idHero, heroData);
        }
    }
}
