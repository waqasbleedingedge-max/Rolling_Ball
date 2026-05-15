using UnityEngine;
using UnityEngine.UI;

namespace Rollance
{
    public class WaypointManager : MonoBehaviour
    {
        public Transform player;
        public Transform[] waypoints;
        public Slider slider;

        [Header("Smooth Settings")]
        public float smoothSpeed = 5f;

        [Header("Reverse Control")]
        [Tooltip("Kitna reverse allow ho (negative value)")]
        public float reverseThreshold = -0.02f;

        private float totalPathDistance;
        private float targetValue;
        private bool initialized = false;

        //private void OnEnable()
        //{
        //    GameManager.OnLevelStart += ResetData;
        //}
        //private void OnDisable()
        //{
        //    GameManager.OnLevelStart -= ResetData;

        //}

        void Awake()
        {
            // 🔹 Player auto find
            if (player == null)
            {
                GameObject p = GameObject.FindGameObjectWithTag("PlayerBall");
                if (p != null)
                    player = p.transform;
                else
                    Debug.LogError("❌ PlayerBall tag not found!");
            }

            // 🔹 Slider auto find
            if (slider == null)
            {
                GameObject s = GameObject.FindGameObjectWithTag("ProgressSlider");

                if (s != null)
                    slider = s.GetComponent<Slider>();
                else
                    Debug.LogError("❌ ProgressSlider tag not found!");
            }

            CalculateTotalDistance();

            // ✅ Start from 0
            if (slider != null)
                slider.value = 0f;

            targetValue = 0f;
        }


        //void ResetData()
        //{
        //    // 🔹 Player auto find
        //    if (player == null)
        //    {
        //        GameObject p = GameObject.FindGameObjectWithTag("PlayerBall");
        //        if (p != null)
        //            player = p.transform;
        //        else
        //            Debug.LogError("❌ PlayerBall tag not found!");
        //    }

        //    // 🔹 Slider auto find
        //    if (slider == null)
        //    {
        //        GameObject s = GameObject.FindGameObjectWithTag("ProgressSlider");

        //        if (s != null)
        //            slider = s.GetComponent<Slider>();
        //        else
        //            Debug.LogError("❌ ProgressSlider tag not found!");
        //    }

        //    CalculateTotalDistance();

        //    // ✅ Start from 0
        //    if (slider != null)
        //        slider.value = 0f;

        //    targetValue = 0f;
        //}

        void SetupWaypoints()
        {
            int count = transform.childCount;

            waypoints = new Transform[count];

            for (int i = 0; i < count; i++)
            {
                Transform child = transform.GetChild(i);
                waypoints[i] = child;

                // 🔹 Add / Get WaypointTrigger
                WaypointTrigger trigger = child.GetComponent<WaypointTrigger>();

                if (trigger == null)
                {
                    trigger = child.gameObject.AddComponent<WaypointTrigger>();
                }

                // 🔹 Assign values
                trigger.waypointIndex = i;
                trigger.manager = this;

                // 🔹 Ensure collider is trigger
                Collider col = child.GetComponent<Collider>();
                if (col != null)
                {
                    col.isTrigger = true;
                }
                else
                {
                    Debug.LogWarning($"⚠️ No Collider on {child.name}");
                }
            }
        }

        void Update()
        {
            // 🔒 First frame fix
            if (!initialized)
            {
                initialized = true;
                slider.value = 0f;
                targetValue = 0f;
                return;
            }

            UpdateProgress();

            // 🎯 Smooth movement
            slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * smoothSpeed);
        }

        void CalculateTotalDistance()
        {
            totalPathDistance = 0f;

            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                totalPathDistance += Vector3.Distance(
                    waypoints[i].position,
                    waypoints[i + 1].position
                );
            }
        }

        void UpdateProgress()
        {
            float coveredDistance = 0f;

            float minDistance = float.MaxValue;
            int closestSegmentIndex = 0;
            float projectionOnSegment = 0f;

            // 🔍 Find closest segment
            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                Vector3 A = waypoints[i].position;
                Vector3 B = waypoints[i + 1].position;

                Vector3 AB = B - A;
                Vector3 AP = player.position - A;

                float segmentLength = AB.magnitude;
                Vector3 AB_dir = AB.normalized;

                float projection = Vector3.Dot(AP, AB_dir);
                projection = Mathf.Clamp(projection, 0f, segmentLength);

                Vector3 closestPoint = A + AB_dir * projection;
                float distanceToSegment = Vector3.Distance(player.position, closestPoint);

                if (distanceToSegment < minDistance)
                {
                    minDistance = distanceToSegment;
                    closestSegmentIndex = i;
                    projectionOnSegment = projection;
                }
            }

            // ➕ Add previous segments
            for (int i = 0; i < closestSegmentIndex; i++)
            {
                coveredDistance += Vector3.Distance(
                    waypoints[i].position,
                    waypoints[i + 1].position
                );
            }

            // ➕ Add current segment progress
            coveredDistance += projectionOnSegment;

            float newValue = coveredDistance / totalPathDistance;
            newValue = Mathf.Clamp01(newValue);

            // 🧠 Smart Hybrid Logic
            float diff = newValue - targetValue;

            if (diff > 0f) // forward always allowed
            {
                targetValue = newValue;
            }
            else if (diff < reverseThreshold) // reverse only if significant
            {
                targetValue = newValue;
            }
        }

        // 🔄 Optional Reset (Level Restart)
        public void ResetProgress()
        {
            targetValue = 0f;

            if (slider != null)
                slider.value = 0f;
        }
    }
}