using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class GameMapModel : IModel
    {
        //英雄
        private Dictionary<int, Vector2Int> m_dicPlayerPos = new Dictionary<int, Vector2Int>();

        //敌人
        private Dictionary<int, Vector2Int> m_dicEnemyPos = new Dictionary<int, Vector2Int>();

        public void Reset()
        {
            m_dicPlayerPos.Clear();
            m_dicEnemyPos.Clear();
        }

        public void SetPlayerPos(int idHero, Vector2Int v2Pos)
        {
            if (m_dicPlayerPos.ContainsKey(idHero))
            {
                m_dicPlayerPos[idHero] = v2Pos;
            }
            else
            {
                m_dicPlayerPos.Add(idHero, v2Pos);
            }
        }

        public void SetEnemyPos(int idEnemy, Vector2Int v2Pos)
        {
            if (m_dicEnemyPos.ContainsKey(idEnemy))
            {
                m_dicEnemyPos[idEnemy] = v2Pos;
            }
            else
            {
                m_dicEnemyPos.Add(idEnemy, v2Pos);
            }
        }

        public int GetPlayerByPos(Vector2Int v2Pos)
        {
            foreach (var va in m_dicPlayerPos)
            {
                if (va.Value == v2Pos)
                {
                    return va.Key;
                }
            }
            return -1;
        }

        public int GetEnemyByPos(Vector2Int v2Pos)
        {
            foreach (var va in m_dicEnemyPos)
            {
                if (va.Value == v2Pos)
                {
                    return va.Key;
                }
            }
            return -1;
        }
    }
}
