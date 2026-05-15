using UnityEngine;
using System.Collections;

namespace Rollance
{
    public class WoodRotation : MonoBehaviour
    {
        public enum RotationAxis { X, Y, Z }

        [Header("Select Axis")]
        public RotationAxis axis = RotationAxis.Z;

        [Header("Target Rotation (Degrees)")]
        public float rotationAmount = 30f;

        [Header("Settings")]
        public float rotationSpeed = 2f;
        public string playerTag = "PlayerBall";

        private bool isRotating = false;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(playerTag) && !isRotating)
            {
              //  Debug.Log("✅ Collision Detected");
                StartCoroutine(RotateSmoothly());
            }
        }

        IEnumerator RotateSmoothly()
        {
            isRotating = true;

            float time = 0f;

            Vector3 start = transform.localEulerAngles;
            Vector3 end = start;

            // 🎯 Target = ZERO on selected axis
            switch (axis)
            {
                case RotationAxis.X:
                    end.x = 0f;
                    break;

                case RotationAxis.Y:
                    end.y = 0f;
                    break;

                case RotationAxis.Z:
                    end.z = 0f;
                    break;
            }

            while (time < 1f)
            {
                time += Time.deltaTime * rotationSpeed;

                float x = Mathf.LerpAngle(start.x, end.x, time);
                float y = Mathf.LerpAngle(start.y, end.y, time);
                float z = Mathf.LerpAngle(start.z, end.z, time);

                transform.localEulerAngles = new Vector3(x, y, z);

                yield return null;
            }

            transform.localEulerAngles = end;
        }
    }
}