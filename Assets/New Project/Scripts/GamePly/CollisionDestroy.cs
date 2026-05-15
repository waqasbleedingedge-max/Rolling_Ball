using UnityEngine;


namespace Rollance
{

    public class CollisionDestroy : MonoBehaviour
    {
        public string enemyTag = "Enemy";

        [Header("Break Effect")]
        public GameObject brokenPrefab; // sliced/broken mesh prefab
        public bool destroyCompletely = true; // true = Destroy, false = SetActive(false)

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(enemyTag))
            {
                BreakObject();
            }
        }

        void BreakObject()
        {
            // 💥 Spawn sliced/broken version
            if (brokenPrefab != null)
            {
                Instantiate(brokenPrefab, transform.position, transform.rotation);
            }

            // ❌ Remove original object
            if (destroyCompletely)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}