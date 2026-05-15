using System.Collections;
using UnityEngine;

namespace Rollance
{
    public class CoinsFlyAnimation : MonoBehaviour
    {
        public RectTransform target;
        public float moveDuration = 0.5f;
        public float delayBetweenCoins = 0.1f;

        public static CoinsFlyAnimation Instance;

        private Vector3[] originalPositions;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            // ✅ Save original positions once
            originalPositions = new Vector3[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                originalPositions[i] = transform.GetChild(i).GetComponent<RectTransform>().position;
            }
        }

        public void PlayAnimation()
        {
            SoundManager.Instance.Play_AddCoins();

            // ✅ Reset + Enable coins
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform coin = transform.GetChild(i);

                coin.gameObject.SetActive(true);

                RectTransform rt = coin.GetComponent<RectTransform>();
                rt.position = originalPositions[i]; // 🔥 RESET POSITION
            }

            StartCoroutine(AnimateCoins());
        }

        IEnumerator AnimateCoins()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                RectTransform coin = transform.GetChild(i).GetComponent<RectTransform>();

                if (coin != null)
                {
                    StartCoroutine(MoveCoin(coin));
                }

                yield return new WaitForSeconds(delayBetweenCoins);
            }
        }

        IEnumerator MoveCoin(RectTransform coin)
        {
            Vector3 startPos = coin.position;
            Vector3 endPos = target.position;

            float time = 0f;

            while (time < moveDuration)
            {
                float t = Mathf.SmoothStep(0, 1, time / moveDuration);
                coin.position = Vector3.Lerp(startPos, endPos, t);

                time += Time.deltaTime;
                yield return null;
            }

            coin.position = endPos;
            coin.gameObject.SetActive(false);
        }
    }
}