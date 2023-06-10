using UnityEngine;

namespace Game
{
    public class GameMain : MonoBehaviour
    {
        private static GameMain s_instance = null;
        public static GameMain Instance()
        {
            return s_instance;
        }

        private void Awake()
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
            ConfigManager.Instance().Init();
            ModelManager.Instance().Init();
        }

        private void Update()
        {
            SchedulerManager.Instance().Update();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.Instance().OpenWindow(EM_UIType.eUT_PM);
            }
        }
    }
}
