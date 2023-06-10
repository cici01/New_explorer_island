using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public delegate void VoidFunc();

namespace Game
{
    public class WndConfirm : UIBase
    {
        public Text m_txtConfirm = null;
        public Transform m_transBtnConfirm = null;
        public GameObject m_goBtnCancel = null;

        private VoidFunc m_cbConfirm = null;
        private VoidFunc m_cbCancel = null;

        public override bool IsModal()
        {
            return true;
        }

        public override void OnModalClick()
        {
            this.OnBtnClose();
        }

        public override byte GetModalAlpha()
        {
            return 0;
        }

        public void ShowConfirm(string strText, VoidFunc cbConfirm = null)
        {
            m_txtConfirm.text = strText;
            m_cbConfirm = cbConfirm;
            m_transBtnConfirm.localPosition = new Vector3(0f, m_transBtnConfirm.localPosition.y, m_transBtnConfirm.localPosition.z);
            m_goBtnCancel.SetActive(false);
        }

        public void ShowConfirmAndCancel(string strText, VoidFunc cbConfirm = null, VoidFunc cbCancel = null)
        {
            m_txtConfirm.text = strText;
            m_cbConfirm = cbConfirm;
            m_cbCancel = cbCancel;
        }

        public void OnBtnConfirm()
        {
            if (m_cbConfirm != null)
            {
                m_cbConfirm();
            }
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Confirm);
        }

        public void OnBtnCancel()
        {
            if (m_cbCancel != null)
            {
                m_cbCancel();
            }
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Confirm);
        }

        public void OnBtnClose()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Confirm);
        }
    }
}
