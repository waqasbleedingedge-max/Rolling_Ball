using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

namespace NA.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        /*[SerializeField]*/ public float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.

        public float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;
        public bool CanBreakProps = false;
       // public BallUserControl buc;
        public float PipeMultiplier=3, SimpleMultiplier=1;
        public float AlterMultiplier = 3;
        public float RLMultiplier = 5;
        public float BSV_Check = 1.5f;
        public bool ShootBall = false;
        public bool ReverseStop = false;
        public bool ReverseHelper = false;
        //[HideInInspector]
        public bool ForwardMove,ReverseMove,RightMove,LeftMove = false;
        public float ReverseTime = 1f;
        public Vector3 dummyDir = Vector3.zero;
        public Transform CubeObj;
        public Text BallSpeed;
        public  float BallSpeedvalue;
        float x,y=0f;

        //public Slider Sli;
        //public Text SliderValue;
        private void Start()
        {
            TryGetComponent(out m_Rigidbody);
            // Set the maximum angular velocity.
            m_Rigidbody.maxAngularVelocity = m_MaxAngularVelocity;
            m_Rigidbody.maxLinearVelocity = 20f;
        }

        public void Move(Vector3 moveDirection,float Speedmultiplier,bool isRev=false)
        {
            //if (SliderValue != null)
            //{
            //    float dum = Sli.value * 50;
            //    SliderValue.text = dum.ToString();
            //}

            x = ControlFreak2.CF2Input.GetAxis("Mouse X");
            y = ControlFreak2.CF2Input.GetAxis("Mouse Y");
            dummyDir = moveDirection;
            if(m_Rigidbody.isKinematic && Speedmultiplier != 0)
            {
                m_Rigidbody.isKinematic = false;
                //LevelManager.Instance.FollowCamera.startMove = true;
                //SmoothFollow.Instance.startMove = true;
            }

            BallSpeedvalue = m_Rigidbody.linearVelocity.magnitude;
            if (BallSpeedvalue < 0.1f && Speedmultiplier==0)
            {
                m_Rigidbody.angularDamping = 6;
                m_Rigidbody.linearDamping = 6;
                
            }
            else
            {
                if (SmoothFollow.Instance.startMove)
                {
                    //m_Rigidbody.angularDamping =LevelManager.Instance.CurAngDrag;
                    //m_Rigidbody.linearDamping = LevelManager.Instance.CurDrag;
                }
            }
            // If using torque to rotate the ball...
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up,out hit, k_GroundRayLength) && m_UseTorque)
            {
                // ... add torque around the axis defined by the move direction.
                if(hit.transform.CompareTag("Booster"))
                {
                    m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower * 5f);
                }
                else
                {
                    m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower,ForceMode.Force);
                   // Debug.Log("Pos x = " + moveDirection.x + " Pos z = " + moveDirection.z);
                }

                //if (buc.onPipes)
                //{
                //  //  m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower * Speedmultiplier);
                //}

            }
            else
            {
                if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength))
                {
                    //Debug.Log("Hit Collider= "+hit.collider.gameObject.name);
                    if (hit.collider == null)
                    {
                        Debug.Log("Null value");//by Qasim
                        return;
                    }
                    if (hit.transform.CompareTag("Booster"))
                    {
                        
                        // Otherwise add force in the move direction.
                        m_Rigidbody.AddForce(moveDirection * m_MovePower*5,ForceMode.Acceleration);
                        //m_Rigidbody.AddForce(moveDirection * m_MovePower/f,ForceMode.Impulse);
                    }
                    else
                    {
                        //Debug.Log("else= ");
                        //if (isRev)
                        //{
                        //    //    Debug.Log("rev= " + moveDirection);
                        //    //float morePower = (BallSpeedvalue * 2.5f) / 2;
                        //    //if (morePower < 1)
                        //    //{
                        //    //    morePower = 1;
                        //    //}
                        //    //Debug.Log("reversePower  "+morePower);
                        //    //if (isHalf)
                        //    //{
                        //    //    if (morePower > 1)
                        //    //        morePower = 1;
                        //    //}
                        //    if (BallSpeedvalue > 3f)
                        //    {
                        //        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier * 5);
                        //        Debug.Log("Reverse taiz");
                        //    }
                        //    else
                        //    {
                        //        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier * 2);
                        //        Debug.Log("Reverse slow");
                        //    }
                        //}
                        //else
                        //{

                        // Debug.Log("For  , Speed multiply = " + moveDirection);
                        if (BallSpeedvalue > BSV_Check)
                        {
                            m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                        }
                        else
                        {
                            if (y > 0 && x > 0)
                            {

                                if (x > y)
                                {
                                    if (LeftMove)
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier * RLMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = false;
                                    ReverseMove = false;
                                    RightMove = true;
                                    LeftMove = false;

                                }
                                else
                                {
                                    if (ReverseMove)
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = true;
                                    ReverseMove = false;
                                    RightMove = false;
                                    LeftMove = false;
                                }

                            }
                            else if (y > 0 && x < 0)
                            {
                                //Debug.Log("2nd Quardenant");
                                if (y > (x * -1))
                                {
                                    if (ReverseMove)
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = true;
                                    ReverseMove = false;
                                    RightMove = false;
                                    LeftMove = false;
                                }
                                else
                                {
                                    if (RightMove )
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier * RLMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = false;
                                    ReverseMove = false;
                                    RightMove = false;
                                    LeftMove = true;
                                }
                            }
                            else if (y < 0 && x > 0)
                            {
                                //Debug.Log("3rd Quardenant");
                                if (x > (y * -1))
                                {
                                    if (LeftMove)
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier * RLMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = false;
                                    ReverseMove = false;
                                    RightMove = true;
                                    LeftMove = false;
                                }
                                else
                                {
                                    if (ForwardMove )
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = false;
                                    ReverseMove = true;
                                    RightMove = false;
                                    LeftMove = false;
                                }
                            }
                            else if (y < 0 && x < 0)
                            {
                                //Debug.Log("3rd Quardenant");
                                if ((x * -1) > (y * -1))
                                {
                                    if (RightMove)
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier * RLMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = false;
                                    ReverseMove = false;
                                    RightMove = false;
                                    LeftMove = true;
                                }
                                else
                                {
                                    if (ForwardMove )
                                    {
                                        //Left To Right
                                        m_Rigidbody.AddForce(moveDirection * AlterMultiplier, ForceMode.Impulse);
                                    }
                                    else
                                    {
                                        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                    }
                                    ForwardMove = false;
                                    ReverseMove = true;
                                    RightMove = false;
                                    LeftMove = false;
                                }
                            }
                            else if (x == 0 && y > 0)
                            {
                                if (ReverseMove )
                                {
                                    //Left To Right
                                    m_Rigidbody.AddForce(moveDirection * AlterMultiplier, ForceMode.Impulse);
                                }
                                else
                                {
                                    m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                }
                                ForwardMove = true;
                                ReverseMove = false;
                                RightMove = false;
                                LeftMove = false;
                            }
                            else if (x > 0 && y == 0)
                            {
                                if (LeftMove )
                                {
                                    //Left To Right
                                    m_Rigidbody.AddForce(moveDirection * AlterMultiplier * RLMultiplier, ForceMode.Impulse);
                                }
                                else
                                {
                                    m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                                }
                                ForwardMove = false;
                                ReverseMove = false;
                                RightMove = true;
                                LeftMove = false;
                            }
                            else
                            {
                                //    //Debug.Log("First Quardinant");
                                //    if (x == 0 && y == 0)
                                //    {
                                //        Debug.Log("Free move");
                                //RightMove=LeftMove=ForwardMove=ReverseMove=false;
                                //m_Rigidbody.AddForce(moveDirection * m_MovePower * 0.1f);
                                //}

                            }
                        }
                        #region Old BallMoveWork
                        //if (ControlFreak2.CF2Input.GetAxis("Reverse") > 0)
                        //{
                        //    if(ReverseStop)
                        //    {
                        //        ReverseStop = false;
                        //        ReverseHelper = true;
                        //        float morePower = (BallSpeedvalue * 2f * ControlFreak2.CF2Input.GetAxis("Reverse"));
                        //        m_Rigidbody.AddForce(moveDirection * morePower, ForceMode.Impulse);
                        //    }
                        //    else if(!ReverseStop && ReverseHelper&& BallSpeedvalue > 1f)
                        //    {
                        //        if (ReverseTime > 0)
                        //        {
                        //            ReverseTime -= Time.deltaTime;
                        //        }
                        //        else
                        //        {
                        //            ReverseHelper = false;
                        //        }
                        //        // Ideal reverse Multiplier 1.5f;
                        //        float morePower = (BallSpeedvalue * 2f * ControlFreak2.CF2Input.GetAxis("Reverse"));
                        //        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier * morePower);
                        //        //Debug.Log("Reverse Call  " + morePower);
                        //    }
                        //    else
                        //    {
                        //        m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                        //    }
                        //}
                        //else
                        //{
                        //    ReverseStop = true;
                        //    if (BallSpeedvalue > 6)
                        //        ReverseTime = 0.6f;
                        //    else if (BallSpeedvalue > 4 && BallSpeedvalue <= 6)
                        //        ReverseTime = 0.4f;
                        //    else if (BallSpeedvalue > 2 && BallSpeedvalue<=4)
                        //        ReverseTime = 0.2f;
                        //    else
                        //    {
                        //        ReverseTime = 0.1f;
                        //    }
                        //    m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);
                        //}
                        ////}

                        if (ShootBall)
                        {
                            if (BallSpeedvalue < 6f)
                            {
                                m_Rigidbody.AddForce(moveDirection * AlterMultiplier*1.15f, ForceMode.Impulse);
                                //m_Rigidbody.AddForce(CubeObj.forward * 25, ForceMode.Impulse);
                            }
                            ShootBall = false;
                            Debug.Log("Shoot Ball Work " + moveDirection);
                        }



                        //if (ControlFreak2.CF2Input.GetAxis("Mouse Y") > 0)
                        //{
                        //    ForwardMove = true;
                        //}
                        //else
                        //{
                        //    ForwardMove = false;
                        //    float morePower = (BallSpeedvalue * 2f * ControlFreak2.CF2Input.GetAxis("Reverse"));
                        //    m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier * morePower);
                        //}

                        #endregion
                        // Otherwise add force in the move direction.

                        //  m_Rigidbody.velocity = moveDirection;
                    }

                }
                //else if(buc.onPipes)
                //{
                //    //Debug.Log("Hit Pipes");
                //    m_Rigidbody.AddForce(moveDirection * m_MovePower * Speedmultiplier);// * Speedmultiplier);
                //}
                else
                {
                    //Debug.Log("empty Input");
                    m_Rigidbody.AddForce(moveDirection * m_MovePower * 0.1f);
                }
               
            }
            if(BallSpeed)
            BallSpeed.text = BallSpeedvalue.ToString();

        }

        public void StartForce(Transform dir)
        {
            m_Rigidbody.AddForce(dir.forward * 10, ForceMode.Impulse);
        }

        public void Jump(float jumpPower)
        {
            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength))
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}
