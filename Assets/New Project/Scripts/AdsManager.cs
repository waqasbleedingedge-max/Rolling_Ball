using UnityEngine;

namespace Rollance
{
    public class AdsManager : MonoBehaviour
    {
        public static AdsManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public bool IsAdsRemoved()
        {
            return PlayerPrefs.GetInt("RemoveAds", 0) == 1;
        }

        public void DisableAds()
        {
            Debug.Log("Ads Disabled!");
        }

        public void ShowAd()
        {
            if (IsAdsRemoved()) return;

            Debug.Log("Showing Ad...");
        }
    }
}