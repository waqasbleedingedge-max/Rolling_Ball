using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Keys : MonoBehaviour
{
    public static Code_Keys ck_Inst;

    public int ck_Val;
    public GameObject[] ck_Obj;

    public float ck_e_Timer;
    public GameObject ck_Effect;

    void Awake()
    {
        ck_Inst = this;
    }

    void OnEnable()
    {
        ck_Val = 0;
    }

    public void Btn_Add_Key()
    {
        ck_e_on();
    }
    void ck_e_on()
    {
        ck_Effect.SetActive(false);
        ck_Effect.SetActive(true);
        Invoke(nameof(ck_e_off), ck_e_Timer);
    }

    void ck_e_off()
    {
        // 0 , 1 , 2
        if (ck_Val < 3)
        {
            ck_Obj[ck_Val].SetActive(true);
        }
        ck_Val = ck_Val + 1;

        // 1 , 2 , 3

        ck_Effect.SetActive(false);
    }
}