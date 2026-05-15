using UnityEngine;

namespace Rollance
{
    public class LevelFailed_WaterTrigger : MonoBehaviour
    {
        //public ParticleSystem WaterEffect;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerBall"))
            {
                // 💥 Spawn particle at hit position
                //if (WaterEffect != null)
                //{
                //    WaterEffect.gameObject.SetActive(true);
                // //   WaterEffect.Play();
                //}
                SoundManager.Instance.Play_FailedSound();
                Invoke(nameof(Delay), 0.5f);
            }
        }

        void Delay()
        {
            GameManager.Instance.LevelFailed();
        }
    }

}