using NA.Vehicles.Ball;
using UnityEngine;

#pragma warning disable 649
namespace UnityStandardAssets.Utility
{
	public class SmoothFollow_new : MonoBehaviour
	{
		public SmoothFollow SF_Ref;
		public Ball Ball_Ref;
		public static SmoothFollow_new Instance = null;
		// The target we are following
		[SerializeField]
		private Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;
		float dummyMultiplier = 0;
		Vector3 Vel=Vector3.zero;

        private void Awake()
        {
            Instance = this;
        }
        // Use this for initialization
        void Start() 
		{
			OnBackTarget();

        }

		void OnBackTarget()
		{
            //Vector3 dir = target.position - transform.position;
            //Vector3 DummyPos = new Vector3(target.position.x,target.position.y+height,target.position.z-distance);
            //dir.z = -distance;
            //dir.y = +height;
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = wantedRotationAngle;
            //currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, 15000 * Time.deltaTime);

            // Damp the height
            currentHeight = wantedHeight;
            //currentHeight = Mathf.Lerp(currentHeight, wantedHeight, 15000 * Time.deltaTime);

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            //transform.position = target.position;
            Vector3 dummyPos = target.position;
            dummyPos -= currentRotation * Vector3.forward * distance;
            transform.position = dummyPos;

            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // Always look at the target
            transform.LookAt(target);
        }

		// Update is called once per frame
		void FixedUpdate()
		{
			// Early out if we don't have a target
			if (!target || !SF_Ref.startMove)
				return;
			if (SF_Ref.currntMode == mode.GamePlay)
			{
				// Calculate the current rotation angles
				var wantedRotationAngle = target.eulerAngles.y;
				var wantedHeight = target.position.y + height;

				var currentRotationAngle = transform.eulerAngles.y;
				var currentHeight = transform.position.y;
				if (Ball_Ref.BallSpeedvalue > 3)
				{
					dummyMultiplier = 3;
				}
				else
				{
					dummyMultiplier = Ball_Ref.BallSpeedvalue;
				}
				dummyMultiplier = dummyMultiplier / 2.5f;
				// Damp the rotation around the y-axis
				currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * dummyMultiplier * Time.deltaTime);
				//currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle,ref  rotationDamping * dummyMultiplier * Time.deltaTime);

				// Damp the height
				currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

				// Convert the angle into a rotation
				var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

				// Set the position of the camera on the x-z plane to:
				// distance meters behind the target
				transform.position = target.position;
				transform.position -= currentRotation * Vector3.forward * distance;

				// Set the height of the camera
				transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

				// Always look at the target
				transform.LookAt(target);
			}
		}
	}
}