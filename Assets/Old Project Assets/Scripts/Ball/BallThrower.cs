using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject BallToThrow;
    public Transform SpawnPos;
    public float Force;
    public float DelayThrow;
    public GameObject BallDummy;
    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnBall),2,DelayThrow);
    }

    void SpawnBall()
    {
        BallDummy = Instantiate(BallToThrow, SpawnPos.transform.position, SpawnPos.transform.rotation);
        if(BallDummy.TryGetComponent(out Rigidbody BF))
        {
            BF.AddForce(BF.transform.forward*Force,ForceMode.Force);
        }

    }
}
