using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class GameMap : MonoBehaviour
    {
        public SpriteRenderer m_srBackground = null;
        public GameObject m_pbGameMapTile = null;
        public Transform m_transTile = null;

        //全部地块
        private Dictionary<Vector2Int, GameMapTile> m_dicGameMapTile = new Dictionary<Vector2Int, GameMapTile>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 v3Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 v2Pos = new Vector2(v3Pos.x, v3Pos.y);
                RaycastHit2D hit = Physics2D.Raycast(v2Pos, Vector2.zero);
                if (hit.collider != null)
                {
                    GameMapTile gameMapTile = hit.collider.gameObject.GetComponent<GameMapTile>();
                    this.HitTile(gameMapTile);
                }
                else
                {
                    this.HitTile(null);
                }
            }
        }

        public void CreateMap(int idMission)
        {
            MissionInfo missionInfo = ConfigManager.Instance().GetConfig<MissionConfig>().GetMissionInfo(idMission);
            if (missionInfo == null)
            {
                Debug.LogError("GameMission.Create missionInfo == null, idMission = " + idMission);
                return;
            }

            m_srBackground.sprite = missionInfo.spBackground;

            MapInfo mapInfo = ConfigManager.Instance().GetConfig<MapConfig>().GetMapInfo(missionInfo.idMap);
            if (mapInfo == null)
            {
                Debug.LogError("GameMission.Create mapInfo == null, idMap = " + missionInfo.idMap);
                return;
            }

            m_dicGameMapTile.Clear();
            m_transTile.localPosition = Vector3.zero;
            m_transTile.localScale = CommonData.MAP_SCALE;
            Vector2 v2PosCenter = new Vector2((mapInfo.nWidth - 1) / 2, (mapInfo.nHeight - 1) / 2);

            Color32[] szColor = mapInfo.texMap.GetPixels32();
            for (int y = 0; y < mapInfo.texMap.height; ++y)
            {
                for (int x = 0; x < mapInfo.texMap.width; ++x)
                {
                    int n = mapInfo.texMap.height * y + x;
                    Color32 color = szColor[n];

                    GameObject go = MonoBehaviour.Instantiate<GameObject>(m_pbGameMapTile);
                    go.name = "Tile_" + x + "_" + y;
                    GameMapTile gameTile = go.GetComponent<GameMapTile>();
                    gameTile.v2Coordinate = new Vector2Int(x, y);
                    gameTile.SetSprite(color.r);
                    m_dicGameMapTile.Add(gameTile.v2Coordinate, gameTile);

                    float fPosX = (x - v2PosCenter.x) * CommonData.TILE_SIZE.x;
                    float fPosY = (y - v2PosCenter.y) * CommonData.TILE_SIZE.y;
                    go.transform.localPosition = new Vector3(fPosX, fPosY);
                    go.transform.SetParent(m_transTile, false);
                }
            }

            for (int i = 0; i < mapInfo.lstPlayerInfo.Count; ++i)
            {
                MapPlayerInfo info = mapInfo.lstPlayerInfo[i];
                ModelManager.Instance().gameMap.SetPlayerPos(i, info.v2Pos);
            }

            for (int i = 0; i < mapInfo.lstEnemyInfo.Count; ++i)
            {
                MapEnemyInfo info = mapInfo.lstEnemyInfo[i];
                ModelManager.Instance().gameMap.SetEnemyPos(info.idEnemy, info.v2Pos);
            }
        }

        public void DestroyMap()
        {
            foreach (Transform trans in m_transTile)
            {
                MonoBehaviour.Destroy(trans.gameObject);
            }
        }

        private void HitTile(GameMapTile gameTile)
        {
            if (gameTile != null)
            {
                Vector2Int v2Coordinate = gameTile.v2Coordinate;
                int id = ModelManager.Instance().gameMap.GetPlayerByPos(v2Coordinate);
                if (id != -1)
                {
                    UIManager.Instance().OpenWindow<WndMapTileInfo>(EM_UIType.eUT_MapTileInfo, gameTile.v2Coordinate, id);
                }
                else
                {
                    id = ModelManager.Instance().gameMap.GetEnemyByPos(v2Coordinate);
                    if (id != -1)
                    {
                        UIManager.Instance().OpenWindow<WndMapTileInfo>(EM_UIType.eUT_MapTileInfo, gameTile.v2Coordinate, id);
                    }
                }

                UIManager.Instance().OpenWindow(EM_UIType.eUT_MapHeroInfo);
            }
            else
            {
                UIManager.Instance().CloseWindow(EM_UIType.eUT_MapTileInfo);
                UIManager.Instance().CloseWindow(EM_UIType.eUT_MapHeroInfo);
            }
        }
    }
}
