using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NA;

public class TextDisplay : MonoBehaviour
{
    public List<int> a;
    public Text objeciveText;


  

    IEnumerator DisplayDialogue(string s)
    {
        objeciveText.text = string.Empty;
        objeciveText.gameObject.SetActive(true);

        foreach (char a in s.ToCharArray())
        {
            objeciveText.text += a;

            yield return new WaitForSeconds(0.05f);
        }
      

    }
}
