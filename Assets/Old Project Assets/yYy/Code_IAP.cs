using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code_IAP : MonoBehaviour
{
    [Space(5)]
    public bool Splash;

    [Space(5)]
    public bool Ad;

    [Space(5)]
    public bool MM;
    public bool LC;
    public float Timer;

    [Space(5)]
    public bool Rnd;
    public int Nbr;
    public int Tot;
    public GameObject[] IAP;

    [Space(5)]
    public string _T_Wb;
    public string _T_IAP_GAF;
    public string _T_IAP_UAB;
    public Text[] _T_Wb_IAP;

    void OnEnable()
    {
        chk();
    }

    void chk()
    {
        if (Splash == true)
        {
            // PlayerPrefs.SetInt("MM_IAP", 0);
            PlayerPrefs.SetInt("Swap_Hand", 0);
            PlayerPrefs.SetInt("Black", 0);
        }
        else
        {
            Tot = IAP.Length;
            tsk();
        }
    }

    void tsk()
    {
        if (Ad == true)
        {
            load_int();
        }

        // Next 
        if (PlayerPrefs.GetInt("MM_IAP") == 0)
        {
            PlayerPrefs.SetInt("MM_IAP", 1);
            if (PlayerPrefs.GetInt("Shop") == 0)
            {
                FB_Event("_MM_IAP_Show");
                Invoke(nameof(_on), Timer);
            }
            else
            {
                FB_Event("_MM_IAP_Buy");
                _off();
            }
        }
        else
        {
            _off();
        }

        _lc();
    }

    void _on()
    {
        Rnd = true;
        Nbr = Random.Range(0, Tot);
        IAP[Nbr].SetActive(true);
    }

    void _off()
    {
        foreach (GameObject xXx in IAP)
        {
            xXx.SetActive(false);
        }
    }


    public void Btn_IAP_Close()
    {
        PlayerPrefs.SetInt("MM_IAP", 1);
        if (Ad == true)
        {
            show_int();
        }
        _off();

        FB_Event("_MM_IAP_Close");
    }

    public void Btn_IAP_Close_WB()
    {
        if (Ad == true)
        {
            show_int();
        }
        _off();

        FB_Event("_WB_IAP_Close");
    }

    void _lc()
    {
        if (LC == true)
        {
            if (PlayerPrefs.GetInt("Shop") == 0)
            {
                Invoke(nameof(_on), Timer);
            }
            else
            {
                _off();
            }
        }
    }

    public void Btn_IAP_Close_Com()
    {
        FB_Event("_Com_IAP_Close");
    }

    // Int
    void load_int()
    {
       // zWork.Instance.Btn_Load_Int();
    }
    void show_int()
    {
       // zWork.Instance.Btn_Show_Int();
        Invoke(nameof(load_int), 1f);
    }

    // FB Event
    string xXx_Fb;
    void FB_Event(string xXx)
    {
        xXx_Fb = xXx;
     //   LevelManager.Instance.Btn_FB_Call(xXx_Fb);
    }
}