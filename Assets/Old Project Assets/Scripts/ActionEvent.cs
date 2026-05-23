using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionEvent : MonoBehaviour
{
    public string EventString;

    public UnityEvent AnimEvent;
  

    public void Action(string a)
    {
        if(a==EventString)
        {
            AnimEvent.Invoke();
        }

    }
}
