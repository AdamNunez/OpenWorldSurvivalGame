using UnityEngine;

namespace OpenWorld
{
    public class PlayerEventHandler : EntityEventHandler
    {
        public Value<Vector2> MovementInput = new Value<Vector2>(Vector2.zero);
    }
}


      