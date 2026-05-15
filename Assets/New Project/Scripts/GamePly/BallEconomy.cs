using UnityEngine;


namespace Rollance
{
    public class BallEconomyController : MonoBehaviour
    {
        [Header("Ball Renderer")]
        public Renderer ballRenderer;

        [Header("Materials")]
        public Material[] materials;

        public static int currentIndex = 0;
        private string saveKey = "BallMaterial";

        public static BallEconomyController Instance;

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            LoadMaterial();
        }

        // 🎨 APPLY MATERIAL
        void ApplyMaterial()
        {
            if (ballRenderer == null || materials.Length == 0) return;

            ballRenderer.material = materials[currentIndex];
        }

        // ▶️ NEXT MATERIAL (Button)
        public void NextMaterial()
        {
            currentIndex++;

            if (currentIndex >= materials.Length)
                currentIndex = 0;

            ApplyMaterial();
            SaveMaterial();
        }

        // ⬅️ PREVIOUS MATERIAL (Button)
        public void PreviousMaterial()
        {
            currentIndex--;

            if (currentIndex < 0)
                currentIndex = materials.Length - 1;

            ApplyMaterial();
            SaveMaterial();
        }

        // 💾 SAVE
        void SaveMaterial()
        {
            PlayerPrefs.SetInt(saveKey, currentIndex);
            PlayerPrefs.Save();
        }

        // 🔄 LOAD
        void LoadMaterial()
        {
            if (materials.Length == 0) return;

            currentIndex = PlayerPrefs.GetInt(saveKey, 0);

            if (currentIndex >= materials.Length)
                currentIndex = 0;

            ApplyMaterial();
        }
    }

}