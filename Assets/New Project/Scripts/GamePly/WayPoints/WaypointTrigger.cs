using UnityEngine;

namespace Rollance
{
    public class WaypointTrigger : MonoBehaviour
    {
        public int waypointIndex;
        public WaypointManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerBall"))
            {
                //manager.SetWaypoint(waypointIndex);

                //Debug.Log("✅ Reached Waypoint: " + waypointIndex);

                // 👉 Yahan tum future me:
                // Sound play
                // Camera change
                // Save progress
            }
        }
    }
}