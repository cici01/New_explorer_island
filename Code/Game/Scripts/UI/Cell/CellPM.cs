using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game
{
    public class CellPM : MonoBehaviour
    {
        public Text m_txtFunc = null;

        private PMInfo m_pmInfo = null;

        public void Init(PMInfo pmInfo)
        {
            m_pmInfo = pmInfo;
            m_txtFunc.text = pmInfo.strFunc;
        }

        public void OnImgBg()
        {
            WndPM wndPM = UIManager.Instance().GetWindow<WndPM>(EM_UIType.eUT_PM);
            wndPM.SetCode(m_pmInfo.strCode);
        }
    }
}
