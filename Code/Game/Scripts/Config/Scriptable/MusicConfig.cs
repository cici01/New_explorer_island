using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class MusicInfo
    {
        public int idMusic = 0;
        public AudioClip audioClip = null;
    }

    [CreateAssetMenu(fileName = "MusicConfig", menuName = "AssetConfig/Music", order = 1)]
    public class MusicConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public MusicInfo[] m_szMusicInfo = null;
        private Dictionary<int, MusicInfo> m_dicMusicInfo = new Dictionary<int, MusicInfo>();

        public void OnAfterDeserialize()
        {
            m_dicMusicInfo.Clear();
            if (m_szMusicInfo != null)
            {
                foreach (MusicInfo musicInfo in m_szMusicInfo)
                {
                    if (!m_dicMusicInfo.ContainsKey(musicInfo.idMusic))
                    {
                        m_dicMusicInfo.Add(musicInfo.idMusic, musicInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public MusicInfo GetMusicInfo(int idMusic)
        {
            if (m_dicMusicInfo.ContainsKey(idMusic))
            {
                return m_dicMusicInfo[idMusic];
            }
            return null;
        }
    }
}
