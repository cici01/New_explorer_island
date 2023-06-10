using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Game
{
    public class WndStart : UIBase
    {
        public void OnBtnStart()
        {
            CommonUtility.LoadScene("Game");
        }
    }
}
