using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    [Serializable]
    public class EnemyInfo
    {
        public int idEnemy = 0;
        public int idHero = 0;
    }

    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "AssetConfig/Enemy", order = 1)]
    public class EnemyConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        public EnemyInfo[] m_szEnemyInfo = null;
        private Dictionary<int, EnemyInfo> m_dicEnemyInfo = new Dictionary<int, EnemyInfo>();

        public void OnAfterDeserialize()
        {
            m_dicEnemyInfo.Clear();
            if (m_szEnemyInfo != null)
            {
                foreach (EnemyInfo enemyInfo in m_szEnemyInfo)
                {
                    if (!m_dicEnemyInfo.ContainsKey(enemyInfo.idEnemy))
                    {
                        m_dicEnemyInfo.Add(enemyInfo.idEnemy, enemyInfo);
                    }
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public EnemyInfo GetEnemyInfo(int idEnemy)
        {
            if (m_dicEnemyInfo.ContainsKey(idEnemy))
            {
                return m_dicEnemyInfo[idEnemy];
            }
            return null;
        }
    }
}
