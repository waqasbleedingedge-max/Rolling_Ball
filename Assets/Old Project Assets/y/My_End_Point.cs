using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_End_Point : MonoBehaviour
{
    public bool Rnd;
    public int Level;

    public int Val;
    public int Total;
    public GameObject[] _Obj;

    void OnEnable()
    {
        Level = PlayerPrefs.GetInt("CurrentLevel");

        _off();
        Total = _Obj.Length;
        chk();
    }

    void chk()
    {
        if (Rnd == true)
        {
            Val = Random.Range(0, Total);
        }
        else
        {
            Val = Level % Total;
        }
        tsk(Val);
    }

    void _off()
    {
        foreach (GameObject xXx in _Obj)
        {
            xXx.SetActive(false);
        }
    }

    void tsk(int xXx)
    {
        _Obj[xXx].SetActive(true);
    }
}