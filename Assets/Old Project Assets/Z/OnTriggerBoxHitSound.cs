using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Purchasing;
//?? using MoreMountains.NiceVibrations;

public class OnTriggerBoxHitSound : MonoBehaviour
{
    //public GameObject _This;
    //public GameObject _Child;

    [Space(5)]
    public UnityEvent BoxTrigger;
    public UnityEvent BoxTrigger_Exit;

    [Space(5)]
    public bool _Kiss;

    [Space(5)]
    public bool _Vlc_Chk;
    public float _Vlc_Time;

    [Space(5)]
    public bool New_Box;
    public bool New_Gry;
    public string tag = "PlayerBall";






    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tag))
        {
            print("New_Box_Tri Player:_ " + other.gameObject.name);
          
            BoxTrigger.Invoke();
            vlc_chk();

            if (_Kiss == true)
            {
            //    LevelManager.Instance.Btn_Kiss_Active();
            }
        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.transform.CompareTag(tag))
        {
            print("New_Box_Tri_Exit Player:_ " + other.gameObject.name);
            BoxTrigger_Exit.Invoke();
        }
    }

    public void vlc_chk()
    {
        if (_Vlc_Chk == true)
        {
            if (!IsInvoking(nameof(vlc_off)))
            {
                if (PlayerPrefs.GetInt("haptics") == 0)
                {
                    //?? MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
                }
             //   _Child.SetActive(false);
               // mr.enabled = false;
              //  _Child.SetActive(true);
                Invoke(nameof(vlc_off), _Vlc_Time);
            }
        }
    }

    void vlc_off()
    {
        //mr.enabled = true;
        //_Child.SetActive(false);
    }
}