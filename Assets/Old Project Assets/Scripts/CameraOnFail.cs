using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnFail : MonoBehaviour
{
    public bool _Active;
    MeshRenderer _mc;    

    public string _Tag = "Player";
    public string _Name = "Player";
    public string _Layer = "Player";

    void OnEnable()
    {
        _mc = this.gameObject.GetComponent<MeshRenderer>();
        _mc.enabled = false;
        _Active = true;
    }

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          //  LevelManager.Instance?.CameraOnFail();
        }
    }
}