using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class WndConsole : UIBase
    {
        public void OnBtnBack2Start()
        {
            string str = LanguageHelper.get_client_str(1);
            UIUtility.ShowConfirmAndCancel(str, () =>
            {
                CommonUtility.LoadScene("Start");
            });
        }

        public void OnBtnMission()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Console);
            MissionManager.Instance().StartMission(1);
        }

        public void OnBtnHero()
        {
            UIStateMachine.Instance().ChangeState(EM_UIState.eUS_Hero);
        }

        public void OnBtnShop()
        {
            UIStateMachine.Instance().ChangeState(EM_UIState.eUS_Shop);
        }

        public void OnBtnSystem()
        {
            UIManager.Instance().OpenWindow(EM_UIType.eUT_System);
        }
    }
}
