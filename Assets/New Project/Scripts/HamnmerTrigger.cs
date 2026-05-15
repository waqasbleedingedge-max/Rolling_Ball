using UnityEngine;

namespace Rollance
{
    public class HamnmerTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("PlayerBall"))
            {
                SoundManager.Instance.Play_Hammer();
          }
        }
    }
}