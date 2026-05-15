using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rollance
{
    public class RollingBallController : MonoBehaviour
    {
        [Header("Movement")]
        public float torquePower = 15f;
        public Camera mainCamera;

        [Tooltip("Left-right swipe torque multiplier")]
        public float horizontalTorqueMultiplier = 0.3f;

        [Tooltip("Up-down swipe torque multiplier")]
        public float verticalTorqueMultiplier = 1f;

        [Header("Jump")]
        public float jumpForce = 7f;
        public LayerMask groundLayer;
        public float groundCheckDistance = 0.6f;

        [Header("Physics Material Settings")]
        public PhysicsMaterial ballMaterial;
        public float dynamicFriction = 0f;
        public float staticFriction = 0f;
        public float bounciness = 0f;

        private Rigidbody rb;
        private Vector2 lastTouchPosition;
        private bool isDragging = false;


        private bool hasStartedMoving = false;

        public static Action FirstClick;
        public bool EnableController = true;

        public List<GameObject> DestroyBall;

        public Rigidbody rg;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            // Apply Physics Material values from Inspector
            ApplyPhysicsMaterial();
        }

        private void OnEnable()
        {
            PillorTrigger.BallSwitch += BallSwitch;
        }
        private void OnDisable()
        {
            PillorTrigger.BallSwitch -= BallSwitch;

        }

        void BallSwitch(Transform pos, Material Assign_material)
        {
            int index = BallEconomyController.currentIndex;

            if (DestroyBall == null || index >= DestroyBall.Count) return;

            GameObject prefab = DestroyBall[index];
            if (prefab == null) return;

            transform.position = pos.position;

            
            EnableController = false;
            rg.isKinematic = true;


            Transform child = transform.GetChild(0);
            var mesh = child.GetComponent<MeshRenderer>();

            // Hide mesh
            if (mesh != null) mesh.enabled = false;

            // Spawn effect
            GameObject spawnedObj = Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(spawnedObj, 2f);

            // Show mesh
            if (mesh != null) mesh.enabled = true;

            // Switch material
           // BallEconomyController.Instance.NextMaterial();



            child.GetComponent<MeshRenderer>().material = Assign_material;

            // Reset parent transform
            transform.rotation = Quaternion.identity;

            // ✅ Reset CHILD transform (this was missing)
            child.localPosition = Vector3.zero;
            child.localRotation = Quaternion.identity;

            // Disable controller


            // Kill previous tweens
            child.DOKill();

            Sequence seq = DOTween.Sequence();

            // Move to Y = -1
            seq.Append(child.DOLocalMoveY(-1f, 1f)
                .SetEase(Ease.InOutSine));

            // Move back to Y = 0
            seq.Append(child.DOLocalMoveY(0f, 1f)
                .SetEase(Ease.InOutSine));

            // Enable controller after animation
            seq.OnComplete(() =>
            {
                EnableController = true;
                rg.isKinematic = false;
            });


           
        }
        void ApplyPhysicsMaterial()
        {
            if (ballMaterial != null)
            {
                ballMaterial.dynamicFriction = dynamicFriction;
                ballMaterial.staticFriction = staticFriction;
                ballMaterial.bounciness = bounciness;
            }
        }

        void Update()
        {
            if ((EnableController))
            {
                if (SmoothFollowPro.IsEconmyActive)
                {
                    StopBall();
                    return;
                }
                else
                {
                    ResumeBall();
                }



                HandleTouchInput();
                HandleMouseInput();
                HandleJump();
            }
         
        }

        void StopBall()
        {
            if (rb == null) return;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        void ResumeBall()
        {
            rb.constraints = RigidbodyConstraints.None;
        }

        // TOUCH INPUT
        void HandleTouchInput()
        {
            if (Touchscreen.current == null) return;

            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                lastTouchPosition = touch.position.ReadValue();
                isDragging = true;

               
            }
            else if (touch.press.isPressed && isDragging)
            {
                Vector2 delta = touch.position.ReadValue() - lastTouchPosition;
                RollBall(delta);
                lastTouchPosition = touch.position.ReadValue();

            }
            else if (touch.press.wasReleasedThisFrame)
            {
                isDragging = false;
            }

        }

        // MOUSE INPUT
        void HandleMouseInput()
        {
            if (Mouse.current == null) return;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                lastTouchPosition = Mouse.current.position.ReadValue();
                isDragging = true;
            }
            else if (Mouse.current.leftButton.isPressed && isDragging)
            {
                Vector2 delta = Mouse.current.position.ReadValue() - lastTouchPosition;
                RollBall(delta);
                lastTouchPosition = Mouse.current.position.ReadValue();
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                isDragging = false;
            }
        }

        // ROLLING
        void RollBall(Vector2 delta)
        {

            if (!hasStartedMoving && delta.magnitude > 0.1f)
            {
                Debug.Log("Ball started moving!");
                FirstClick?.Invoke();
                hasStartedMoving = true;
            }

            if (mainCamera == null || rb == null) return;

            Vector3 right = mainCamera.transform.right;
            Vector3 forward = mainCamera.transform.forward;

            right.y = 0f;
            forward.y = 0f;

            right.Normalize();
            forward.Normalize();

            // delta.x = left-right swipe -> reduced torque
            // delta.y = up-down swipe -> normal torque
            Vector3 torqueDirection =
                (-forward * delta.x * horizontalTorqueMultiplier) +
                (right * delta.y * verticalTorqueMultiplier);

            rb.AddTorque(torqueDirection * torquePower * Time.deltaTime, ForceMode.Force);
        }

        // JUMP INPUT
        void HandleJump()
        {
            if (Touchscreen.current != null &&
                Touchscreen.current.primaryTouch.press.wasReleasedThisFrame)
            {
                Jump();
            }

            if (Mouse.current != null &&
                Mouse.current.leftButton.wasReleasedThisFrame)
            {
                Jump();
            }

            if (Keyboard.current != null &&
                Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }
        }

        void Jump()
        {
            if (IsGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
        }
    }

}