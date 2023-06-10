using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using Game;

namespace MetaCharacter.Editors
{
    public class MapTile
    {
        public int nPosX = 0;
        public int nPosY = 0;
        public int idTile = 0;
        public SpriteRenderer spTile = null;
        public SpriteRenderer spRange = null;
        public TextMesh tmTileIndex = null;
        public TextMesh tmPos = null;
    }

    public class MapMaker : EditorWindow
    {
        private int m_idMap = 0;        //地图id
        private Vector2Int m_v2Size;    //地图尺寸
        private bool m_bShowTileIndex = false;  //是否显示地块的精灵索引
        private bool m_bShowPos = false;        //显示地块的坐标
        private int m_idTileDefault = 0;        //默认的地块id
        private Sprite m_spTileDefault = null;  //默认的地块精灵
        private int m_idTile = 0;               //填充的地块id
        private Sprite m_spTile = null;         //填充的地块精灵

        private Transform m_transMap = null;
        private Dictionary<Vector2Int, MapTile> m_dicMapTile = new Dictionary<Vector2Int, MapTile>();

        [MenuItem("CommonTools/地图编辑器")]
        private static void Package()
        {
            GetWindow(typeof(MapMaker));
        }

        void OnEnable()
        {
            titleContent.text = "地图编辑器";
            minSize = new Vector2(300, 400);
            this.InitScene();
        }

        private void InitScene()
        {
            GameObject go = GameObject.Find("GameMap");
            if (go == null)
            {
                go = new GameObject("GameMap");
                go.transform.localPosition = Vector3.zero;
            }
            m_transMap = go.transform;
            m_transMap.localScale = CommonData.MAP_SCALE;

            TileInfo tileInfo = ConfigManager.Instance().GetConfig<TileConfig>().GetTileInfo(1);
            m_spTileDefault = tileInfo.sprite;
        }

        void OnDisable()
        {
            if (m_transMap != null)
            {
                DestroyImmediate(m_transMap.gameObject);
                m_transMap = null;
            }
        }

        void OnGUI()
        {
            EditorGUILayout.Space(10);
            GUILayout.Label("地图设置：");

            m_idMap = EditorGUILayout.IntField("地图id", m_idMap);
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("加载地图"))
                {
                    this.OnBtnLoadMap();
                }

                if (GUILayout.Button("保存地图"))
                {
                    this.OnBtnSaveMap();
                }
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(10);
            m_v2Size = EditorGUILayout.Vector2IntField("地图尺寸", m_v2Size);

            EditorGUILayout.Space(10);
            bool bShow = m_bShowTileIndex;
            m_bShowTileIndex = EditorGUILayout.Toggle("显示地块的精灵索引", m_bShowTileIndex);
            if (m_bShowTileIndex != bShow)
            {
                this.ShowSpriteIndex();
            }

            bShow = m_bShowPos;
            m_bShowPos = EditorGUILayout.Toggle("显示地块的坐标", m_bShowPos);
            if (m_bShowPos != bShow)
            {
                this.ShowPos();
            }

            EditorGUILayout.Space(10);
            GUILayout.Label("地块设置：");

            m_idTileDefault = 0;
            m_spTileDefault = EditorGUILayout.ObjectField("默认的地块精灵", m_spTileDefault, typeof(Sprite), false) as Sprite;
            if (m_spTileDefault != null)
            {
                TileInfo[] szTileInfo = ConfigManager.Instance().GetConfig<TileConfig>().m_szTileInfo;
                for (int i = 0; i < szTileInfo.Length; ++i)
                {
                    TileInfo tileInfo = szTileInfo[i];
                    if (m_spTileDefault == tileInfo.sprite)
                    {
                        m_idTileDefault = tileInfo.idTile;
                    }
                }
            }

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                EditorGUILayout.TextArea("默认的地块id: " + m_idTileDefault, GUILayout.Width(100));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            m_idTile = 0;
            m_spTile = EditorGUILayout.ObjectField("填充的地块精灵", m_spTile, typeof(Sprite), false) as Sprite;
            if (m_spTile != null)
            {
                TileInfo[] szTileInfo = ConfigManager.Instance().GetConfig<TileConfig>().m_szTileInfo;
                for (int i = 0; i < szTileInfo.Length; ++i)
                {
                    TileInfo tileInfo = szTileInfo[i];
                    if (m_spTile == tileInfo.sprite)
                    {
                        m_idTile = tileInfo.idTile;
                    }
                }
            }

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                EditorGUILayout.TextArea("填充的地块id: " + m_idTile, GUILayout.Width(100));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("新建地图"))
                {
                    this.OnBtnNewMap();
                }

                if (GUILayout.Button("填充地块"))
                {
                    this.OnBtnSetTile();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        private void OnBtnLoadMap()
        {
            if (m_idMap <= 0)
            {
                EditorUtility.DisplayDialog("警告", "地图id需要大于0哟！", "确定");
                return;
            }
        }

        private void OnBtnSaveMap()
        {
            if (m_idMap <= 0)
            {
                EditorUtility.DisplayDialog("警告", "地图id需要大于0哟！", "确定");
                return;
            }

            if (!EditorUtility.DisplayDialog("警告", "保存将覆盖已有配置，是否继续？", "继续"))
            {
                return;
            }
        }

        private void OnBtnNewMap()
        {
            if (m_v2Size.x <= 0 || m_v2Size.y <= 0)
            {
                EditorUtility.DisplayDialog("警告", "地图尺寸需要大于0哟！", "确定");
                return;
            }

            if (m_spTileDefault == null)
            {
                EditorUtility.DisplayDialog("警告", "缺少默认的地块精灵哟！", "确定");
                return;
            }
            this.CreateMap(m_v2Size.x, m_v2Size.y);
        }

        private void CreateMap(int nSizeX, int nSizeY)
        {
            this.ClearMap();

            float fHalfTileSizeX = CommonData.TILE_SIZE.x / 2;
            float fHalfTileSizeY = CommonData.TILE_SIZE.y / 2;
            float fPosXMin = -nSizeX * CommonData.TILE_SIZE.x / 2f + fHalfTileSizeX;
            float fPosYMin = -nSizeY * CommonData.TILE_SIZE.y / 2f + fHalfTileSizeY;
            for (int j = nSizeY - 1; j >= 0; --j)
            {
                for (int i = 0; i < nSizeX; ++i)
                {
                    MapTile mapTile = new MapTile();
                    mapTile.nPosX = i;
                    mapTile.nPosY = j;
                    m_dicMapTile.Add(new Vector2Int(i, j), mapTile);

                    GameObject goTile = new GameObject();
                    goTile.name = "MapTile(" + i + "," + j + ")";
                    goTile.transform.localPosition = new Vector3(fPosXMin + i * CommonData.TILE_SIZE.x, fPosYMin + j * CommonData.TILE_SIZE.y);
                    goTile.transform.SetParent(m_transMap, false);
                    goTile.AddComponent<BoxCollider2D>();

                    GameObject go = new GameObject("Tile");
                    go.transform.SetParent(goTile.transform, false);
                    mapTile.spTile = go.AddComponent<SpriteRenderer>();
                    mapTile.spTile.sprite = m_spTileDefault;
                    mapTile.idTile = m_idTileDefault;

                    go = new GameObject("Range");
                    go.transform.localPosition = new Vector3(0, 0, -0.1f);
                    go.transform.SetParent(goTile.transform, false);
                    mapTile.spRange = go.AddComponent<SpriteRenderer>();

                    go = new GameObject("TxtSpriteIndex");
                    go.transform.localPosition = new Vector3(0, 0, -0.2f);
                    go.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
                    go.transform.SetParent(goTile.transform, false);
                    mapTile.tmTileIndex = go.AddComponent<TextMesh>();
                    mapTile.tmTileIndex.anchor = TextAnchor.MiddleCenter;
                    mapTile.tmTileIndex.fontSize = 30;
                    mapTile.tmTileIndex.fontStyle = FontStyle.Bold;
                    mapTile.tmTileIndex.color = Color.red;
                    mapTile.tmTileIndex.text = mapTile.idTile.ToString();
                    go.SetActive(m_bShowTileIndex);

                    go = new GameObject("TxtPos");
                    go.transform.localPosition = new Vector3(0.8f, -0.8f, -0.2f);
                    go.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
                    go.transform.SetParent(goTile.transform, false);
                    mapTile.tmPos = go.AddComponent<TextMesh>();
                    mapTile.tmPos.anchor = TextAnchor.MiddleCenter;
                    mapTile.tmPos.fontSize = 30;
                    mapTile.tmPos.fontStyle = FontStyle.Bold;
                    mapTile.tmPos.color = Color.red;
                    mapTile.tmPos.text = i + ","+j;
                    go.SetActive(m_bShowPos);
                }
            }
        }

        private void ClearMap()
        {
            for (int i = m_transMap.childCount - 1; i >= 0; --i)
            {
                Transform trans = m_transMap.GetChild(i);
                DestroyImmediate(trans.gameObject);
            }
            m_dicMapTile.Clear();
        }

        private void OnBtnSetTile()
        {
            if (m_spTile == null)
            {
                EditorUtility.DisplayDialog("警告", "缺少填充的地块精灵哟！", "确定");
                return;
            }
        }

        private void ShowSpriteIndex()
        {
            foreach (MapTile mapTile in m_dicMapTile.Values)
            {
                if (mapTile != null && mapTile.tmTileIndex != null)
                {
                    mapTile.tmTileIndex.gameObject.SetActive(m_bShowTileIndex);
                }
            }
        }

        private void ShowPos()
        {
            foreach (MapTile mapTile in m_dicMapTile.Values)
            {
                if (mapTile != null && mapTile.tmPos != null)
                {
                    mapTile.tmPos.gameObject.SetActive(m_bShowPos);
                }
            }
        }
    }
}
