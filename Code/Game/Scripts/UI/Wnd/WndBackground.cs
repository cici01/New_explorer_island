using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game
{
    public class WndBackground : UIBase
    {
        public Image m_imgBg = null;

        public override void Init(params object[] objs)
        {
            int idSpriteBg = (int)objs[0];
            SpriteInfo spriteInfo = ConfigManager.Instance().GetConfig<SpriteConfig>().GetSpriteInfo(idSpriteBg);
            m_imgBg.sprite = spriteInfo.sprite;
        }
    }
}
