using UnityEngine;

namespace Game
{
    public class StartScene : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance().CloseAllWindow();
            UIManager.Instance().OpenWindow(EM_UIType.eUT_Start);
            AudioManager.Instance().PlayMusic(1);
        }
    }
}
