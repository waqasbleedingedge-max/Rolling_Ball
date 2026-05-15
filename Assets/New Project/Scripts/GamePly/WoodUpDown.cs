using UnityEngine;

namespace Rollance
{
    public class WoodUpDown : MonoBehaviour
    {
        [Header("Local Y Positions")]
        public float downY = 0f;
        public float upY = 3f;

        [Header("Settings")]
        public float speed = 2f;
        public float waitTime = 0.5f;

        private bool movingUp = true;
        private float waitTimer = 0f;

        void Update()
        {
            Vector3 localPos = transform.localPosition;
            float targetY = movingUp ? upY : downY;

            // ⏸️ Wait at endpoints
            if (Mathf.Abs(localPos.y - targetY) < 0.01f)
            {
                waitTimer += Time.deltaTime;

                if (waitTimer >= waitTime)
                {
                    movingUp = !movingUp; // direction change
                    waitTimer = 0f;
                }

                return; // stop movement during wait
            }

            // 🔼🔽 Smooth movement (LOCAL Y)
            float newY = Mathf.MoveTowards(localPos.y, targetY, speed * Time.deltaTime);
            transform.localPosition = new Vector3(localPos.x, newY, localPos.z);
        }
    }
}