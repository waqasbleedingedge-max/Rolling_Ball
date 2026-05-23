using System;
using UnityEngine;
//using NA.CrossPlatformInput;
using NA.Vehicles.Ball;

namespace NA.Cameras
{
    public class FreeLookCam : PivotBasedCameraRig
    {
        // This script is designed to be placed on the root object of a camera rig,
        // comprising 3 gameobjects, each parented to the next:

        // 	Camera Rig
        // 		Pivot
        // 			Camera

        [SerializeField] private float m_MoveSpeed = 1f;                      // How fast the rig will move to keep up with the target's position.
        [Range(0f, 10f)] [SerializeField] private float m_TurnSpeed = 1.5f;   // How fast the rig will rotate from user input.
        [SerializeField] private float m_TurnSmoothing = 5f;                // How much smoothing to apply to the turn input, to reduce mouse-turn jerkiness
        [SerializeField] private float m_TiltMax = 75f;                       // The maximum value of the x axis rotation of the pivot.
        [SerializeField] private float m_TiltMin = 45f;                       // The minimum value of the x axis rotation of the pivot.
        [SerializeField] private bool m_LockCursor = false;                   // Whether the cursor should be hidden and locked.
        [SerializeField] private bool m_VerticalAutoReturn = false;           // set wether or not the vertical axis should auto return

        private float m_LookAngle;                    // The rig's y axis rotation.
        private float m_TiltAngle;                    // The pivot's x axis rotation.
        private const float k_LookDistance = 100f;    // How far in front of the pivot the character's look target is.
		private Vector3 m_PivotEulers;
		private Quaternion m_PivotTargetRot;
		private Quaternion m_TransformTargetRot;
        public float a;
      //  public BallUserControl bUC;
       [HideInInspector]
        public float x;
     //   public DynamicJoystick dJS;
        private Camera cam;
        bool gameStart;
        protected override void Awake()
        {
            base.Awake();
            // Lock or unlock the cursor.
            Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !m_LockCursor;
			m_PivotEulers = m_Pivot.rotation.eulerAngles;

            m_PivotTargetRot = Camera.main.transform.parent.transform.localRotation;
			m_TransformTargetRot = transform.localRotation;
            cam = Camera.main;
            gameStart = true;
        }


        protected void Update()
        {
            HandleRotationMovement();
            ////if (m_LockCursor && Input.GetMouseButtonUp(0))
            ////{
            ////    Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            ////    Cursor.visible = !m_LockCursor;
            ////}
        }


        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        protected override void FollowTarget(float deltaTime)
        {
            if (m_Target == null) return;
            // Move the rig towards target position.
            transform.position = Vector3.Lerp(transform.position,new Vector3(m_Target.position.x, m_Target.position.y+2, m_Target.position.z), deltaTime*m_MoveSpeed);
        }

        public override void  SetTarget(Transform trgt)
        {
            m_Target = trgt;
                 
        }
        private void HandleRotationMovement()
        {
			if(Time.timeScale < float.Epsilon)
			return;
            // Debug.Log("Camera rotation");
            // Read the user input
            //  var x = CrossPlatformInputManager.GetAxis("Mouse X");
            //   var y = CrossPlatformInputManager.GetAxis("Mouse Y");
            //  float x = CrossPlatformInputManager.GetAxis("Horizontal");
            //  float y = CrossPlatformInputManager.GetAxis("Vertical");
          //  x = dJS.Horizontal;
            
            //Debug.Log("Target Rot Player" + m_Target.eulerAngles.y);
            //  Debug.Log("Cam parent Rot" + m_PivotTargetRot.y);
            //  Debug.Log("Target Rot Cam" + m_TransformTargetRot.y);

            if (0.01f < (m_Target.eulerAngles.y - m_TransformTargetRot.eulerAngles.y) || 0f > (m_Target.eulerAngles.y - m_TransformTargetRot.eulerAngles.y))
            {
                //  Debug.Log("n Condition"+ (m_Target.eulerAngles.y - m_TransformTargetRot.eulerAngles.y));
                //  Debug.Log("n Condition"+ (m_Target.eulerAngles.y - m_TransformTargetRot.eulerAngles.y));
               
                float angleDiff = Mathf.Abs(m_Target.eulerAngles.y) - Mathf.Abs(m_TransformTargetRot.eulerAngles.y);
                // Debug.Log("Euler Angles =" + angleDiff);

                //  Debug.Log("Euler Angles m_target =" + Mathf.Abs(m_Target.eulerAngles.y));
                //   Debug.Log("Euler Angles Transform target =" + Mathf.Abs(m_TransformTargetRot.eulerAngles.y));
                //if (bUC.velocity > 5)
                //{
                //    if (angleDiff < -05.0f && angleDiff > -180)
                //    {
                //        a = -0.25f;
                //    }
                //    else if (angleDiff > 05.0f && angleDiff < 180)
                //    {
                //        a = 0.25f;
                //    }
                //    else if (angleDiff < -180.0f && angleDiff >= -358)
                //    {
                //        a = 0.25f;
                //    }
                //    else if (angleDiff > 180 && angleDiff <= 358)
                //    {
                //        a = -0.25f;
                //    }
                //    else
                //    {
                //        a = 0f;
                //    }
                //}
                //else
                //{
                //    if (angleDiff < -01.50f && angleDiff >= -180)
                //    {
                //        a = -0.25f;
                //    }
                //    else if (angleDiff > 1.50f && angleDiff <= 180)
                //    {
                //        a = 0.25f;
                //    }
                //    else if (angleDiff < -180.0f && angleDiff >= -358)
                //    {
                //        a = 0.25f;
                //    }
                //    else if (angleDiff > 180 && angleDiff <= 358)
                //    {
                //        a = -0.25f;
                //    }
                //    else
                //    {
                //        a = 0f;
                //    }
                //}
            }
            else
            {
                if (gameStart)
                {
                    a = 0.5f;
                }
                else
                {
                    a = 0f;
                }

            }

      
            m_LookAngle += a * m_TurnSpeed;// * bUC.velocity;
            // Rotate the rig (the root object) around Y axis only:
            m_TransformTargetRot = Quaternion.Euler(0f, m_LookAngle, 0f);

        

            // Tilt input around X is applied to the pivot (the child of this object)
			m_PivotTargetRot = Quaternion.Euler(m_TiltAngle, m_PivotEulers.y , m_PivotEulers.z);

			if (m_TurnSmoothing > 0)
			{
				m_Pivot.localRotation = Quaternion.Slerp(m_Pivot.localRotation, m_PivotTargetRot, m_TurnSmoothing * Time.deltaTime);
				transform.localRotation = Quaternion.Slerp(transform.localRotation, m_TransformTargetRot, m_TurnSmoothing * Time.deltaTime);
			}
			else
			{
				m_Pivot.localRotation = m_PivotTargetRot;
				transform.localRotation = m_TransformTargetRot;
			}

            //if(bUC.velocityX>3||bUC.velocity>3)
            //{
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 100f, 0.01f);
            //}
            //else
            //{
            //    if(cam.fieldOfView>80f)
            //    {
            //        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80f, 0.01f);
            //    }
            //}
        }
    }
}
