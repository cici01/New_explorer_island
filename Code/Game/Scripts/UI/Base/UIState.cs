using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public abstract class UIState : IUIState
    {
        public virtual EM_UIState uiState { get; }
        public virtual EM_UITitle uiTitle { get; }

        public virtual void EnterState()
        {
            if (uiTitle == EM_UITitle.eUT_None)
            {
                return;
            }

            int idTitle = (int)uiTitle;
            UIManager.Instance().OpenWindow<WndTitle>(EM_UIType.eUT_Title, idTitle);

            TitleInfo titleInfo = ConfigManager.Instance().GetConfig<TitleConfig>().GetTitleInfo(idTitle);
            if (titleInfo.idSpriteBg != 0)
            {
                UIManager.Instance().OpenWindow<WndBackground>(EM_UIType.eUT_Background, titleInfo.idSpriteBg);
            }
        }

        public virtual void ExitState()
        {
            if (uiTitle == EM_UITitle.eUT_None)
            {
                return;
            }

            UIManager.Instance().CloseWindow(EM_UIType.eUT_Title);

            int idTitle = (int)uiTitle;
            TitleInfo titleInfo = ConfigManager.Instance().GetConfig<TitleConfig>().GetTitleInfo(idTitle);
            if (titleInfo.idSpriteBg != 0)
            {
                UIManager.Instance().CloseWindow(EM_UIType.eUT_Background);
            }
        }
    }

    public class UIStateMain : UIState
    {
        public override EM_UIState uiState { get { return EM_UIState.eUS_Main; } }
        public override EM_UITitle uiTitle { get { return EM_UITitle.eUT_None; } }

        public override void EnterState()
        {
            UIManager.Instance().OpenWindow(EM_UIType.eUT_Console);
            base.EnterState();
        }

        public override void ExitState()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Console);
            base.ExitState();
        }
    }

    public class UIStateHero : UIState
    {
        public override EM_UIState uiState { get { return EM_UIState.eUS_Hero; } }
        public override EM_UITitle uiTitle { get { return EM_UITitle.eUT_Hero; } }

        public override void EnterState()
        {
            UIManager.Instance().OpenWindow(EM_UIType.eUT_Hero);
            base.EnterState();
        }

        public override void ExitState()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Hero);
            base.ExitState();
        }
    }

    public class UIStateShop : UIState
    {
        public override EM_UIState uiState { get { return EM_UIState.eUS_Shop; } }
        public override EM_UITitle uiTitle { get { return EM_UITitle.eUT_Shop; } }

        public override void EnterState()
        {
            UIManager.Instance().OpenWindow(EM_UIType.eUT_Shop);
            base.EnterState();
        }

        public override void ExitState()
        {
            UIManager.Instance().CloseWindow(EM_UIType.eUT_Shop);
            base.ExitState();
        }
    }
}
