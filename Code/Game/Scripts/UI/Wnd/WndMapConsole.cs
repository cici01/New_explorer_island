using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class WndMapConsole : UIBase
    {
        public void OnBtnBack()
        {
            MissionManager.Instance().EndMission();
            UIManager.Instance().OpenWindow(EM_UIType.eUT_Console);
        }
    }
}
