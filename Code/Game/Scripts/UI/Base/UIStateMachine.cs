using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UIStateMachine
    {
        private static UIStateMachine s_instance = null;
        private Dictionary<EM_UIState, IUIState> m_dicUIState = new Dictionary<EM_UIState, IUIState>(); //状态实例
        private List<IUIState> m_lstUIState = new List<IUIState>(); //当前的ui状态队列

        public static UIStateMachine Instance()
        {
            if (s_instance == null)
            {
                s_instance = new UIStateMachine();
                s_instance.Init();
            }
            return s_instance;
        }

        private void Init()
        {
            m_dicUIState.Add(EM_UIState.eUS_Main, new UIStateMain());
            m_dicUIState.Add(EM_UIState.eUS_Hero, new UIStateHero());
            m_dicUIState.Add(EM_UIState.eUS_Shop, new UIStateShop());
        }

        public void ChangeState(EM_UIState eState)
        {
            if (m_lstUIState.Count > 0)
            {
                IUIState uiState = m_lstUIState[m_lstUIState.Count - 1];
                uiState.ExitState();
            }

            {
                IUIState uiState = m_dicUIState[eState];
                uiState.EnterState();
                m_lstUIState.Add(uiState);
            }
        }

        public void ExitState()
        {
            if (m_lstUIState.Count > 0)
            {
                int nIndex = m_lstUIState.Count - 1;
                IUIState uiState = m_lstUIState[nIndex];
                uiState.ExitState();
                m_lstUIState.RemoveAt(nIndex);
            }

            if (m_lstUIState.Count > 0)
            {
                int nIndex = m_lstUIState.Count - 1;
                IUIState uiState = m_lstUIState[nIndex];
                uiState.EnterState();
            }
            else
            {
                this.ChangeState(EM_UIState.eUS_Main);
            }
        }

        public void ExitAllState()
        {
            for (int i = m_lstUIState.Count - 1; i >= 0; --i)
            {
                IUIState uiState = m_lstUIState[i];
                uiState.ExitState();
            }
            m_lstUIState.Clear();
            this.ChangeState(EM_UIState.eUS_Main);
        }
    }
}
