using UnityEngine;
using System.Collections;


namespace Rollance
{
    public class CollectKey : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] private GameObject shineEffect;
        [SerializeField] private GameObject keyObject;

        [Header("Timings")]
        [SerializeField] private float collectDelay = 0.1f;
        [SerializeField] private float shineDelay = 0.5f;

        private bool isCollected = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("PlayerBall") || isCollected) return;
            
            
         
            StartCoroutine(CollectRoutine());
        }

        private IEnumerator CollectRoutine()
        {
            isCollected = true;
            SoundManager.Instance.Play_Collect();

            CoinsManager.Instance.AddCoins(10);

            yield return new WaitForSeconds(collectDelay);

            if (shineEffect != null) shineEffect.SetActive(true);
            if (keyObject != null) keyObject.SetActive(false);

            yield return new WaitForSeconds(shineDelay);

            gameObject.SetActive(false); // or Destroy(gameObject);
        }
    }

}

