using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public delegate void CallBack();

    public class SchedulerManager
    {
        private class Scheduler
        {
            protected float m_fInterval;
            protected float m_fUpdateTime;
            public CallBack m_pCallBack;
            protected int m_nLoop;

            public Scheduler(float fIntervalSecs, int nLoop, CallBack callBack)
            {
                m_nLoop = nLoop;
                m_fInterval = fIntervalSecs;
                UpdateTime();
                m_pCallBack = callBack;
            }

            public void Update()
            {
                if (IsEnd())
                    return;

                if (IsExpire())
                {
                    float fDeltaTime = UpdateTime();
                    if (m_nLoop > 0)
                        --m_nLoop;
                    m_pCallBack();
                }
            }

            virtual protected float UpdateTime()
            {
                float fReturn = Time.time - m_fUpdateTime;
                m_fUpdateTime = Time.time;
                return fReturn;
            }

            virtual protected bool IsExpire()
            {
                return Time.time > (m_fUpdateTime + m_fInterval);
            }

            public bool IsEnd()
            {
                if (m_nLoop == 0)
                    return true;
                return false;
            }

            public void ForceEnd()
            {
                m_nLoop = 0;
            }
        }

        private class SchedulerFixTime : Scheduler
        {
            public SchedulerFixTime(float fIntervalSecs, int nLoop, CallBack callBack) : base(fIntervalSecs, nLoop, callBack)
            {
            }

            override protected float UpdateTime()
            {
                float fReturn = Time.realtimeSinceStartup - m_fUpdateTime;
                m_fUpdateTime = Time.realtimeSinceStartup;
                return fReturn;
            }

            override protected bool IsExpire()
            {
                return Time.realtimeSinceStartup > (m_fUpdateTime + m_fInterval);
            }
        }

        private static SchedulerManager s_instance = null;
        private List<Scheduler> m_pScheduler = new List<Scheduler>();
        private List<Scheduler> m_pBuffScheduler = new List<Scheduler>();

        public static SchedulerManager Instance()
        {
            if (s_instance == null)
            {
                s_instance = new SchedulerManager();
            }
            return s_instance;
        }

        public bool AddScheduler(CallBack call, int nLoop, float fIntervalSecs, bool bRealTime = false)
        {
            if (call == null)
                return false;

            Scheduler info = m_pScheduler.Find(delegate (Scheduler deleter)
            {
                if (deleter.m_pCallBack == call && !deleter.IsEnd())
                    return true;
                return false;
            });

            if (info != null)
                return false;

            info = m_pBuffScheduler.Find(delegate (Scheduler deleter)
            {
                if (deleter.m_pCallBack == call)
                    return true;
                return false;
            });

            if (info != null)
                return false;

            if (bRealTime)
                m_pBuffScheduler.Add(new SchedulerFixTime(fIntervalSecs, nLoop, call));
            else
                m_pBuffScheduler.Add(new Scheduler(fIntervalSecs, nLoop, call));

            return true;
        }

        public void DelScheduler(CallBack call)
        {
            Scheduler info = m_pScheduler.Find(delegate (Scheduler deleter)
            {
                if (deleter.m_pCallBack == call && !deleter.IsEnd())
                    return true;
                return false;
            });

            if (info != null)
            {
                info.ForceEnd();
            }
        }

        public void Update()
        {
            m_pScheduler.AddRange(m_pBuffScheduler);
            m_pBuffScheduler.Clear();
            foreach (Scheduler scheduler in m_pScheduler)
            {
                scheduler.Update();
            }

            this.GarbageCollection();
        }

        public void GarbageCollection()
        {
            m_pScheduler.RemoveAll(delegate (Scheduler item) { if (item.IsEnd()) return true; return false; });
        }
    }
}
