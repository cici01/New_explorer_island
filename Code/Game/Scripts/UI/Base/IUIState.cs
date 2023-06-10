using UnityEngine;

namespace Game
{
    //对话框状态
    public enum EM_UIState
    {
        eUS_None,
        eUS_Main,   //首页
        eUS_Hero,   //英雄
        eUS_Shop,   //商店
    }

    //对话框标题
    public enum EM_UITitle
    {
        eUT_None,
        eUT_Hero,   //英雄
        eUT_Shop,   //商店
    }

    public interface IUIState
    {
        EM_UIState uiState { get; }
        EM_UITitle uiTitle { get; }
        void EnterState();
        void ExitState();
    }
}
