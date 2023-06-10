using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class WndSystem : UIBase
    {
        public Image m_imgMusic = null;
        public Image m_imgSound = null;

        private void Start()
        {
            this.RefreshMusic();
            this.RefreshSound();
        }

        public override bool IsModal()
        {
            return true;
        }

        public override void OnModalClick()
        {
            this.OnBtnClose();
        }

        private void RefreshMusic()
        {
            int idSprite = ModelManager.Instance().system.musicOn ? 102 : 101;
            m_imgMusic.sprite = SpriteManager.Instance().GetSprite(idSprite);
        }

        private void RefreshSound()
        {
            int idSprite = ModelManager.Instance().system.soundOn ? 102 : 101;
            m_imgSound.sprite = SpriteManager.Instance().GetSprite(idSprite);
        }

        public void OnBtnClose()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_System);
        }

        public void OnSwtichMusic()
        {
            ModelManager.Instance().system.musicOn = !(ModelManager.Instance().system.musicOn);
            this.RefreshMusic();
        }

        public void OnSwtichSound()
        {
            ModelManager.Instance().system.soundOn = !(ModelManager.Instance().system.soundOn);
            this.RefreshSound();
        }
    }
}
