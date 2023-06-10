using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
    public class UIBase : MonoBehaviour
    {
        public virtual void Init(params object[] objs)
        {
        }

        public virtual bool IsModal()
        {
            return false;
        }

        public virtual void OnModalClick()
        {
        }

        public virtual byte GetModalAlpha()
        {
            return 170;
        }
    }
}
