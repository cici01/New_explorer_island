using UnityEngine;

namespace Game
{
    public class LogoScene : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance().OpenWindow(EM_UIType.eUT_Logo);
        }
    }
}
