using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class SoundInfo
    {
        public int idSound = 0;
        public AudioClip audioClip = null;
    }

    [CreateAssetMenu(fileName = "SoundConfig", menuName = "AssetConfig/Sound", order = 1)]
    public class SoundConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public SoundInfo[] m_szSoundInfo = null;
        private Dictionary<int, SoundInfo> m_dicSoundInfo = new Dictionary<int, SoundInfo>();

        public void OnAfterDeserialize()
        {
            m_dicSoundInfo.Clear();
            if (m_szSoundInfo != null)
            {
                foreach (SoundInfo soundInfo in m_szSoundInfo)
                {
                    if (!m_dicSoundInfo.ContainsKey(soundInfo.idSound))
                    {
                        m_dicSoundInfo.Add(soundInfo.idSound, soundInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public SoundInfo GetSoundInfo(int idSound)
        {
            if (m_dicSoundInfo.ContainsKey(idSound))
            {
                return m_dicSoundInfo[idSound];
            }
            return null;
        }
    }
}
