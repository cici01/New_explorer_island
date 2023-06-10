using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class WndLoading : UIBase
    {
        public Image m_imgProgress = null;
        public Text m_txtProgress = null;

        void OnEnable()
        {
            NotifyCenter.Instance().AddEventListener(EM_NotifyMessage.eNM_LoadingProgress, this.SetProgress);
        }

        void OnDisable()
        {
            NotifyCenter.Instance().RemoveEventListener(EM_NotifyMessage.eNM_LoadingProgress, this.SetProgress);
        }

        private void SetProgress(params object[] objs)
        {
            float fProgress = (float)objs[0];
            m_imgProgress.fillAmount = fProgress;
            m_txtProgress.text = Mathf.CeilToInt(fProgress * 100) + "%";
        }
    }
}
