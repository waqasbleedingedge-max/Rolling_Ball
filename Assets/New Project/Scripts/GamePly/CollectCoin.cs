using UnityEngine;

namespace Rollance
{
    public class CollectCoin : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("PlayerBall"))
            {
                CoinsManager.Instance.AddCoins(10);
                SoundManager.Instance.Play_PickCoin();
                Invoke(nameof(End), 0.1f);
            }
        }

        private void End()
        {
            Destroy(this.gameObject);
        }

    }
}