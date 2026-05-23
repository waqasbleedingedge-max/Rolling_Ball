using NA.Vehicles.Ball;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityStandardAssets.Utility;
using static UnityEngine.GraphicsBuffer;
using NA;
using UnityEngine.Events;

public class BallSwitcher : MonoBehaviour
{
    [Header("Switch")]
    public bool SwitchBall = true;
    public SwitchBallType CurrentType;
    public UnityEvent OnUpEvent;

    [Header("Other")]
    public float Player_Off;
    public GameObject Player_Ball;
    public GameObject Player_Cube;
    public GameObject Player_Mesh;

    public GameObject PaperBall, MetalBall;
    public GameObject[] PlayerBalls;
    public Rigidbody SpherePlayer;
    public Transform Target;
    public Transform DownTarget;
    public int CurrentBallNum = 0;
    //BallUserControl BUC;
    public Animator CheckPointAnim;
    public ParticleSystem OffUp, BallSpawnParticles;
    //public ParticleSystem ShowPaticle;
    public float speed = 2f;
    public float MoveSpeed = 2f;
    public bool Up = false;
    public bool PRS_New;
    public Transform DummyPos;
    public bool Movechk = false;
    public bool DownChk = false;
    public Collider BaseCol;
    public bool BreakMetal, BreakPaper;
    public SphereCollider BallCollider;

    void OnEnable()
    {
       // Player_Ball = LevelManager.Instance.Player_Ball;
       // Player_Cube = LevelManager.Instance.Player_Cube;
       // Player_Mesh = LevelManager.Instance.Player_Mesh;
    }

    void Call()
    {
        if (PRS_New == true)
        {
            Player_Ball.transform.position = DummyPos.transform.position;
            Player_Ball.transform.rotation = DummyPos.transform.rotation;

            Player_Cube.transform.position = DummyPos.transform.position;
            Player_Cube.transform.rotation = DummyPos.transform.rotation;
        }
    }

    //private void Start()
    //{
    //    SpherePlayer.maxAngularVelocity = 250;
    //    SpherePlayer.maxLinearVelocity = 20f;
    //}
    private void FixedUpdate()
    {
        if (Movechk)
        {
            Vector3 currentPosition = SpherePlayer.position;

            // Lerp towards the target position
            Vector3 targetPosition = Vector3.Lerp(currentPosition, Target.position, speed);

            // Calculate the velocity to move towards the target position
            Vector3 velocity = (targetPosition - currentPosition) / Time.fixedDeltaTime;

            // Apply the velocity to the rigidbody
            SpherePlayer.linearVelocity = velocity.normalized * MoveSpeed;
            float dis = Vector3.Distance(Target.position, currentPosition);
            if (dis <= 0.25f)
            {
                Movechk = false;
                DownChk = true;
                //SmoothFollow.Instance.startMove = false;
                if (BaseCol != null)
                {
                    BaseCol.enabled = false;
                }
                if (SpherePlayer.TryGetComponent(out BallCollider))
                {
                    BallCollider.enabled = false;
                }
                //makeStatic();
            }
        }
        if (DownChk)
        {
            Vector3 currentPosition = SpherePlayer.position;

            // Lerp towards the target position
            Vector3 targetPosition = Vector3.Lerp(currentPosition, DownTarget.position, speed);

            // Calculate the velocity to move towards the target position
            Vector3 velocity = (targetPosition - currentPosition) / Time.fixedDeltaTime;

            // Apply the velocity to the rigidbody
            SpherePlayer.linearVelocity = velocity.normalized * MoveSpeed;
            float dis = Vector3.Distance(DownTarget.position, currentPosition);
            if (dis <= 0.25f)
            {
                DownChk = false;
                UpNow();
            }
        }
        //SpherePlayer.position = transform.position;
    }
    void Start()
    {
        if (!IsInvoking(nameof(SwitchBallOn)))
        {
            Invoke(nameof(SwitchBallOn), 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if (other.TryGetComponent(out BUC))
            //{
            //    if (TryGetComponent(out Collider Col))
            //    {
            //        Col.enabled = false;
            //    }
            //    //LevelManager.Instance.BallType = CurrentType;
            //    CurrentBallNum = PlayerPrefs.GetInt("selectedball");

            //  //  SpherePlayer = BUC.rb;
            //    //SpherePlayer.interpolation = RigidbodyInterpolation.Interpolate; // Smooth movement
            //    //SpherePlayer.isKinematic = true;
            //  //  BUC.StopInput = true;
            //    CheckPointAnim.SetTrigger("Up");
            //    OffUp.gameObject.SetActive(false);
            //    //Transform pos=
            //    float s = SpherePlayer.transform.localScale.y / 2;

            //    Vector3 curTarget = new Vector3(Target.localPosition.x, s, Target.localPosition.z);
            //    Target.localPosition = new Vector3(Target.localPosition.x, s, Target.localPosition.z);
            //    //Up = true;
            //    Movechk = true;
            //    MoveBall();
            //    //SpherePlayer.transform.DOMove(Target.position, 1f).OnComplete(() => makeStatic());
            //    //Up = true;
            //}
        }
    }
    void mesh_off()
    {
        if (PRS_New == true)
        {
            Player_Mesh.SetActive(false);
        }
    }

    void MoveBall()
    {
        Invoke(nameof(mesh_off), Player_Off);
        Debug.Log("MoveBall*******");
        //SpherePlayer.transform.DOMove(Target.position, 1f);
        //.OnComplete(() => makeStatic());
        //Invoke(nameof(makeStatic),1);
      //  LevelManager.Instance.BallSwitchTxt.text = "ReachPosition";

       // LevelManager.Instance.BallRotation_Ref.Target = Target;
       /// LevelManager.Instance.BallRotation_Ref.OffRotation = true;
        //SpherePlayer.angularVelocity = Vector3.zero;
        //SpherePlayer.maxAngularVelocity = 0;
        //SpherePlayer.maxLinearVelocity = 0;
        //SpherePlayer.useGravity = false;
        //SpherePlayer.isKinematic = true;

    }

    void makeStatic()
    {
        //SmoothFollow.Instance.startMove = false;
        Invoke(nameof(TempFum), 0.1f);
       // LevelManager.Instance.BallSwitchTxt.text = "Downward pos";

    }

    void TempFum()
    {
        SpherePlayer.transform.DOMove(DownTarget.position, 1f);
        //.OnComplete(() => UpNow());
        Invoke(nameof(UpNow), 1);
    }
    void tsk()
    {
        if (PRS_New == true)
        {
            Invoke(nameof(BreakBall), 0.8f);
        }
        else
        {
            BreakBall();
        }
    }

    void UpNow()
    {
        SwitchBallFun(CurrentType);
        tsk();
        float s = SpherePlayer.transform.localScale.y / 2;
        if (PRS_New == true)
        {
            Target.localPosition = new Vector3(DummyPos.localPosition.x, s, DummyPos.localPosition.z);
            SpherePlayer.transform.DOMove(DummyPos.position, 1f).SetUpdate(UpdateType.Fixed).OnComplete(() => KinematicOff());
            SpherePlayer.angularVelocity = Vector3.zero;
            SpherePlayer.isKinematic = true;
        }
        else
        {
            Target.localPosition = new Vector3(Target.localPosition.x, s, Target.localPosition.z);
            SpherePlayer.transform.DOMove(Target.position, 1f).SetUpdate(UpdateType.Fixed).OnComplete(() => KinematicOff());
            SpherePlayer.angularVelocity = Vector3.zero;
            SpherePlayer.isKinematic = true;
        }
        ParticleOn();
        //LevelManager.Instance.BallRotation_Ref.OffRotation = false;
        //LevelManager.Instance.BallRotation_Ref.ResetRotation();
        //LevelManager.Instance.BallSwitchTxt.text = "Up Position";
        SoundsManager.Instance?.GenericFun(SoundsManager.Instance.BallSwapSound);
    }

    void ParticleOn()
    {
        BallSpawnParticles.gameObject.SetActive(true);
        BallSpawnParticles.Play();
    }

    void KinematicOff()
    {
        if (BaseCol != null)
        {
            BaseCol.enabled = false;
        }
        BallCollider.enabled = true;
       // BallUserControl.Instance.RefPosSetting();
        SpherePlayer.isKinematic = true;
        SmoothFollow.Instance.BackSmooth = true;
        SmoothFollow.Instance.startMove = true;
        CheckPointAnim.gameObject.SetActive(false);
        //SpherePlayer.transform.localRotation = DownTarget.localRotation;
        //ShowPaticle.gameObject.SetActive(true);
        //ShowPaticle.Play();
        SpherePlayer.maxAngularVelocity = 20;
        SpherePlayer.maxLinearVelocity = 25;
       // LevelManager.Instance.BallSwitchTxt.text = "isKinematic Off";
       // LevelManager.Instance.BallRotation_Ref.OffRotation = false;
        SpherePlayer.useGravity = true;
        OnUpEvent.Invoke();


    }

    void SwitchBallOn()
    {
        for (int i = 0; i < PlayerBalls.Length; i++)
        {
            PlayerBalls[i].SetActive(false);
        }
        PaperBall.SetActive(false);
        MetalBall.SetActive(false);

        //switch (CurrentType)
        //{
        //    case SwitchBallType.Origional:
        //        PlayerBalls[LevelManager.Instance.SelectedBallIndex].SetActive(true);
        //        break;

        //    case SwitchBallType.MetalBall:
        //        MetalBall.SetActive(true);

        //        break;
        //    case SwitchBallType.PaperBall:
        //        PaperBall.SetActive(true);
        //        break;
        //}
    }

    void SwitchBallFun(SwitchBallType Ball)
    {
        //switch (Ball)
        //{
        //    case SwitchBallType.Origional:
        //        if (LevelManager.Instance.PaperBall.activeInHierarchy)
        //        {
        //           // LevelManager.Instance.PaperBall.SetActive(false);
        //            BreakPaper = true;
        //        }
        //        if (LevelManager.Instance.MetalBall.activeInHierarchy)
        //        {
        //           // LevelManager.Instance.MetalBall.SetActive(false);
        //            BreakMetal = true;
        //        }
        //        for (int i = 0; i < LevelManager.Instance.playerBalls.Length; i++)
        //        {
        //           // LevelManager.Instance.playerBalls[i].SetActive(false);
        //        }
        //       // LevelManager.Instance.playerBalls[LevelManager.Instance.SelectedBallIndex].SetActive(true);//PlayerPrefs.GetInt("selectedball")
        //       //// LevelManager.Instance.PaperBallChk = false;
        //       // LevelManager.Instance.MetalBallChk = false;
        //        break;
        //    case SwitchBallType.MetalBall:
        //        if (LevelManager.Instance.PaperBall.activeInHierarchy)
        //        {
        //            LevelManager.Instance.PaperBall.SetActive(false);
        //            BreakPaper = true;
        //        }
        //        LevelManager.Instance.PaperBall.SetActive(false);
        //        LevelManager.Instance.MetalBall.SetActive(true);
        //        for (int i = 0; i < LevelManager.Instance.playerBalls.Length; i++)
        //        {
        //            LevelManager.Instance.playerBalls[i].SetActive(false);
        //        }
        //        LevelManager.Instance.MetalBallChk = true;
        //        break;

        //    case SwitchBallType.PaperBall:
        //        if (LevelManager.Instance.MetalBall.activeInHierarchy)
        //        {
        //            LevelManager.Instance.MetalBall.SetActive(false);
        //            BreakMetal = true;
        //        }
        //        LevelManager.Instance.PaperBall.SetActive(true);
        //        LevelManager.Instance.MetalBall.SetActive(false);
        //        for (int i = 0; i < LevelManager.Instance.playerBalls.Length; i++)
        //        {
        //            LevelManager.Instance.playerBalls[i].SetActive(false);
        //        }
        //        LevelManager.Instance.PaperBallChk = true;
        //        break;

        //}
        SpherePlayer.transform.localRotation = DownTarget.rotation;
        //BUC.StopInput = false;
        Movechk = false;
        //SmoothFollow.Instance.CameraOnBackSmooth();
    }

    public void BreakBall()
    {
        if (BreakMetal)
        {
            if (PRS_New == true)
            {
               // Instantiate(LevelManager.Instance.MetalBallBr, DummyPos.position, Quaternion.identity);
                Player_Mesh.SetActive(true);
            }
            else
            {
              //  Instantiate(LevelManager.Instance.MetalBallBr, Target.position, Quaternion.identity);
            }

            BreakMetal = false;
            BreakPaper = false;
        }
        else if (BreakPaper)
        {
           // Instantiate(LevelManager.Instance.PaperBallBr, Target.position, Quaternion.identity);
            BreakMetal = false;
            BreakPaper = false;
        }
        else
        {
           // Instantiate(LevelManager.Instance.BreakAbleBalls[LevelManager.Instance.SelectedBallIndex]
               // , Target.position, Quaternion.identity);
            BreakMetal = false;
            BreakPaper = false;
        }
    }

    //public void FixedUpdate()
    //{
    //    if (Up)
    //    {
    //        if (SpherePlayer.position != Target.position)
    //            MoveTowardsTarget();
    //        else
    //        {
    //            SpherePlayer.isKinematic = true;
    //            Up = false;
    //        }
    //    }

    //}
    //Vector3 Vel;
    //public void MoveTowardsTarget()
    //{
    //    Vector3 Dir = Target.position - SpherePlayer.position;
    //    //Vector3 di=new Vector3 (Dir.x, 0,Dir.y);
    //    DummyPos.position = SpherePlayer.position;
    //    DummyPos.LookAt(Target);

    //    if (Dir.x < 0)
    //    {
    //        Dir.x = Dir.x * -1;
    //    }

    //    if (Dir.x > 0)
    //    {
    //        Dir.x = Dir.x + 0.7f;
    //    }

    //    if (Dir.y > 0)
    //    {
    //        Dir.y += 0.7f;
    //    }

    //    if (Dir.y < 0)
    //    {
    //        Dir.y -= 0.7f;
    //    }

    //    Debug.Log("x " + Dir.x + " y " + Dir.y);
    //    Vector3 move = (Dir.y * DummyPos.forward + Dir.x * DummyPos.right).normalized;
    //    //Dir.Normalize();
    //    //Quaternion n = Quaternion.Euler(Dir.x,Dir.y,Dir.z);
    //    //Vector3 pos=Dir+transform.position;
    //    //Vector3 d= DummyPos.position;
    //    //DummyPos.rotation = Quaternion.Euler(0,d.y,0);
    //    //Vector3  move = ( DummyPos.forward +  DummyPos.right).normalized;
    //    //  SpherePlayer.AddTorque(new Vector3(move.z, 0, -move.x) * speed, ForceMode.Force);
    //    SpherePlayer.AddTorque(move * Time.fixedDeltaTime * speed, ForceMode.Force);
    //    //transform.LookAt(Target);
    //    //transform.position = Vector3.SmoothDamp(transform.position, pos, ref Vel, speed * Time.deltaTime);

    //}

    public void DownClick()
    {
        Up = true;
    }

    public void OnUp()
    {
        Up = false;
    }
}

[System.Serializable]
public enum SwitchBallType
{
    Origional, MetalBall, PaperBall
}
