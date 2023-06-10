using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class SystemModel : IModel
    {
        private bool m_bMusicOn = true;
        private bool m_bSoundOn = true;

        public override void Init()
        {
            m_bMusicOn = (RecordManager.Instance().GetGlobalInt("SwitchMusic", 1) == 1);
            m_bSoundOn = (RecordManager.Instance().GetGlobalInt("SwitchSound", 1) == 1);
            AudioManager.Instance().SetMusicVolume(m_bMusicOn ? 1f : 0f);
            AudioManager.Instance().SetSoundVolume(m_bSoundOn ? 1f : 0f);
        }

        public bool musicOn
        {
            set
            {
                m_bMusicOn = value;
                AudioManager.Instance().SetMusicVolume(m_bMusicOn ? 1f : 0f);
                RecordManager.Instance().SetGlobalInt("SwitchMusic", m_bMusicOn ? 1 : 0);
            }
            get { return m_bMusicOn; }
        }

        public bool soundOn
        {
            set
            {
                m_bSoundOn = value;
                AudioManager.Instance().SetSoundVolume(m_bSoundOn ? 1f : 0f);
                RecordManager.Instance().SetGlobalInt("SwitchSound", m_bSoundOn ? 1 : 0);
            }
            get { return m_bSoundOn; }
        }
    }
}
