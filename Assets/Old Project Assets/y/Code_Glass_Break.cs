using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Glass_Break : MonoBehaviour
{
    public float _G_Force = 300f;
    public bool _G_Broken;
    public GameObject[] Audio;
    public GameObject _Main;
    public BoxCollider _Main_Bc;
    public Rigidbody _Main_Rb;

    public Rigidbody[] _inSide;

    public string _p_Tag = "Player";
    public string _p_Name = "RollerBall";

    void OnEnable()
    {
        _Main = this.gameObject;
        _Main_Bc = _Main.GetComponent<BoxCollider>();
        _Main_Rb = _Main.GetComponent<Rigidbody>();

        _inSide = _Main.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody xXx in _inSide)
        {
            xXx.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        TryBreak(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        TryBreak(other.gameObject);
    }

    void TryBreak(GameObject obj)
    {
        if (_G_Broken) return;

        if (obj.CompareTag(_p_Tag) && obj.name == _p_Name)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 dir = rb.linearVelocity.normalized;
                float spd = rb.linearVelocity.magnitude * 1.2f; // multiplier optional

                BreakNow(dir, spd);
            }
        }
    }

    void BreakNow(Vector3 hitDirection, float hitSpeed)
    {
        _G_Broken = true;

        foreach (Rigidbody yYy in _inSide)
        {
            yYy.isKinematic = false;
        }

        foreach (GameObject xXx in Audio)
        {
            xXx.SetActive(true);
        }

        // Force
        foreach (Rigidbody yYy in _inSide)
        {
            yYy.AddForce(hitDirection * hitSpeed, ForceMode.Impulse);
        }
    }
}