using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
    [AddComponentMenu("UI/ButtonPlus", 32)]
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public class ButtonPlus : Button
    {
        [SerializeField]
        public Transform m_transScale = null;   //缩放的transform
        public float m_fPressScale = 0.9f;      //缩放系数
        public int m_idClickClip = 1;           //点击音效

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (m_idClickClip != 0)
            {
                AudioManager.Instance().PlaySound(m_idClickClip);
            }
            base.OnPointerClick(eventData);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            m_transScale.localScale = new Vector3(m_fPressScale, m_fPressScale, 1);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            m_transScale.localScale = Vector3.one;
            base.OnPointerDown(eventData);
        }
    }
}
