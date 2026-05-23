using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NA;
using NA.Utility;
using UnityStandardAssets.Utility;

public class DropBoundary : MonoBehaviour
{
    public Rigidbody Ball;
    public float CustomGravityForce = -1.7f;
    public bool once = false;


    void OnEnable()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player") && !once)
        //{
        //    once = true;
        //    SoundsManager.Instance.ballLost.Play();
        //    other.TryGetComponent(out Ball);
        //    if (LevelManager.Instance)
        //    {
        //        Vector3 newTran = new Vector3(other.transform.position.x, other.transform.position.y/* - 0.25f*/, other.transform.position.z);
        //        LevelManager.Instance.Drop_Splash.transform.position = newTran;
        //        LevelManager.Instance.Drop_Splash.gameObject.SetActive(true);
        //        LevelManager.Instance.Drop_Splash.Play();
        //        isFail = true;
        //    }
        //    StartCoroutine(LevelFailed());

        //}
        //else if (other.CompareTag("Props"))
        //{
        //    Vector3 newTran = new Vector3(other.transform.position.x, other.transform.position.y/* - 0.25f*/, other.transform.position.z);
        //    LevelManager.Instance.Drop_Splash.transform.position = newTran;
        //    LevelManager.Instance.Drop_Splash.gameObject.SetActive(true);
        //    LevelManager.Instance.Drop_Splash.Play();
        //    SoundsManager.Instance?.ballLost.Play();
        //}
    }
    bool isFail = false;
    private void FixedUpdate()
    {
        if (isFail)
        {
            Vector3 customGravity = Physics.gravity * -CustomGravityForce;
            Ball.AddForce(customGravity, ForceMode.Acceleration);
        }
    }
    IEnumerator LevelFailed()
    {

        //LevelManager.Instance?.CameraOnFail();
        //yield return new WaitForSeconds(0.25f);
        Ball.constraints = RigidbodyConstraints.FreezeAll;
        Ball.constraints = ~RigidbodyConstraints.FreezePositionY;
        if (!isFail)
            isFail = true;
        Ball.angularDamping = 0.5f;
        Ball.linearDamping = 0.5f;
        yield return new WaitForSeconds(1.25f);
        isFail = false;
        //LevelManager.Instance.LevelFailedINIT();
    }
}
