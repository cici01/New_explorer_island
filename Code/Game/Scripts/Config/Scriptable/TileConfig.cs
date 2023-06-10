using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class TileInfo
    {
        public int idTile = 0;
        public Sprite sprite = null;
        public int nCost = 1;       //移动消耗
        public int nPercentDef = 0; //防御加成百分比
    }

    [CreateAssetMenu(fileName = "TileConfig", menuName = "AssetConfig/Tile", order = 1)]
    public class TileConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public TileInfo[] m_szTileInfo = null;
        private Dictionary<int, TileInfo> m_dicTileInfo = new Dictionary<int, TileInfo>();

        public void OnAfterDeserialize()
        {
            m_dicTileInfo.Clear();
            if (m_szTileInfo != null)
            {
                foreach (TileInfo tileInfo in m_szTileInfo)
                {
                    if (tileInfo.idTile == 0)
                    {
                        continue;
                    }

                    if (!m_dicTileInfo.ContainsKey(tileInfo.idTile))
                    {
                        m_dicTileInfo.Add(tileInfo.idTile, tileInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public TileInfo GetTileInfo(int idTile)
        {
            if (m_dicTileInfo.ContainsKey(idTile))
            {
                return m_dicTileInfo[idTile];
            }
            return null;
        }
    }
}
