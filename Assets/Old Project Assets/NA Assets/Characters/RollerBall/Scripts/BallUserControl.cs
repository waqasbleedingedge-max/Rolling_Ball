//using System;
//using UnityEngine;
//using UnityEngine.UI;
//using ControlFreak2;
//using UnityStandardAssets.Utility;

//namespace NA.Vehicles.Ball
//{
//    public class BallUserControl : SimpleSingleton<BallUserControl>
//    {
        
//        public Ball ball; // Reference to the ball controller.
//        public LayerMask groundLayers;
//        [SerializeField]
//        //private Transform[] rotatingBall;
//        public float rotationSpeed;
//        private Vector3 move;
//        // the world-relative desired move direction, calculated from the camForward and user input.
//        public  Rigidbody rb;
//        private Transform cam; // A reference to the main camera in the scenes transform
//        private Vector3 camForward; // The current forward direction of the camera
//                                    // private bool jump; // whether the jump button is currently pressed
//        public Transform t;
//        [SerializeField] private float m_TurnSmoothing = 10f;

//        private float ballLookAngle;
//      //  private float ballTurnSpeed = 1.5f;

//        private Quaternion m_TransformTargetRot;
//        private Quaternion m_PivotTargetRot;

//        public Vector3 previousPos;
//        public Vector3 cameraTarget;
//        private Transform bT;

//        public Transform followFrefab;

//      //  public DynamicJoystick dJS;
//        public InputManager input;
//        public float h;
//        public float v;

//        public bool jump;
//        public bool onPipes;
//        bool isSoundPlaying;
//        public float velocity;
//        public float velocityX;
//        // ..............Sounds ............

//        public AudioSource rollingSound;
//        public AudioSource pipeRollingSound;
//        public AudioSource groundHitsound;
//        public Transform rotation;
//        // ........ Particles ........
//        public ParticleSystem groundHitEffect;
//        int ballIndex;
//        Vector3 lookPos;
//        Quaternion rot;
//      //  Vector3 prevInput;
//      // Vector3 curInput;
//        public Button playButton;
//        public bool gameStart;
//        public Transform ballLocation;
//        public GameObject[] _coinanimPrefab;
//        public GameObject[] _coinsTextPrefab;
//        public GameObject coinanimPrefab;
//        public GameObject keyAnimPrefab;
//        public GameObject coinsTextPrefab;
//      //  public GameObject keyTextPrefab;
//        public Transform mainCanvas;
//        private float inputTimer;
//        //public GameObject dirArrow;
//        float hr = 0.0f;
//        float vr = 0.0f;
//        float x = 0.0f;
//        float z = 0.0f;
//        float xSpeed = 0.0f;
//        float zSpeed = 0.0f;
//        Vector3 pos;
//        Vector3 dir;
//        Vector3 zForward;
//        public GameObject[] particlesPrefabs;

//        public bool StopInput = false;

//        private void OnEnable()
//        {
//            Time.timeScale = 1.0f;
//            load_Int();
//            TryGetComponent(out bT);
//            // Set up the reference.
//            TryGetComponent(out ball);
//            TryGetComponent(out rb);
//            m_PivotTargetRot = transform.localRotation;
//            m_TransformTargetRot = transform.localRotation;
//            // get the transform of the main camera
//            if (Camera.main != null)
//            {
//                cam = Camera.main.transform;
//            }
//            else
//            {
//                Debug.LogWarning(
//                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
//                // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
//            }

//            ballIndex = PlayerPrefs.GetInt("selectedball");
//            //for (int i = 0; i < rotatingBall.Length; i++)
//            //{
//            //    if (i == ballIndex)
//            //    {
//            //        rotatingBall[i].gameObject.SetActive(true);
//            //    }
//            //    else
//            //    {
//            //        rotatingBall[i].gameObject.SetActive(false);
//            //    }

//            //}
//            //t.SetLocalPositionAndRotation(transform.position, transform.rotation);
//            UpdateParticles();

//        }

//        public void UpdateBall()
//        {
//            ballIndex = PlayerPrefs.GetInt("selectedball");
//            //for (int i = 0; i < rotatingBall.Length; i++)
//            //{
//            //    if (i == ballIndex)
//            //    {
//            //        rotatingBall[i].gameObject.SetActive(true);
//            //    }
//            //    else
//            //    {
//            //        rotatingBall[i].gameObject.SetActive(false);
//            //    }

//            //}
//        }

//        public void UpdateParticles()
//        {
//            int a = PlayerPrefs.GetInt("particles");
//            for (int i = 0; i < particlesPrefabs.Length; i++)
//            {
//                particlesPrefabs[i].SetActive(false);
//            }
//            if (a == 0)
//            {
//                return;
//            }
//            else
//            {
//                particlesPrefabs[a - 1].gameObject.SetActive(true);
//            }
//        }
//        int coinanimIndex = -1;
//        public void PlayCoinAnim()
//        {
//            // Debug.Log("PlayAnim");
//            if(_coinanimPrefab.Length-1 > coinanimIndex)
//            {
//                coinanimIndex += 1;
//            }
//            else
//            {
//                coinanimIndex = 0;
//            }
//            _coinanimPrefab[coinanimIndex].SetActive(true);
//            _coinsTextPrefab[coinanimIndex].SetActive(true);
//           // GameObject c = Instantiate(coinanimPrefab, t);
//           // GameObject tx = Instantiate(coinsTextPrefab, mainCanvas);
//           // tx.SetActive(true);
//           // Destroy(c, 1.0f);
//           // Destroy(tx, 1.0f);

//            // t.GetComponent<Animator>().Play("CoinAnimNew");
//        } 
//        public void PlayKeyAnim()
//        {
//            if (_coinsTextPrefab.Length - 1 > coinanimIndex)
//            {
//                coinanimIndex += 1;
//            }
//            else
//            {
//                coinanimIndex = 0;
//            }
//            _coinsTextPrefab[coinanimIndex].SetActive(true);
//            keyAnimPrefab.SetActive(true);
//            // Debug.Log("PlayAnim");
//            //GameObject c = Instantiate(keyAnimPrefab, t);
//            //GameObject tx = Instantiate(coinsTextPrefab, mainCanvas);
//           // tx.SetActive(true);
//            //Destroy(c, 1.0f);
//            //Destroy(tx, 1.0f);

//            // t.GetComponent<Animator>().Play("CoinAnimNew");
//        }

//        public float FrameCounter = 0;
//        private void FixedUpdate()
//        {
//            #region StopAction Region
//            if (StopInput)
//            {
//                h = 0;
//                v = 0;
//                rb.angularDamping = 1;
//                rb.linearDamping = 1;

//                if (rb.maxAngularVelocity >= 0)
//                {
//                    rb.maxAngularVelocity -= Time.fixedDeltaTime * 40f;
//                }

//                t.position = transform.position;
//                return;
//            }
//            #endregion
//            // upward stop Action

//            // Update()
//            ////h = input.horizontal;
//            ////v = input.vertical;
            
//            if (CF2Input.GetAxis("Fire1") != 0)
//            {
//                if (FrameCounter <= 0.025f )
//                {
//                    if (v > 0)
//                    {
//                        if (v >= 2.5f)
//                            ball.ShootBall = true;
//                    }
//                    else
//                    {
//                        if ((v * -1) >= 3)
//                        {
//                            ball.ShootBall = true;
//                        }
//                    }

//                    if (x > 0)
//                    {
//                        if (x >= 3f)
//                            ball.ShootBall = true;
//                    }
//                    else
//                    {
//                        if ((x * -1) >= 3)
//                        {
//                            ball.ShootBall = true;
//                        }
//                    }

//                    //ball.ShootBall = true;
//                    //Debug.Log("Shoot ");
//                    x = Mathf.Abs(h);
//                    z = Mathf.Abs(v);
//                    if (x >= z)
//                    {
//                        ball.Move(move, Mathf.Clamp01(x), false);

//                    }
//                    else
//                    {
//                        ball.Move(move, Mathf.Clamp01(z), false);
//                    }
//                }
//                FrameCounter = 0;
//                h = CF2Input.GetAxis("Mouse X");
//                v = CF2Input.GetAxis("Mouse Y");

//            }
//            else
//            {
//                h = CF2Input.GetAxis("Mouse X");
//                v = CF2Input.GetAxis("Mouse Y");
//            }
//            //if (CF2Input.GetAxis("Fire1")>0)
//            //{
//            //    FrameCounter += Time.fixedDeltaTime;
//            //    Debug.Log("Mouse Y Value  " + v +"  Frames "+FrameCounter);
//            //}


//            if (v > 0.2f && !gameStart)
//            {
//                playButton.onClick.Invoke();
//            }
//            if (!gameStart)
//                return;
//            if (v > 3.5f)
//            {
//                v = 3.5f;
//            }
//            if (v < -3.5f)
//            {
//                v = -3.5f;
//            }

//            if (h > 3.5f)
//            {
//                h = 3.5f;
//            }
//            if (h < -3.5f)
//            {
//                h = -3.5f;
//            }
//            // calculate move direction
//            if (cam != null)
//            {
//                // calculate camera relative direction to move:
//                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
//                move = (v * camForward + h * cam.right).normalized;
//            }
//            else
//            {
//                // we use world-relative directions in the case of no main camera
//                move = (v * Vector3.forward + h * Vector3.right).normalized;
//            }
            
//            t.position = transform.position;
//            lookPos = followFrefab.position - t.position;

//            lookPos.y = 0;
//            rot = Quaternion.LookRotation(lookPos);
//            t.rotation = Quaternion.Slerp(t.rotation, rot, Time.deltaTime * 10.0f);


//            xSpeed = Mathf.Abs(rb.linearVelocity.x);
//            zSpeed = Mathf.Abs(rb.linearVelocity.z);
//            //Comment by Qasim as sound and rotation use nhi krni
//            #region Sound Track Off
//            if (xSpeed > zSpeed)
//            {
//                //rotatingBall[ballIndex].Rotate(Mathf.Abs(rb.velocity.x * rotationSpeed), 0, 0, Space.Self);
//                if (!jump && Mathf.Abs(rb.linearVelocity.x * rotationSpeed) > 5f)
//                {
//                    if (!rollingSound.isPlaying)
//                    {
//                        rollingSound.Play();
//                    }
//                    else
//                    {

//                        float pitch = Mathf.Abs(rb.linearVelocity.x);

//                        if (pitch > 10f)
//                        {
//                            rollingSound.pitch = 2.0f;
//                            rollingSound.volume = (Mathf.Abs(rb.linearVelocity.x));
//                            rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.2f);
//                        }
//                        else
//                        {
//                            rollingSound.volume = (Mathf.Abs(rb.linearVelocity.x));
//                            rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.2f);
//                            rollingSound.pitch = (pitch / 10f) + 1;
//                        }

//                    }

//                }
//                else
//                {
//                    if (rollingSound.isPlaying)
//                    {
//                        rollingSound.Stop();
//                    }

//                    if (onPipes)
//                    {
//                        if (!pipeRollingSound.isPlaying)
//                        {
//                            pipeRollingSound.Play();
//                        }
//                        else
//                        {
//                            float pitch = Mathf.Abs(rb.linearVelocity.x);
//                            if (pitch > 10f)
//                            {
//                                pipeRollingSound.pitch = 2.0f;
//                                pipeRollingSound.volume = (Mathf.Abs(rb.linearVelocity.x) / 40);
//                                rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.2f);
//                            }
//                            else
//                            {
//                                pipeRollingSound.volume = (Mathf.Abs(rb.linearVelocity.x) / 40);
//                                rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.2f);
//                                pipeRollingSound.pitch = (pitch / 10f) + 1;
//                            }
//                        }
//                    }
//                }
//            }
//            else
//            {
//               // Debug.Log("Velocity "+rb.velocity.z);
//                //rotatingBall[ballIndex].Rotate(Mathf.Abs(rb.velocity.z * rotationSpeed), 0, 0, Space.Self);
//                if (!jump && Mathf.Abs(rb.linearVelocity.z * rotationSpeed) > 5f)
//                {
//                    if (!rollingSound.isPlaying && Mathf.Abs(rb.linearVelocity.z * rotationSpeed) > 0.8f)
//                    {
//                        rollingSound.Play();
//                    }
//                    else
//                    {

//                        float pitch = Mathf.Abs(rb.linearVelocity.z);

//                        if (pitch > 10f)
//                        {
//                            rollingSound.pitch = 1.20f;
//                            rollingSound.volume = (Mathf.Abs(rb.linearVelocity.z));
//                            rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.2f);
//                        }
//                        else
//                        {

//                            rollingSound.volume = (Mathf.Abs(rb.linearVelocity.z));
//                            rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.2f);
//                            rollingSound.pitch = 1f;
//                        }
//                    }

//                }
//                else
//                {
//                    if (rollingSound.isPlaying)
//                    {
//                        rollingSound.Stop();
//                    }
//                    if (onPipes)
//                    {
//                        if (!pipeRollingSound.isPlaying)
//                        {
//                            pipeRollingSound.Play();
//                        }
//                        else
//                        {


//                            float pitch = Mathf.Abs(rb.linearVelocity.z);

//                            if (pitch > 10f)
//                            {
//                                pipeRollingSound.pitch = 1.20f;
//                                pipeRollingSound.volume = (Mathf.Abs(rb.linearVelocity.z) / 80);
//                                rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.3f);
//                            }
//                            else
//                            {

//                                pipeRollingSound.volume = (Mathf.Abs(rb.linearVelocity.z) / 80);
//                                rollingSound.volume = Mathf.Clamp(rollingSound.volume, 0, 0.3f);
//                                pipeRollingSound.pitch = 1f;
//                            }
//                        }
//                    }
//                }
//            }
//            #endregion

//            RaycastHit hit;
//            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1f, groundLayers))
//            {
//                if (jump)
//                {
//                    Debug.Log("Ground Hit Call");

//                    if (!groundHitEffect.gameObject.activeInHierarchy)
//                        groundHitEffect.gameObject.SetActive(true);
//                    groundHitsound.Play();
//                    groundHitEffect.transform.SetPositionAndRotation(hit.point, groundHitEffect.transform.rotation);
//                    groundHitEffect.Play();
//                }

//                jump = false;

//            }
//            else
//            {
//                jump = true;

//            }



//            if (!Mathf.Approximately(0f, Vector3.Distance(previousPos, bT.position)))
//            {
//                pos = previousPos;
//                dir = (transform.position - previousPos).normalized;


//                zForward = pos + dir * 10;
//                followFrefab.position = new Vector3(zForward.x, zForward.y, zForward.z);
//                cameraTarget = pos + dir * 10;

//                previousPos = bT.transform.position;
//            }


//            // Call the Move function of the ball controller


//            if (ball.ShootBall)
//                return;

//            x = Mathf.Abs(h);
//            z = Mathf.Abs(v);
//            if (x >= z )
//            {
//                ball.Move(move, Mathf.Clamp01(x), false);

//            }
//            else
//            {
//                ball.Move(move, Mathf.Clamp01(z), false);
//            }


//        }

//        public void RefPosSetting(bool BakOn=false)
//        {
//            t.position = transform.position;
//            lookPos = followFrefab.position - t.position;

//            lookPos.y = 0;
//            rot = Quaternion.LookRotation(lookPos);
//            t.rotation = transform.rotation;

//            //if (!Mathf.Approximately(0f, Vector3.Distance(previousPos, bT.position)))
//            //{
//            //    pos = previousPos;
//            pos = transform.position;
//            dir = (transform.forward).normalized;


//                zForward = pos + dir * 10;
//                followFrefab.position = new Vector3(zForward.x, zForward.y, zForward.z);
//                cameraTarget = pos + dir * 10;

//            previousPos = bT.transform.position;
//            //}
//            if(BakOn)
//            Invoke(nameof(CameraBack),0.5f);
//        }
//        public void Jump(float power)
//        {
//            ball.Jump(power);
//        }

//        public void SpawnPlayer(Transform to)
//        {
//            // Debug.Log("Spawn Player Run");
//            ball.gameObject.SetActive(true);
//            transform.SetPositionAndRotation(new Vector3(to.position.x, to.position.y + 0.5f, to.position.z), to.rotation);
//            t.SetLocalPositionAndRotation(transform.position, Quaternion.identity);
//            Invoke("isKinameticFalse", 0.2f);
//            RefPosSetting(true);
//        }
//        void CameraBack()
//        {
//            SmoothFollow.Instance.CameraOnBack();
//        }
//        public void ReSpawnPlayer(Transform to)
//        {
//            //for (int i = 0; i < rotatingBall.Length; i++)
//            //{

//            //    rotatingBall[i].gameObject.SetActive(false);


//            //}

//            float BallRadius=0;
//            //GameObject balldummy;
//            //if (LevelManager.Instance.PaperBallChk)
//            //{
//            //    balldummy = LevelManager.Instance.PaperBall;
//            //}else if (LevelManager.Instance.MetalBall)
//            //{
//            //    balldummy = LevelManager.Instance.MetalBall;
//            //}
//            //else
//            //{
//            //    balldummy = LevelManager.Instance.playerBalls[PlayerPrefs.GetInt("selectedball")];
//            //}
//            // if(balldummy.TryGetComponent(out BallStats ballStats))
//            //{
//                 BallRadius = gameObject.transform.localScale.x / 2;
//            //}
//            transform.SetPositionAndRotation(new Vector3(to.position.x, to.position.y+BallRadius, to.position.z), to.rotation);
//            t.SetLocalPositionAndRotation(transform.position, transform.rotation);
//            //LevelManager.Instance.ballIcon.gameObject.SetActive(true);
//            //LevelManager.Instance.ballIcon.position = LevelManager.Instance.chanceImages[LevelManager.Instance.chance].transform.position;
//            //LevelManager.Instance.ballIcon.DOMove(ballLocation.position, 1.0f).OnComplete(() => ReSpawnEvent(to));



//            //  rb.isKinematic = false;

//        }

//        public void ReSpawnEvent(Transform to)
//        {
//            //for (int i = 0; i < LevelManager.Instance.playerBalls.Length; i++)
//            //{
//            //    LevelManager.Instance.playerBalls[i].SetActive(false);
//            //}
//            //switch (LevelManager.Instance.BallType)
//            //{
//            //    case SwitchBallType.Origional:
//            //        LevelManager.Instance.PaperBall.SetActive(false);
//            //        LevelManager.Instance.MetalBall.SetActive(false);
//            //        LevelManager.Instance.playerBalls[LevelManager.Instance.SelectedBallIndex].SetActive(true); //PlayerPrefs.GetInt("selectedball")

//            //        break;
//            //    case SwitchBallType.MetalBall:
//            //        LevelManager.Instance.PaperBall.SetActive(false);
//            //        LevelManager.Instance.MetalBall.SetActive(true);
//            //        break;
//            //    case SwitchBallType.PaperBall:
//            //        LevelManager.Instance.PaperBall.SetActive(true);
//            //        LevelManager.Instance.MetalBall.SetActive(false);
//            //        break;

//            //}

//            //for (int i = 0; i < LevelManager.Instance.playerBalls.Length; i++)
//            //{
//            //    if (i == ballIndex)
//            //    {
                    
//            //        LevelManager.Instance.playerBalls[i].gameObject.SetActive(true);
//            //    }
//            //    else
//            //    {
//            //        LevelManager.Instance.playerBalls[i].gameObject.SetActive(false);
//            //    }

//            //}
//            //LevelManager.Instance.ballIcon.gameObject.SetActive(false);

//        }

//        public void PlayButton()
//        {
//            SmoothFollow.Instance.distance = SmoothFollow.Instance.GamePlayCamera.Distance;
//            SmoothFollow.Instance.height = SmoothFollow.Instance.GamePlayCamera.HeightSub;
//            //SmoothFollow.Instance.reachDamping = 1.5f; 
//            //SmoothFollow.Instance.heightDamping = 50f;
//            SmoothFollow.Instance.reachDamping = SmoothFollow.Instance.GamePlayCamera.ReachDamping;
//            SmoothFollow.Instance.heightDamping = SmoothFollow.Instance.GamePlayCamera.HeightDamping;
//            SmoothFollow.Instance.startMove = true;
            
          
//            gameStart = true;
//            rb.isKinematic = false;
//            Invoke("MoveStart", 0.1f);
//        }


//        public void MoveStart()
//        {
//            ball.StartForce(cam);
//            //ball.Move(cam.forward, 10.0f, false);
//        }

//        // Int
//        void Btn_Call_AD()
//        {
//            print("Int_Ad_Kon_Sa");
//            show_Int();
//        }

//        void load_Int()
//        {
//           // zWork.Instance.Btn_Load_Int();
//        }

//        void show_Int()
//        {
//           // zWork.Instance.Btn_Show_Int();
//            Invoke(nameof(load_Int), 1f);
//        }
//    }
//}