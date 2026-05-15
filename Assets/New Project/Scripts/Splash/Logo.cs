using UnityEngine;
using System.Collections;

namespace Rollance
{
    public class Logo : MonoBehaviour
    {
        public RectTransform target; // UI Image
        public float duration = 0.1f;


        private void OnEnable()
        {
            target.localScale = Vector3.zero;
            StartCoroutine(AnimateScale());
        }
    

        IEnumerator AnimateScale()
        {
            // ⏳ Delay
         

            float time = 0f;

            Vector3 startScale = Vector3.zero;
            Vector3 endScale = Vector3.one * 1.3f;

            while (time < duration)
            {
                float t = time / duration;

                // Smooth feel (optional but recommended)
                t = Mathf.SmoothStep(0f, 1f, t);

                target.localScale = Vector3.Lerp(startScale, endScale, t);

                time += Time.deltaTime;
                yield return null;
            }

            target.localScale = endScale;
        }
    }
}
