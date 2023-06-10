using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game
{
    public class WndModal : UIBase
    {
        public Image m_imgModal = null;

        private VoidFunc m_cbClick = null;

        public void Reset(byte btAlpha, VoidFunc cbClick = null)
        {
            m_imgModal.color = new Color32(0, 0, 0, btAlpha);
            m_cbClick = cbClick;
        }

        public void OnClick()
        {
            if (m_cbClick != null)
            {
                m_cbClick();
            }
        }
    }
}
