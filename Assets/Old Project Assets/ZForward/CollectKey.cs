using NA.Vehicles.Ball;
using NA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{

    public GameObject Shine, Key;
    public float ontriggerEnterDelay;
   

    WaitForSeconds delayCoin = new WaitForSeconds(.1f);
    WaitForSeconds delayShine = new WaitForSeconds(.5f);




    void OnTriggerEnter(Collider other)
    {
       // foreach (string tag in tags)
        {
            if (other.CompareTag("PlayerBall"))
            {
              //  bsu = other.GetComponent<BallUserControl>();
               // bsu.PlayKeyAnim();
                //CoinsManager.Instance.AddCoins(10);
                StartCoroutine(DelayOff());
            }

        }
    }

    void End()
    {
        Destroy(this.gameObject);
    }
    IEnumerator DelayOff()
    {
        _call();
        yield return delayCoin;
        Shine.SetActive(true);
        Key.SetActive(false);
        yield return delayShine;
        this.gameObject.SetActive(false);
    }

    bool _j;
    void _call()
    {
        if (_j == false)
        {
            _j = true;
         //   Code_Keys.ck_Inst.Btn_Add_Key();
        }
        else
        {
            // Already Add
        }
    }
}
