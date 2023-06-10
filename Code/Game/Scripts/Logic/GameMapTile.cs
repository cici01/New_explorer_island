using UnityEngine;
using System.Collections;

namespace Game
{
    public class GameMapTile : MonoBehaviour
    {
        public SpriteRenderer m_srTile = null;
        public SpriteRenderer m_srRange = null;
        public SpriteRenderer m_srEvent = null;
        public SpriteRenderer m_srHero = null;

        private Vector2Int m_v2Coordinate;
        public Vector2Int v2Coordinate
        {
            set { m_v2Coordinate = value; }
            get { return m_v2Coordinate; }
        }

        public void SetSprite(int idTile)
        {
            TileInfo tileInfo = ConfigManager.Instance().GetConfig<TileConfig>().GetTileInfo(idTile);
            m_srTile.sprite = tileInfo.sprite;
        }
    }
}
