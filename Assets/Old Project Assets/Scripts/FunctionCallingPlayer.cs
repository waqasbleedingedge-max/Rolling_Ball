using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NA;



public class FunctionCallingPlayer : SimpleSingleton<FunctionCallingPlayer>
{

    public GameObject Nos;
  public void TimelineGameStart()
    {
        
        if(UiManager.Instance)
        {
            UiManager.Instance.StartRace();
        }


    }
    public void NosONOFF(bool a)
    {
        Nos.SetActive(a);
    }

}
