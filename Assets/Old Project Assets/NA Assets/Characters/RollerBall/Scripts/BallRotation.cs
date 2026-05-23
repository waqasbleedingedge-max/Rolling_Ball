using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    public Transform RotaionCopyBall;
    public bool OffRotation = false;
    public Transform Target;
    public Transform DummyPos;
    public Transform Parent;
    public float RotationSpeed = 200f;

    private void OnEnable()
    {
        OffRotation = false;
      //  LevelManager.Instance.BallRotation_Ref = this;
    }

    bool Once = false;
    
    private void Update()
    {
        if (!OffRotation)
            transform.rotation = RotaionCopyBall.rotation;
        else
        {

            if (Target)
            {
                DummyPos.LookAt(Target);

                Parent.Rotate(RotationSpeed * Time.deltaTime,
                    0, 0);
                //transform.rotation = DummyPos2.rotation;
                //transform.localRotation(DummyPos.right*RotationSpeed*Time.deltaTime);
            }
        }
    }

    public void ResetRotation()
    {
        Parent.rotation=new Quaternion(0,0,0,0);
    }
}
