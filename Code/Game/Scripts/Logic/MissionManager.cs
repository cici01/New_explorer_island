using UnityEngine;
using System.Collections;

namespace Game
{
    public class MissionManager : MonoBehaviour
    {
        private static MissionManager s_instance = null;

        public GameObject m_pbGameMap = null;
        private GameMap m_gameMap = null;

        public static MissionManager Instance()
        {
            return s_instance;
        }

        private void Awake()
        {
            s_instance = this;
        }

        public void StartMission(int idMission)
        {
            //数据准备
            ModelManager.Instance().gameMap.Reset();

            //地图显示
            if (m_gameMap == null)
            {
                GameObject go = MonoBehaviour.Instantiate<GameObject>(m_pbGameMap);
                m_gameMap = go.GetComponent<GameMap>();
            }
            m_gameMap.gameObject.SetActive(true);
            m_gameMap.CreateMap(idMission);

            UIManager.Instance().OpenWindow(EM_UIType.eUT_MapConsole);
        }

        public void EndMission()
        {
            m_gameMap.DestroyMap();
            m_gameMap.gameObject.SetActive(false);
            UIManager.Instance().CloseWindow(EM_UIType.eUT_MapConsole);
            UIManager.Instance().CloseWindow(EM_UIType.eUT_MapTileInfo);
            UIManager.Instance().CloseWindow(EM_UIType.eUT_MapHeroInfo);
        }
    }
}
