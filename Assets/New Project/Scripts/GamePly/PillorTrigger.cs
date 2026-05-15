using UnityEngine;
using System;

namespace Rollance
{
    public class PillorTrigger : MonoBehaviour
    {
        public static Action<Transform, Material> BallSwitch;
        public static Action<Vector3, Quaternion> SetCam_Position_And_Rotation;

        private bool entered = false;

        public Transform SetPosition;
        public Material Assign_material;

        public GameObject CameraPositionRotation;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerBall") && !entered)
            {
                entered = true;

                // Ball + Material
                BallSwitch?.Invoke(SetPosition, Assign_material);

                // ✅ Camera position + rotation
                if (CameraPositionRotation != null)
                {
                    SetCam_Position_And_Rotation?.Invoke(
                        CameraPositionRotation.transform.position,
                        CameraPositionRotation.transform.rotation
                    );
                }

                if (SetPosition != null)
                    SetPosition.gameObject.SetActive(false);


                FindObjectOfType<DestroyBall>().SetCanDestroy(true);
            }
        }
    }
}