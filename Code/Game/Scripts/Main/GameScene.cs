using UnityEngine;

namespace Game
{
    public class GameScene : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance().CloseAllWindow();
            UIStateMachine.Instance().ChangeState(EM_UIState.eUS_Main);
            AudioManager.Instance().PlayMusic(2);
        }
    }
}
