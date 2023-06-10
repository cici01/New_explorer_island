using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game
{
    public class WndWarning : UIBase
    {
        public Text m_txtWarning = null;
        public float m_fShowtime = 3f;

        void Start()
        {
            SchedulerManager.Instance().AddScheduler(this.CloseWindow, 1, m_fShowtime);
        }

        void OnDestroy()
        {
            SchedulerManager.Instance().DelScheduler(this.CloseWindow);
        }

        public void ShowText(string strText)
        {
            m_txtWarning.text = strText;
        }

        public void CloseWindow()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Warning);
        }
    }
}
