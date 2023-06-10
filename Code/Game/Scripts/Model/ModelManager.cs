using System.Collections.Generic;

namespace Game
{
    public class ModelManager
    {
        private static ModelManager s_instance = null;
        private List<IModel> m_lstModel = new List<IModel>();

        private CharacterModel m_characterModel = new CharacterModel();
        private HeroModel m_heroModel = new HeroModel();
        private GameMapModel m_gameMapModel = new GameMapModel();
        private SystemModel m_systemModel = new SystemModel();

        public CharacterModel character { get { return m_characterModel; } }
        public HeroModel hero { get { return m_heroModel; } }
        public GameMapModel gameMap { get { return m_gameMapModel; } }
        public SystemModel system { get { return m_systemModel; } }

        public static ModelManager Instance()
        {
            if (s_instance == null)
            {
                s_instance = new ModelManager();
            }
            return s_instance;
        }

        public void Init()
        {
            m_lstModel.Add(character);
            m_lstModel.Add(hero);
            m_lstModel.Add(gameMap);
            m_lstModel.Add(system);
            foreach (IModel model in m_lstModel)
            {
                model.Init();
            }
        }
    }
}
