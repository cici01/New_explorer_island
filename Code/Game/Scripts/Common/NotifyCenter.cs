using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//一般用于下层通知上层，以摆脱耦合
//正常模块的逻辑不需要走这个流程，代码尽量易读，避免泛用监听者模式
//多模块交叉引用的情况可以考虑使用中介者

namespace Game
{
    public delegate void IObserver(params object[] objs);

    public class NotifyCenter
    {
        private class ObserverInfo
        {
            public IObserver pObserver;
            public bool bRemoved;
        };

        private static NotifyCenter s_instance = null;
        private Dictionary<EM_NotifyMessage, List<ObserverInfo>> m_listeners = new Dictionary<EM_NotifyMessage, List<ObserverInfo>>();

        public static NotifyCenter Instance()
        {
            if (s_instance == null)
            {
                s_instance = new NotifyCenter();
            }
            return s_instance;
        }

        public void Notify(EM_NotifyMessage evt, params object[] objs)
        {
            List<ObserverInfo> handlers;
            if (m_listeners.TryGetValue(evt, out handlers))
            {
                ObserverInfo handler = null;
                int count = handlers.Count;
                for (int i = 0; i < count; i++)
                {
                    handler = handlers[i];
                    if (handler.pObserver != null)
                    {
                        handler.pObserver(objs);
                    }
                }
            }
        }

        public void AddEventListener(EM_NotifyMessage type, IObserver handler)
        {
            if (handler == null)
                return;
            List<ObserverInfo> handlers = null;
            if (!m_listeners.ContainsKey(type))
            {
                handlers = new List<ObserverInfo>();
                m_listeners.Add(type, handlers);
            }
            else
            {
                handlers = m_listeners[type];
            }

            ObserverInfo info = handlers.Find(delegate (ObserverInfo observer)
            {
                if (observer.pObserver == handler)
                    return true;
                return false;
            });
            if (info == null)
            {
                info = new ObserverInfo();
                info.bRemoved = false;
                info.pObserver = handler;
                handlers.Add(info);
            }
        }

        public void RemoveEventListener(EM_NotifyMessage type, IObserver handler)
        {
            List<ObserverInfo> handlers = m_listeners[type];
            if (handlers != null && handler != null)
            {
                ObserverInfo info = handlers.Find(delegate (ObserverInfo observer)
                {
                    if (observer.pObserver == handler)
                        return true;
                    return false;
                });

                if (info != null)
                {
                    info.bRemoved = true;
                    info.pObserver = null;
                    m_bNeedGC = true;
                }
            }
        }

        public void GarbageCollection(float fTimeDef)
        {
            if (m_bNeedGC)
            {
                m_bNeedGC = false;
                foreach (KeyValuePair<EM_NotifyMessage, List<ObserverInfo>> handlersKey in m_listeners)
                {
                    handlersKey.Value.RemoveAll(delegate (ObserverInfo item) { if (item.bRemoved == true) return true; return false; });
                }
            }
        }

        private bool m_bNeedGC = false;
    }
}
