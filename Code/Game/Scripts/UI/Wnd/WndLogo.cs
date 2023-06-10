using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Game
{
    public class WndLogo : UIBase
    {
        private void Start()
        {
            SchedulerManager.Instance().AddScheduler(this.OnLoadScene, 1, 3f);
        }

        private void OnLoadScene()
        {
            SchedulerManager.Instance().DelScheduler(this.OnLoadScene);
            SceneManager.LoadScene("Start");
        }
    }
}
