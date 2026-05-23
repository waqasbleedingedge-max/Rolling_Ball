using UnityEngine;
using NA;
using DG.Tweening;
using NA.Vehicles.Ball;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : SimpleSingleton<SmoothFollow>
	{
		[SerializeField]
		public mode currntMode;
        public Ball Ball_Ref;
        float dummyMultiplier = 0;
        Vector3 CameraDummyPos= Vector3.zero;
        // The target we are following
        //[SerializeField]
        public Transform target;
		public Transform GamePlayTarget;
		public Transform bsllSelectionTarget;
		public Transform ParticleSelectionTarget;
		// The distance in the x-z plane to the target
		//[SerializeField]
		public float distance = 10.0f;

		// the height we want the camera to be above the target
		//[SerializeField]
		public float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		//[SerializeField]
		public float heightDamping;
        //[SerializeField]
        public float reachDamping;
		Vector3 Vel=Vector3.zero ;

		public LayerMask groundLayer;
	//	public GameObject lerpTarget;

		// Use this for initialization
		bool finishHit = false;
		Transform finishTarget;
		float rotator = 0;
		Transform t = null;
        
		
		//bool lookHim;
		[Header("CameraSetting")]

		public CameraSetting GamePlayCamera; 
		public CameraSetting BallSelection_S; 
		public CameraSetting ParitcleSelection_S, WorldSelection_S;
		public bool startMove = false;
		public bool LookAtPlayer = false;
        public bool FailCheck = false;
		//public Camera MainCamera, SelectioinCamera;
		//public GameObject SelectionRender;

      
        public void InGamplayCam()
        {
            height = GamePlayCamera.HeightSub;
            distance = GamePlayCamera.Distance;
            heightDamping = GamePlayCamera.HeightDamping;
            reachDamping = GamePlayCamera.ReachDamping;
            target = GamePlayTarget;
            currntMode = mode.GamePlay;
            BackSmooth = true;
        }

		public void CameraOnBack()
		{
            reachDamping = GamePlayCamera.ReachDamping ;
            heightDamping = GamePlayCamera.HeightDamping;
            distance = GamePlayCamera.Distance;
            height = GamePlayCamera.HeightSub;
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
            startMove = false;
        }
        public float Duration = 1;
        public float elapsedTime = 0;
        public bool BackSmooth = false;
        public void CameraOnBackSmooth()
        {
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, elapsedTime/Duration);
            //currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * dummyMultiplier * Time.deltaTime);

            // Damp the height
            //currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, elapsedTime / Duration);

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
            if (elapsedTime >= Duration)
            {
                elapsedTime = 0;
                BackSmooth = false;
            }

            elapsedTime += Time.deltaTime;
            //if (!IsInvoking(nameof(MoveCamera)))
            //{
            //    Invoke(nameof(MoveCamera),Duration);
            //}
            // Always look at the target
            //transform.LookAt(target);
        }
        void MoveCamera()
        {
            BackSmooth = false;
            startMove = true;
        }
        float speed=1000;
        public void CameraOnLevelComplete()
		{
            reachDamping =80f; // 120f
            distance = 5f; // 15f
            height = 15;  //12f
            heightDamping = 0.12f; //0.12f
            //Vector3 dir = target.position - transform.position;
            //Vector3 DummyPos = new Vector3(target.position.x,target.position.y+height,target.position.z-distance);
            //dir.z = -distance;
            //dir.y = +height;
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping  * Time.fixedDeltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.fixedDeltaTime);

			// Convert the angle into a rotation

			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            //transform.position = target.position;
            Vector3 dummyPos = target.position;
            dummyPos -= currentRotation * Vector3.forward * distance;
			transform.position = Vector3.SmoothDamp(transform.position, dummyPos, ref Vel, reachDamping  * Time.fixedDeltaTime);

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

			// Always look at the target
			transform.LookAt(target);
        }

        public void CameraOnFail()
        {
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            //currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, elapsedTime / Duration);
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping*0.1f * Time.deltaTime);

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            CameraDummyPos = target.position;
            CameraDummyPos -= currentRotation * Vector3.forward * distance;

            transform.position = Vector3.SmoothDamp(transform.position, CameraDummyPos, ref Vel, reachDamping * Time.fixedDeltaTime);

            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // Always look at the target
            transform.LookAt(target);
        }
        float angleDifference = 0;
        private void FixedUpdate()
        {
            
			if (!startMove || BackSmooth)
				return;
            
            #region GameplayCamera
            if (currntMode == mode.GamePlay)
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
                CameraDummyPos = target.position;
                CameraDummyPos -= currentRotation * Vector3.forward * distance;

                transform.position = Vector3.SmoothDamp(transform.position, CameraDummyPos, ref Vel, reachDamping * Time.fixedDeltaTime);

                // Set the height of the camera
                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

                // Always look at the target
                transform.LookAt(target);
            }
            #endregion GamePlayCamera
            else if (currntMode == mode.BallSelection)
			{
				//SelectionRender.gameObject.SetActive(true);
				//MainCamera.enabled = false;
				//SelectioinCamera.gameObject.SetActive(true);

                distance = BallSelection_S.Distance;
                //var wantedRotationAngle = bsllSelectionTarget.eulerAngles.y+BallSelection_S.RotatonAngle;
                rotator += Time.deltaTime * BallSelection_S.RotatonAngle;
                var wantedRotationAngle = target.eulerAngles.y + rotator;
                var wantedHeight = bsllSelectionTarget.position.y + height- BallSelection_S.HeightSub;

                var currentRotationAngle = transform.eulerAngles.y;
                var currentHeight = transform.position.y;

                // Damp the rotation around the y-axis
                currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

                // Damp the height
                currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

                // Convert the angle into a rotation
                var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

                // Set the position of the camera on the x-z plane to:
                // distance meters behind the target
                //transform.position = target.position;
                Vector3 dummyPos = bsllSelectionTarget.position;
                dummyPos -= currentRotation * Vector3.forward * distance;
                transform.position = Vector3.SmoothDamp(transform.position, dummyPos, ref Vel, reachDamping * 0.1f * Time.deltaTime);

                // Set the height of the camera
                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

				// Always look at the target
				//t.SetPositionAndRotation(new Vector3(target.position.x, target.position.y + 10, target.position.z), target.rotation);
				//transform.SetPositionAndRotation(transform.position,Quaternion.Euler(transform.rotation.x+10, transform.rotation.y,transform.rotation.z));
                transform.LookAt(bsllSelectionTarget);

            }
			else if(currntMode == mode.WorldSelection)
			{
				
				distance = WorldSelection_S.Distance;
				height = WorldSelection_S.HeightSub;
				rotator += Time.deltaTime*WorldSelection_S.RotatonAngle;
                var wantedRotationAngle = target.eulerAngles.y+rotator;
                var wantedHeight = target.position.y + height;

                var currentRotationAngle = transform.eulerAngles.y;
                var currentHeight = transform.position.y;

                // Damp the rotation around the y-axis
                currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

                // Damp the height
                currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

                // Convert the angle into a rotation
                var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

                // Set the position of the camera on the x-z plane to:
                // distance meters behind the target
                //transform.position = target.position;
                Vector3 dummyPos = target.position;
                dummyPos -= currentRotation * Vector3.forward * distance;
                transform.position = Vector3.SmoothDamp(transform.position, dummyPos, ref Vel, reachDamping * Time.deltaTime);

                // Set the height of the camera
                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

                // Always look at the target
                transform.LookAt(target);

            }
            else if (currntMode == mode.ParticlesSelection)
            {
                target = ParticleSelectionTarget;

                distance = ParitcleSelection_S.Distance;
                var wantedRotationAngle = target.eulerAngles.y+ParitcleSelection_S.RotatonAngle ;
                var wantedHeight = target.position.y + height - ParitcleSelection_S.HeightSub;

                var currentRotationAngle = transform.eulerAngles.y;
                var currentHeight = transform.position.y;

                // Damp the rotation around the y-axis
                currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping*20 * Time.deltaTime);

                // Damp the height
                currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

                // Convert the angle into a rotation
                var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

                // Set the position of the camera on the x-z plane to:
                // distance meters behind the target
                //transform.position = target.position;
                Vector3 dummyPos = target.position;
                dummyPos -= currentRotation * Vector3.forward * distance;
                transform.position = Vector3.SmoothDamp(transform.position, dummyPos, ref Vel, reachDamping * Time.deltaTime);

                // Set the height of the camera
                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

                // Always look at the target
                //t.SetPositionAndRotation(new Vector3(target.position.x, target.position.y + 10, target.position.z), target.rotation);
                //transform.SetPositionAndRotation(transform.position,Quaternion.Euler(transform.rotation.x+10, transform.rotation.y,transform.rotation.z));
                transform.LookAt(target);

            }
        }
        private void LateUpdate()
        {
            if (BackSmooth)
            {
                CameraOnBackSmooth();
            }

            if (FailCheck)
            {
                CameraOnFail();
            }

            if (LookAtPlayer)
            {
                CameraOnLevelComplete();
            }
        }
        public void ChangeCamTarget()
        {
			finishHit = true;
			//finishTarget = t;
			//transform.DOMove(t.position, 1.0f);
			LookAtPlayer=true;
			startMove = false;
			//Time.timeScale = 0.3f;
        }


		public void BallSelection()
		{
			SoundsManager.Instance.PlayBGMusicStop();
			currntMode = mode.BallSelection;
			startMove = true;

		}

		public void WorldSelection()
		{
            SoundsManager.Instance.PlayBGMusicStop();
            currntMode = mode.WorldSelection;
            startMove = true;
        }

		public void GamePlay()
		{
            SoundsManager.Instance.PlayBGMusic();
            currntMode = mode.GamePlay;
            InGamplayCam();

        }
		public void ParticlesSelection()
		{
            SoundsManager.Instance.PlayBGMusicStop();
            currntMode = mode.ParticlesSelection;
            startMove = true;

        }
	}
	[System.Serializable]
	public struct CameraSetting
	{
		public float HeightSub;
		public float RotatonAngle;
		public float Distance;
        public float ReachDamping;
        public float HeightDamping;
	}
	public enum mode
	{
		GamePlay,
		BallSelection,
		WorldSelection,
		ParticlesSelection
	}
}