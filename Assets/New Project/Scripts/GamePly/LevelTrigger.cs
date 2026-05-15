using UnityEngine;
namespace Rollance
{

    public class LevelTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("PlayerBall"))
            {
                SoundManager.Instance.Play_WinSound();
                Invoke(nameof(Delay), 1.5f);
            }
        }

        void Delay()
        {
            GameManager.Instance.LevelComplete();
        }
    }
}
