using UnityEngine;

namespace OpenWorld
{
    /// <summary>
    /// Sends a ray from the center of the camera, in the game world.
    /// It gathers data about what is in front of the player, and stores it in a variable.
    /// </summary>
    public class RayCastManager : PlayerBehaviour
    {

        private Camera m_WorldCamera;

        [SerializeField]
        [Tooltip("The maximum distance at which you can interact with objects.")]
        private float m_RayLength = 1.5f;

        [SerializeField]
        [Tooltip("The distance at which an object is considered 'too close'.")]
        private float m_TooCloseThreeshold = 1f;

        [SerializeField]
        private LayerMask m_LayerMask;

        private void Start()
        {
            m_WorldCamera = Player.PlayerCamera.GetComponent<Camera>();
        }

        private void Update()
        {
            var ray = m_WorldCamera.ViewportPointToRay(Vector2.one * 0.5f);
            RaycastHit hitInfo;
            var lastRaycastData = Player.RaycastData.Get();

            if (Physics.Raycast(ray, out hitInfo, m_RayLength, m_LayerMask, QueryTriggerInteraction.Collide))
            {
                Player.RaycastData.Set(hitInfo);
            }
        }
    }
}
