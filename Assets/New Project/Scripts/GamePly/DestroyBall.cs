using System.Collections;
using UnityEngine;

namespace Rollance
{
    public class DestroyBall : MonoBehaviour
    {
        [Header("Settings")]
        public bool canDestroyBall = false; // default false rakho

        [Header("References")]
        public GameObject objectToEnable;
        public GameObject objectToDisable;
        public SphereCollider ThisBallCollider;

        [Header("Delay")]
        public float destroyDelay = 2f;

        private bool triggered = false;

        // ✅ Method to control from other scripts
        public void SetCanDestroy(bool value)
        {
            canDestroyBall = value;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("PlayerBall")) return;

            if (!canDestroyBall || triggered) return;

            triggered = true;

            if (objectToEnable != null)
                objectToEnable.SetActive(true);

            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
                ThisBallCollider.enabled = false;
            }

            StartCoroutine(DestroyAfterDelay());
        }

        IEnumerator DestroyAfterDelay()
        {
            yield return new WaitForSeconds(destroyDelay);

            if (objectToEnable != null)
            {
                Destroy(objectToEnable);
            }
        }
    }
}