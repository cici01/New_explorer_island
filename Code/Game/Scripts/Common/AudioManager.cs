using UnityEngine;
using System.Collections;

namespace Game
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager s_instance = null;

        public AudioSource m_musicSource = null;
        public AudioSource[] m_szSoundSource = null;
        private int m_idCurMusic = 0;

        public static AudioManager Instance()
        {
            return s_instance;
        }

        private void Awake()
        {
            s_instance = this;
        }

        public void PlayMusic(int idMusic)
        {
            if (m_musicSource.isPlaying && m_idCurMusic == idMusic)
            {
                return;
            }

            m_idCurMusic = idMusic;
            MusicInfo musicInfo = ConfigManager.Instance().GetConfig<MusicConfig>().GetMusicInfo(idMusic);
            m_musicSource.clip = musicInfo.audioClip;
            m_musicSource.Play();
        }

        public void StopMusic()
        {
            m_musicSource.Stop();
            m_idCurMusic = 0;
        }

        public void SetMusicVolume(float fVolume)
        {
            m_musicSource.volume = fVolume;
        }

        public void PlaySound(int idSound)
        {
            int i = 0;
            for (; i < m_szSoundSource.Length; ++i)
            {
                if (!m_szSoundSource[i].isPlaying)
                {
                    break;
                }
            }

            if (i < m_szSoundSource.Length)
            {
                SoundInfo soundInfo = ConfigManager.Instance().GetConfig<SoundConfig>().GetSoundInfo(idSound);
                m_szSoundSource[i].clip = soundInfo.audioClip;
                m_szSoundSource[i].Play();
            }
        }

        public void SetSoundVolume(float fVolume)
        {
            for (int i = 0; i < m_szSoundSource.Length; ++i)
            {
                m_szSoundSource[i].volume = fVolume;
            }
        }
    }
}
