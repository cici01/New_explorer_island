using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager s_instance = null;
        private Dictionary<EM_UIType, GameObject> m_dicWindow = new Dictionary<EM_UIType, GameObject>();
        private Dictionary<EM_UILayer, Transform> m_dicLayer = new Dictionary<EM_UILayer, Transform>();
        private GameObject m_goWndModal = null;

        public Transform m_transCanvas = null;
        public GameObject m_goEventSystem = null;
        public GameObject m_pbWndModal = null;

        public static UIManager Instance()
        {
            return s_instance;
        }

        private void Awake()
        {
            s_instance = this;
            DontDestroyOnLoad(m_transCanvas.gameObject);
            DontDestroyOnLoad(m_goEventSystem);
        }

        public GameObject OpenWindow(EM_UIType eType)
        {
            if (m_dicWindow.ContainsKey(eType))
            {
                return m_dicWindow[eType];
            }

            UIInfo uiInfo = ConfigManager.Instance().GetConfig<UIConfig>().GetUIInfo(eType);
            if (uiInfo == null)
            {
                return null;
            }

            //放在适当的layer上
            GameObject go = MonoBehaviour.Instantiate(uiInfo.pbWindow) as GameObject;
            if (!m_dicLayer.ContainsKey(uiInfo.eLayer))
            {
                int nLayer = (int)uiInfo.eLayer;
                GameObject goLayer = new GameObject("Layer" + nLayer);
                RectTransform rt = goLayer.AddComponent<RectTransform>();
                rt.sizeDelta = Vector2.zero;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                goLayer.transform.SetParent(m_transCanvas, false);

                //计算层级关系
                int nIndex = 0;
                foreach (EM_UILayer eLayer in m_dicLayer.Keys)
                {
                    if (nLayer > (int)eLayer)
                    {
                        ++nIndex;
                    }
                }
                goLayer.transform.SetSiblingIndex(nIndex);
                m_dicLayer.Add(uiInfo.eLayer, goLayer.transform);
            }

            Transform transLayer = m_dicLayer[uiInfo.eLayer];
            go.transform.SetParent(transLayer, false);
            m_dicWindow[eType] = go;
            this.CheckModal();
            return go;
        }

        public T OpenWindow<T>(EM_UIType eType, params object[] objs) where T : UIBase
        {
            GameObject go = this.OpenWindow(eType);
            if (go != null)
            {
                T t = go.GetComponent<T>();
                t.Init(objs);
                return t;
            }
            return null;
        }

        public void CloseWindow(EM_UIType eType)
        {
            if (!m_dicWindow.ContainsKey(eType))
            {
                return;
            }

            GameObject go = m_dicWindow[eType];
            m_dicWindow.Remove(eType);
            go.transform.SetParent(null);
            MonoBehaviour.Destroy(go);
            this.CheckModal();
        }

        public void CloseAllWindow()
        {
            foreach (GameObject go in m_dicWindow.Values)
            {
                MonoBehaviour.Destroy(go);
            }
            m_dicWindow.Clear();

            if (m_goWndModal != null)
            {
                m_goWndModal.SetActive(false);
            }
        }

        //确认是否需要模式对话框
        private void CheckModal()
        {
            for (int i = m_transCanvas.childCount - 1; i >= 0; --i)
            {
                Transform transLayer = m_transCanvas.GetChild(i);
                for (int j = transLayer.childCount - 1; j >= 0; --j)
                {
                    Transform transWindow = transLayer.GetChild(j);
                    UIBase uiBase = transWindow.gameObject.GetComponent<UIBase>();
                    if (uiBase != null && uiBase.IsModal())
                    {
                        if (m_goWndModal == null)
                        {
                            m_goWndModal = MonoBehaviour.Instantiate(m_pbWndModal) as GameObject;
                        }
                        m_goWndModal.transform.SetParent(transLayer, false);
                        int nIndex = Mathf.Max(j - 1, 0);
                        m_goWndModal.transform.SetSiblingIndex(nIndex);
                        m_goWndModal.SetActive(true);

                        WndModal wndModal = m_goWndModal.GetComponent<WndModal>();
                        wndModal.Reset(uiBase.GetModalAlpha(), uiBase.OnModalClick);
                        return;
                    }
                }
            }

            if (m_goWndModal != null)
            {
                m_goWndModal.SetActive(false);
            }
        }

        public GameObject GetWindow(EM_UIType eType)
        {
            if (!m_dicWindow.ContainsKey(eType))
            {
                return null;
            }
            return m_dicWindow[eType];
        }

        public T GetWindow<T>(EM_UIType eType) where T : MonoBehaviour
        {
            GameObject go = this.GetWindow(eType);
            if (go != null)
            {
                T t = go.GetComponent<T>();
                return t;
            }
            return null;
        }
    }
}
