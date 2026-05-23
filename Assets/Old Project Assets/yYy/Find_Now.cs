using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_Now : MonoBehaviour
{
    public string _Name;
    public Camera _Find;
    public bool _Del;

    void OnEnable()
    {
        //string _Name_WB = "WB_OnReflectionCamera";
        //string _Name_LB = "LB_OnReflectionCamera";
        Invoke(nameof(chk), 1f);
    }

    void chk()
    {
        GameObject obj = GameObject.Find(_Name);
        if (obj != null)
        {
            // OK
            _Find = obj.GetComponent<Camera>();
            if (_Find != null)
            {
                _Find.enabled = true;
                Invoke(nameof(tsk), 1f);
            }
        }
        else
        {
            Debug.LogWarning("GameObject nahi mila: " + _Name);
        }
    }

    void tsk()
    {
        //?? _Find.enabled = false;
        if (_Del == true)
        {
            Destroy(_Find.gameObject);
        }
    }
}