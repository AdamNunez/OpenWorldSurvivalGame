using UnityEngine;

namespace OpenWorld
{
    public class EntityBehaviour : Bolt.EntityBehaviour<IPlayerState>
    {
        public EntityEventHandler Entity
        {
            get
            {
                if (!m_Entity)
                    m_Entity = GetComponent<EntityEventHandler>();
                if (!m_Entity)
                    m_Entity = GetComponentInParent<EntityEventHandler>();

                return m_Entity;
            }
        }

        private EntityEventHandler m_Entity;
    }
}
