using UnityEngine;

namespace OpenWorld.EventSystem
{
    public class PlayerEventHandler : EntityEventHandler
    {
        public Movement movement;
        public GameObject PlayerCamera;
        public Inventory Inventory;

        public Value<Vector2> MovementInput = new Value<Vector2>(Vector2.zero);
        public Value<Vector2> MouseInput = new Value<Vector2>(Vector2.zero);
        public Value<RaycastHit> RaycastData = new Value<RaycastHit>(new RaycastHit());
        public Attempt Interact = new Attempt();

    }

}


      