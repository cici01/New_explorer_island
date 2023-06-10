using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class MapObjectInfo
    {
        public Vector2Int v2Pos;
    }

    [Serializable]
    public class MapPlayerInfo : MapObjectInfo
    {
    }

    [Serializable]
    public class MapEnemyInfo : MapObjectInfo
    {
        public int idEnemy = 0;
    }

    [Serializable]
    public class MapInfo
    {
        public int idMap = 0;
        public int nWidth = 0;
        public int nHeight = 0;
        public Texture2D texMap = null;
        public List<MapPlayerInfo> lstPlayerInfo = null;
        public List<MapEnemyInfo> lstEnemyInfo = null;
    }

    [CreateAssetMenu(fileName = "MapConfig", menuName = "AssetConfig/Map", order = 1)]
    public class MapConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public MapInfo[] m_szMapInfo = null;
        private Dictionary<int, MapInfo> m_dicMapInfo = new Dictionary<int, MapInfo>();

        public void OnAfterDeserialize()
        {
            m_dicMapInfo.Clear();
            if (m_szMapInfo != null)
            {
                foreach (MapInfo mapInfo in m_szMapInfo)
                {
                    if (mapInfo.idMap == 0)
                    {
                        continue;
                    }

                    if (!m_dicMapInfo.ContainsKey(mapInfo.idMap))
                    {
                        m_dicMapInfo.Add(mapInfo.idMap, mapInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public MapInfo GetMapInfo(int idMap)
        {
            if (m_dicMapInfo.ContainsKey(idMap))
            {
                return m_dicMapInfo[idMap];
            }
            return null;
        }
    }
}
