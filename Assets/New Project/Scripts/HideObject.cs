using UnityEngine;

namespace Rollance
{
    public class HideObject : MonoBehaviour
    {
        public float HideTime = 2f;

        private void OnEnable()
        {
            Invoke(nameof(OffObject), HideTime);
        }

        void OffObject()
        {
            gameObject.SetActive(false);
        }
    }
}

