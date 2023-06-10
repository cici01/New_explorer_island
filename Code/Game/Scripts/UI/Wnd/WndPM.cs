using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace Game
{
    public class WndPM : UIBase
    {
        public InputField m_inpCode = null;
        public GameObject m_pbCellPM = null;
        public Transform m_transLayoutGroup = null;

        void Start()
        {
            List<PMInfo> lstPMInfo = ConfigManager.Instance().GetConfig<PMConfig>().lstPMInfo;
            for (int i = 0; i < lstPMInfo.Count; ++i)
            {
                GameObject go = MonoBehaviour.Instantiate(m_pbCellPM) as GameObject;
                go.transform.SetParent(m_transLayoutGroup);
                go.transform.localScale = Vector3.one;
                CellPM cellPM = go.GetComponent<CellPM>();
                cellPM.Init(lstPMInfo[i]);
            }
        }

        public void SetCode(string strCode)
        {
            m_inpCode.text = strCode;
        }

        public void OnBtnExecute()
        {
            m_inpCode.text = m_inpCode.text.Trim();
            if (m_inpCode.text.Length == 0)
            {
                UIUtility.ShowWarning(36002);
                return;
            }

            string[] szStr = m_inpCode.text.Split(' ');
            if (szStr == null || szStr.Length == 0)
            {
                UIUtility.ShowWarning(36002);
                return;
            }

            string strCode = szStr[0];
            switch (strCode)
            {
                case "AddMoney":
                    {
                    }
                    break;
                case "AddEMoney":
                    {
                    }
                    break;
                case "OpenWindow":
                    {
                        if (szStr.Length < 2)
                        {
                            UIUtility.ShowWarning(36002);
                            return;
                        }
                        EM_UIType eType = (EM_UIType)Convert.ToInt32(szStr[1]);
                        UIManager.Instance().OpenWindow(eType);
                    }
                    break;
                case "CloseWindow":
                    {
                        if (szStr.Length < 2)
                        {
                            UIUtility.ShowWarning(36002);
                            return;
                        }
                        EM_UIType eType = (EM_UIType)Convert.ToInt32(szStr[1]);
                        UIManager.Instance().CloseWindow(eType);
                    }
                    break;
                default:
                    {
                        UIUtility.ShowWarning(36002);
                    }
                    break;
            }
            UIUtility.ShowWarning(36001);
        }

        public void OnBtnClose()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_PM);
        }
    }
}
