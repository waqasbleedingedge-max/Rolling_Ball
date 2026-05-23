using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NA.Vehicles.Ball;

public class JumpPower : MonoBehaviour
{
    public Ball b;
    public float jumpPower;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            b = other.GetComponent<Ball>();
            StartCoroutine(CallJump());
        }
    }

    IEnumerator CallJump()
    {
        yield return new WaitForSeconds(0.1f);
        b.Jump(jumpPower);
    }
}
