using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class CharacterModel : IModel
    {
        private int m_nHp = 0;
        public int hp { get { return m_nHp; } }
    }
}
