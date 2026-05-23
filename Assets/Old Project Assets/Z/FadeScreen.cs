using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public Image fadeImage;
    float time = 2;


    private void Update()
    {
       
        time -= Time.deltaTime;
        if(time<=0)
        {
            Destroy(this.gameObject);
        }
    }


}
