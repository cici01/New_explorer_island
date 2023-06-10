using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game
{
    public class WndTitle : UIBase
    {
        public Text m_txtTitle = null;

        public override void Init(params object[] objs)
        {
            int idTitle = (int)objs[0];
            m_txtTitle.text = LanguageHelper.get_title_title(idTitle);
        }

        public void OnBtnBack()
        {
            UIStateMachine.Instance().ExitState();
        }
    }
}
