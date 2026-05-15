using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rollance
{

    public class GlobalBallManager : MonoBehaviour
    {
        public static GlobalBallManager Instance;

        [Header("Ball")]
        public Transform ball;

        [Header("Camera")]
        public Transform cam;

        [Header("All Levels Spawn Data")]
        public List<LevelSpawnData> levels = new List<LevelSpawnData>();

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
        }

        public void SetBallStartPosition(int levelIndex)
        {
            if (levels == null || levels.Count == 0)
            {
                Debug.LogError("❌ Levels list is empty!");
                return;
            }

            if (levelIndex >= levels.Count)
            {
                Debug.LogError("❌ Invalid level index!");
                return;
            }

            LevelSpawnData data = levels[levelIndex];

            if (data == null || data.ballPoint == null || data.cameraPoint == null)
            {
                Debug.LogError("❌ Missing spawn references!");
                return;
            }

            // ✅ BALL
            if (ball != null)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.isKinematic = true;

                ball.SetPositionAndRotation(data.ballPoint.position, data.ballPoint.rotation);

                Physics.SyncTransforms();

                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }

            // 🎥 CAMERA (delayed to avoid override)
            StartCoroutine(SetCameraAfterSpawn(data));
        }

        IEnumerator SetCameraAfterSpawn(LevelSpawnData data)
        {
            yield return null;

            if (cam != null)
            {
                cam.SetParent(null);
                cam.SetPositionAndRotation(data.cameraPoint.position, data.cameraPoint.rotation);

                SmoothFollowPro follow = cam.GetComponent<SmoothFollowPro>();
                if (follow != null)
                {
                    follow.ResetCameraInstant();
                }
            }
        }
    }

    [System.Serializable]
    public class LevelSpawnData
    {
        public Transform ballPoint;
        public Transform cameraPoint;
    }


}