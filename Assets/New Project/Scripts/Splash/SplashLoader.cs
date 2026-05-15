using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

namespace Rollance
{
    public class Loader : MonoBehaviour
    {
        public Image progressImage;
        public Text progressText;
        public string sceneName = "GameScene";

        [Header("Loading Time")]
        public float loadingDuration = 7f; // ⏳ total loading time

        void Start()
        {
            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            float timer = 0f;

            while (timer < loadingDuration)
            {
                timer += Time.deltaTime;

                float progress = Mathf.Clamp01(timer / loadingDuration);

                // UI update
                progressImage.fillAmount = progress;

                if (progressText != null)
                {
                    progressText.text = "Loading " + Mathf.RoundToInt(progress * 100f) + "%";
                }

                yield return null;
            }

            // Ensure scene is ready
            while (operation.progress < 0.9f)
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);
            operation.allowSceneActivation = true;
        }
    }
}