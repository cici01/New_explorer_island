using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class SpriteManager
    {
        private static SpriteManager s_instance = null;

        public static SpriteManager Instance()
        {
            if (s_instance == null)
            {
                s_instance = new SpriteManager();
            }
            return s_instance;
        }

        public Sprite GetSprite(int idSprite)
        {
            SpriteInfo spriteInfo = ConfigManager.Instance().GetConfig<SpriteConfig>().GetSpriteInfo(idSprite);
            if (spriteInfo == null)
            {
                return null;
            }
            return spriteInfo.sprite;
        }
    }
}
