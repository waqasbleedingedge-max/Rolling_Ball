using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsNumberUpdateComplete : MonoBehaviour
{
    public Text firstCircleText;
    public GameObject firstCircleImage;
    public Text secondCircleText;
    public GameObject secondCircleImage;
    public Text thirdCircleText;
    public GameObject thirdCircleImage;
    public Text fourthCircleText;
    public GameObject fourthCircleImage;
    public Sprite check;

    void OnEnable()
    {
        int a = PlayerPrefs.GetInt("CurrentLevel");
        a = a + 1;
        if (a % 4 == 1)
        {

            firstCircleText.text = a.ToString();
            firstCircleImage.SetActive(true);
            secondCircleText.text = (a + 1).ToString();
            secondCircleImage.SetActive(false);
            thirdCircleText.text = (a + 2).ToString();
            thirdCircleImage.SetActive(false);
            fourthCircleText.text = (a + 3).ToString();
            fourthCircleImage.SetActive(false);
        }
        else if (a % 4 == 2)
        {
            firstCircleText.enabled = false;
            firstCircleImage.SetActive(true);
            firstCircleImage.GetComponent<Image>().sprite = check;
            secondCircleText.text = a.ToString();
            secondCircleImage.SetActive(true);
            thirdCircleText.text = (a + 1).ToString();
            thirdCircleImage.SetActive(false);
            fourthCircleText.text = (a + 2).ToString();
            fourthCircleImage.SetActive(false);
        }
        else if (a % 4 == 3)
        {
            firstCircleText.enabled = false;
            firstCircleImage.SetActive(true);
            firstCircleImage.GetComponent<Image>().sprite = check;
            secondCircleText.enabled = false;
            secondCircleImage.SetActive(true);
            secondCircleImage.GetComponent<Image>().sprite = check;
            thirdCircleText.text = a.ToString();
            thirdCircleImage.SetActive(true);
            fourthCircleText.text = (a + 1).ToString();
            fourthCircleImage.SetActive(false);
        }
        else
        {
            firstCircleText.enabled = false;
            firstCircleImage.SetActive(true);
            firstCircleImage.GetComponent<Image>().sprite = check;
            secondCircleText.enabled = false;
            secondCircleImage.SetActive(true);
            secondCircleImage.GetComponent<Image>().sprite = check;
            thirdCircleText.enabled = false;
            thirdCircleImage.SetActive(true);
            thirdCircleImage.GetComponent<Image>().sprite = check;
            fourthCircleText.text = a.ToString();
            fourthCircleImage.SetActive(true);
        }

    }
}
