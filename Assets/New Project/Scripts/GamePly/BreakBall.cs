using UnityEngine;


namespace Rollance
{
    public class BreakBall : MonoBehaviour
    {
        public bool CanBreak;
        public string Tag = "PlayerBall";



        private void OnCollisionEnter(Collision collision)
        {
            if(CanBreak && collision.transform.CompareTag(Tag))
            {

            }

        }



    }

}
