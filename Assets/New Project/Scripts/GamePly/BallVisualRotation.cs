using UnityEngine;

namespace Rollance
{


    public class BallVisualRotation : MonoBehaviour
    {
        public Rigidbody rb;
        public float rotationMultiplier = 5f;

        void Update()
        {
            if (rb == null) return;

            Vector3 velocity = rb.linearVelocity;

            if (velocity.magnitude > 0.1f)
            {
                // 🔥 rotation axis (real rolling direction)
                Vector3 rotationAxis = Vector3.Cross(Vector3.up, velocity.normalized);

                // 🔥 rotate mesh
                transform.Rotate(
                    rotationAxis,
                    velocity.magnitude * rotationMultiplier * Time.deltaTime,
                    Space.World
                );
            }
        }
    }
}