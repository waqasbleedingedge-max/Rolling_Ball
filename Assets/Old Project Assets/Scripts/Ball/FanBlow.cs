using UnityEngine;
using NA.Utility;

public class FanBlow : MonoBehaviour
{
    public Rigidbody PlayerRig;
    public bool AddForce = false;
    public float ForceValue = 200f;
    public Transform ForceDirection;

    public bool BlowConstant = false;
    public bool UpWardForce = false;
    public float CustomGravityForce = -9.8f;
    public float BlowBreakTime = 2f;
    public AutoMoveAndRotate FanSc;
    public Collider FanCollider;
    public GameObject WindEffect;
    public Vector3 ForceValueDir;
    bool onOff;

    private void OnEnable()
    {
        if (!BlowConstant)
        {
            InvokeRepeating(nameof(FanOnOff),BlowBreakTime,BlowBreakTime);
        }
    }

    void FanOnOff()
    {
        onOff = !onOff;
        FanSc.enabled = onOff;
        WindEffect.SetActive(onOff);
        FanCollider.enabled = onOff;
        if (!onOff)
        {
            AddForce = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.TryGetComponent(out PlayerRig);
            AddForce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddForce = false;
        }
    }

    private void FixedUpdate()
    {
        if (AddForce) 
        {
            if (UpWardForce)
            {
                Vector3 customGravity = Physics.gravity * -CustomGravityForce;
                Debug.Log("Gravity "+customGravity);
                PlayerRig.AddForce(customGravity, ForceMode.Acceleration);
            }
            else 
            {
                PlayerRig.AddForce(ForceDirection.forward*ForceValue, ForceMode.Force);
            }
        }
    }
}
