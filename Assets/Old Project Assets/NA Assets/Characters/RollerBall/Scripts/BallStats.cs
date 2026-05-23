using NA.Vehicles.Ball;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStats : MonoBehaviour
{
    public Ball Ball;
    public GameObject Cube;
    public bool CanBreakProps=false;
    public Rigidbody BallRig;
    public Projector Projector;
    public float BallSize = 0.7f;
    public float BallMass = 35f;
    public float AngularDrag = 0.1f;
    public float Drag = 0.1f;
    public float BallPower = 600f;
    public float Pro_OrthoSize = 0.61f;


    private void OnEnable()
    {
        BallRig.mass = BallMass;
        BallRig.angularDamping = AngularDrag;
        BallRig.linearDamping = Drag;
      //  LevelManager.Instance.CurAngDrag = AngularDrag;
      //  LevelManager.Instance.CurDrag = Drag;
      //  LevelManager.Instance.CurMass = BallMass;
        Ball.m_MovePower = BallPower;
        Ball.CanBreakProps = CanBreakProps;
        Projector.orthographicSize = Pro_OrthoSize;
        Ball.gameObject.transform.localScale=new Vector3 (BallSize,BallSize,BallSize);
        //Cube.transform.localScale=new Vector3 (BallSize,BallSize,BallSize);
    }
}
