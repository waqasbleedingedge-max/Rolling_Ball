using UnityEngine;
using System.Collections;

namespace Rollance
{
    public class SmoothFollowPro : MonoBehaviour
    {
        public Transform target;
        private Rigidbody rb;

        [Header("Distance Settings")]
        public float distance = 6.5f;
        public float height = 3f;

        [Header("Smooth Settings")]
        public float rotationSmoothTime = 0.2f;
        public float heightDamping = 5f;
        public float positionDamping = 0.1f;

        [Header("Rotation Settings")]
        public float rotationThreshold = 0.5f;
        public float velocitySmoothSpeed = 5f;

        [Header("Look Settings")]
        public float lookAheadDistance = 2f;
        public float lookHeightOffset = 1.2f;

        [Header("Start Settings")]
        public float followDelay = 0.3f;

        [Header("Economy Mode")]
        public static bool IsEconmyActive = false;

        [Header("Orbit Settings")]
        public float orbitSpeed = 60f;
        public float orbitHeight = 6f;

        [Header("FOV Settings")]
        public Camera cam;
        public float normalFOV = 60f;
        public float backFOV = 70f;
        public float fovSmoothTime = 0.3f;

        [Header("Trigger Camera Settings")]
        public float returnDelay = 2f;

        private Vector3 velocity = Vector3.zero;
        private Vector3 smoothMoveDir;
        private Vector3 lastMoveDir;

        private float currentRotationAngle;
        private float rotationVelocity;
        private float timer = 0f;

        private float currentTargetFOV;
        private float fovVelocity;

        private bool stopFollow = false;
        private Coroutine triggerCamRoutine;

        private void OnEnable()
        {
            PillorTrigger.SetCam_Position_And_Rotation += SetCameraPositionAndRotation;
        }

        private void OnDisable()
        {
            PillorTrigger.SetCam_Position_And_Rotation -= SetCameraPositionAndRotation;
        }

        void Start()
        {
            if (target != null)
                rb = target.GetComponent<Rigidbody>();

            currentRotationAngle = transform.eulerAngles.y;

            Vector3 forward = transform.forward;
            lastMoveDir = new Vector3(forward.x, 0, forward.z).normalized;

            if (cam != null)
                currentTargetFOV = cam.fieldOfView;
        }

        void LateUpdate()
        {
            if (!target || stopFollow) return;

            if (IsEconmyActive)
            {
                HandleOrbitMode();
                return;
            }

            HandleFollowMode();
        }

        private void SetCameraPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            if (triggerCamRoutine != null)
                StopCoroutine(triggerCamRoutine);

            triggerCamRoutine = StartCoroutine(TriggerCameraRoutine(position, rotation));
        }



        private IEnumerator TriggerCameraRoutine(Vector3 targetPos, Quaternion targetRot)
        {
            //Debug.Log("🎬 TriggerCameraRoutine START");

            stopFollow = true;
            //Debug.Log("stopFollow TRUE");

            float goDuration = 1.5f;
            float time = 0f;

            Vector3 startPos = transform.position;
            Quaternion startRot = transform.rotation;

            //Debug.Log("Start Position: " + startPos);
            //Debug.Log("Target Position: " + targetPos);
            //Debug.Log("Start Rotation: " + startRot.eulerAngles);
            //Debug.Log("Target Rotation: " + targetRot.eulerAngles);
            //Debug.Log("Distance Start To Target: " + Vector3.Distance(startPos, targetPos));

            while (time < goDuration)
            {
                time += Time.deltaTime;

                float rawT = Mathf.Clamp01(time / goDuration);
                float smoothT = rawT * rawT * (3f - 2f * rawT);

                transform.position = Vector3.Lerp(startPos, targetPos, smoothT);
                transform.rotation = Quaternion.Slerp(startRot, targetRot, smoothT);

                //Debug.Log(
                //    "Moving To Trigger | Time: " + time +
                //    " | T: " + smoothT +
                //    " | Pos: " + transform.position +
                //    " | Distance Left: " + Vector3.Distance(transform.position, targetPos)
                //);

                yield return null;
            }

            //Debug.Log("✅ Reached Trigger Camera Position");
            //Debug.Log("Current Position After Move: " + transform.position);
            //Debug.Log("Current Rotation After Move: " + transform.eulerAngles);

            //Debug.Log("⏸ Waiting returnDelay: " + returnDelay);
            yield return new WaitForSeconds(returnDelay);

            //Debug.Log("🔁 Preparing To Resume Follow");

            velocity = Vector3.zero;
            smoothMoveDir = Vector3.zero;
            rotationVelocity = 0f;
            fovVelocity = 0f;

            //Debug.Log("Velocity Reset: " + velocity);
            //Debug.Log("SmoothMoveDir Reset: " + smoothMoveDir);
            //Debug.Log("RotationVelocity Reset: " + rotationVelocity);
            //Debug.Log("FovVelocity Reset: " + fovVelocity);

            currentRotationAngle = transform.eulerAngles.y;   //yaha issue hai



            Vector3 forward = transform.forward;
            lastMoveDir = new Vector3(forward.x, 0, forward.z).normalized;

            //Debug.Log("Current Rotation Angle Set: " + currentRotationAngle);
            //Debug.Log("Forward: " + forward);
            //Debug.Log("Last Move Dir Set: " + lastMoveDir);

            timer = followDelay;
            //Debug.Log("Timer Set To FollowDelay: " + timer);

            //Debug.Log("⚠️ stopFollow FALSE now - next frame HandleFollowMode will run");
            //Debug.Log("Camera Position Before Follow Resume: " + transform.position);
            //Debug.Log("Camera Rotation Before Follow Resume: " + transform.eulerAngles);

            stopFollow = false;

            yield return null;

            //Debug.Log("✅ One frame after follow resume");
            //Debug.Log("Camera Position After Resume Frame: " + transform.position);
            //Debug.Log("Camera Rotation After Resume Frame: " + transform.eulerAngles);

            triggerCamRoutine = null;

            //Debug.Log("🎬 TriggerCameraRoutine END");
        }




        void HandleFollowMode()
        {
            timer += Time.deltaTime;
            if (timer < followDelay)
                return;

            Vector3 moveDir = rb != null ? rb.linearVelocity : Vector3.zero;

            smoothMoveDir = Vector3.Lerp(
                smoothMoveDir,
                moveDir,
                velocitySmoothSpeed * Time.deltaTime
            );

            float targetAngle = currentRotationAngle;

            if (smoothMoveDir.sqrMagnitude > rotationThreshold)
            {
                lastMoveDir = smoothMoveDir;
                targetAngle = Mathf.Atan2(lastMoveDir.x, lastMoveDir.z) * Mathf.Rad2Deg;
            }

            currentRotationAngle = Mathf.SmoothDampAngle(
                currentRotationAngle,
                targetAngle,
                ref rotationVelocity,
                rotationSmoothTime
            );

            Quaternion rotation = Quaternion.Euler(0, currentRotationAngle, 0);

            Vector3 desiredPosition = target.position - rotation * Vector3.forward * distance;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                desiredPosition,
                ref velocity,
                positionDamping
            );

            float wantedHeight = target.position.y + height;

            transform.position = new Vector3(
                transform.position.x,
                Mathf.Lerp(transform.position.y, wantedHeight, heightDamping * Time.deltaTime),
                transform.position.z
            );

            Vector3 lookPos = target.position
                            + Vector3.up * lookHeightOffset
                            + rotation * Vector3.forward * lookAheadDistance;

            transform.LookAt(lookPos);

            AdjustFOV();
        }

        void AdjustFOV()
        {
            if (cam == null) return;

            Vector3 camForward = transform.forward;
            Vector3 targetForward = lastMoveDir.normalized;

            float dot = Vector3.Dot(camForward, targetForward);

            if (dot < -0.4f)
                currentTargetFOV = backFOV;
            else if (dot > -0.2f)
                currentTargetFOV = normalFOV;

            cam.fieldOfView = Mathf.SmoothDamp(
                cam.fieldOfView,
                currentTargetFOV,
                ref fovVelocity,
                fovSmoothTime
            );
        }

        void HandleOrbitMode()
        {
            currentRotationAngle += orbitSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0, currentRotationAngle, 0);

            Vector3 pos = target.position - rotation * Vector3.forward * distance;

            pos.y = Mathf.Lerp(transform.position.y, orbitHeight, 3f * Time.deltaTime);

            transform.position = pos;

            transform.LookAt(target.position + Vector3.up * lookHeightOffset);
        }

        public void ResetCameraInstant()
        {
            currentRotationAngle = transform.eulerAngles.y;

            Vector3 forward = transform.forward;
            lastMoveDir = new Vector3(forward.x, 0, forward.z).normalized;

            smoothMoveDir = Vector3.zero;
            velocity = Vector3.zero;
            rotationVelocity = 0f;

            timer = followDelay;

            if (cam != null)
                cam.fieldOfView = normalFOV;
        }

        public void ActivateEconomyMode()
        {
            IsEconmyActive = true;
        }

        public void DeactivateEconomyMode()
        {
            IsEconmyActive = false;

            timer = 0f;

            Vector3 forward = transform.forward;
            lastMoveDir = new Vector3(forward.x, 0, forward.z).normalized;
        }
    }
}