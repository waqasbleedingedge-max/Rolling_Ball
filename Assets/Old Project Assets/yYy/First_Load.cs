using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class First_Load : MonoBehaviour
{
    public bool AO;
    public float AOL_Timer;
    public float AOS_Timer;

    public float _Timer;
    public string _Name;

    void OnEnable()
    {
        Invoke(nameof(_Next), _Timer);
        _Chk();

    }

    void _Chk()
    {
        if (AO == true)
        {
            Invoke(nameof(AO_L), AOL_Timer);
            Invoke(nameof(AO_S), AOS_Timer);
        }
    }

    void _Next()
    {
        SceneManager.LoadScene(_Name);
    }

    void AO_L()
    {
        //?1?2? AppOpenManager.Instance.Btn_App_Load();
    }
    void AO_S()
    {
        //?1?2? AppOpenManager.Instance.Btn_App_Show();
    }
}