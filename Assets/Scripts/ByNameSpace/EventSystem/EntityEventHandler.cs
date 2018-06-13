using OpenWorld.EventSystem;
using UnityEngine;

namespace OpenWorld
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityEventHandler : MonoBehaviour
    {
        /// <summary></summary>
        public Value<float> Health = new Value<float>(100f);

        /// <summary> </summary>
        public Value<bool> IsGrounded = new Value<bool>(true);

        /// <summary> </summary>
        public Value<Vector3> Velocity = new Value<Vector3>(Vector3.zero);

        /// <summary> </summary>
        public Value<float> VerticalSpeed = new Value<float>(0f);

        ///// <summary> </summary>
        //public Message<float> Land = new Message<float>();

        ///// <summary></summary>
        //public Message Death = new Message();

        ///// <summary></summary>
        //public Message Respawn = new Message();
    }
}
