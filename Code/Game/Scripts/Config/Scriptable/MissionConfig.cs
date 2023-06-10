using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class MissionInfo
    {
        public int idMission = 0;
        public int idMap = 0;
        public Sprite spBackground = null;
    }

    [CreateAssetMenu(fileName = "MissionConfig", menuName = "AssetConfig/Mission", order = 1)]
    public class MissionConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public MissionInfo[] m_szMissionInfo = null;
        private Dictionary<int, MissionInfo> m_dicMissionInfo = new Dictionary<int, MissionInfo>();

        public void OnAfterDeserialize()
        {
            m_dicMissionInfo.Clear();
            if (m_szMissionInfo != null)
            {
                foreach (MissionInfo missionInfo in m_szMissionInfo)
                {
                    if (!m_dicMissionInfo.ContainsKey(missionInfo.idMission))
                    {
                        m_dicMissionInfo.Add(missionInfo.idMission, missionInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public MissionInfo GetMissionInfo(int idMission)
        {
            if (m_dicMissionInfo.ContainsKey(idMission))
            {
                return m_dicMissionInfo[idMission];
            }
            return null;
        }
    }
}
