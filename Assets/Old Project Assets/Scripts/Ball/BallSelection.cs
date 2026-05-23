//using NA;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class BallSelection : MonoBehaviour
//{

//    public Transform camTransform;
//    public Transform particlesCamTransform;
//    //public Button left;
//    //public Button right;
//    public Balls[] balls;
//    public float m_TurnSmoothing;

//    private int numberOfBalls = 4;
//    private int ballIndex;
//    private int particleIndex;

//    private Vector3 target_position;
//    [SerializeField]
//    private Button selectButton;
//    [SerializeField]
//    private Button buyButton;
//    //   [SerializeField]
//    //  private Image buyImage;
//    [SerializeField]
//    private Text[] buyPrice;
//    [SerializeField]
//    private Text[] particlesBuyPrice;
//    private int unlockedBalls;

//    public GameObject[] particlesEffects;
//    public GameObject getCoinsPanel;

//    public GameObject left;
//    public GameObject right;

//    public GameObject getCoins;
//    private void Start()
//    {
//        //PlayerPrefs.SetInt("selectedball",0);
//        ballIndex = PlayerPrefs.GetInt("selectedball");
//        particleIndex = PlayerPrefs.GetInt("particles");
//        // unlockedBalls = PlayerPrefs.GetInt("unlockedballs");
//        Debug.Log(ballIndex);

//        target_position = new Vector3(balls[ballIndex].ballTransform.position.x, balls[ballIndex].ballTransform.position.y + 2f, balls[ballIndex].ballTransform.position.z - 6);
//        camTransform.SetPositionAndRotation(target_position, camTransform.rotation);

//        for (int i = 0; i < buyPrice.Length; i++)
//        {
//            buyPrice[i].text = balls[i].ballsPrice.ToString();
//        }
//        for (int i = 0; i < particlesBuyPrice.Length; i++)
//        {
//            particlesBuyPrice[i].text = balls[i].particlesPrice.ToString();
//        }


//    }
//    public void Left()
//    {

//        ballIndex--;
//        Debug.Log(ballIndex);
//        if (ballIndex < 0)
//        {
//            ballIndex = balls.Length - 1;
//        }

//        if (balls[ballIndex].ballsPrice == 0)
//        {
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //  buyImage.gameObject.SetActive(false);
//        }
//        else if (PlayerPrefs.GetInt("unlockedBalls" + ballIndex) == 0)
//        {
//            buyButton.gameObject.SetActive(true);
//            if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
//            {
//                buyButton.interactable = true;
//            }
//            else
//            {
//                buyButton.interactable = false;
//            }
//            selectButton.gameObject.SetActive(false);
//            //  buyImage.gameObject.SetActive(true);
//            // buyPrice.text = balls[ballIndex].ballsPrice.ToString();
//        }
//        else
//        {
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //  buyImage.gameObject.SetActive(false);
//        }
//        target_position = new Vector3(balls[ballIndex].ballTransform.position.x, balls[ballIndex].ballTransform.position.y + 2f, balls[ballIndex].ballTransform.position.z - 6);
//    }

//    public void Right()
//    {
//        ballIndex++;
//        Debug.Log(ballIndex);
//        if (ballIndex >= balls.Length)
//        {
//            ballIndex = 0;
//        }

//        if (balls[ballIndex].ballsPrice == 0)
//        {
//            Debug.Log("price 0");
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //  buyImage.gameObject.SetActive(false);
//        }
//        else if (PlayerPrefs.GetInt("unlockedBalls" + ballIndex) == 0)
//        {

//            buyButton.gameObject.SetActive(true);
//            if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
//            {
//                buyButton.interactable = true;
//            }
//            else
//            {
//                buyButton.interactable = false;
//            }
//            selectButton.gameObject.SetActive(false);
//            //   buyImage.gameObject.SetActive(true);
//            // //  buyPrice.text = balls[ballIndex].ballsPrice.ToString();
//        }
//        else
//        {
//            Debug.Log("else chala");
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //    buyImage.gameObject.SetActive(false);
//        }
//        target_position = new Vector3(balls[ballIndex].ballTransform.position.x, balls[ballIndex].ballTransform.position.y + 2f, balls[ballIndex].ballTransform.position.z - 6);
//    }

//    public void SelectBall(int a)
//    {
//        ballIndex = a;
//        if (ballIndex < 0)
//        {
//            ballIndex = balls.Length - 1;
//        }

//        if (balls[ballIndex].ballsPrice == 0)
//        {
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //    buyImage.gameObject.SetActive(false);
//        }
//        else if (PlayerPrefs.GetInt("unlockedBalls" + ballIndex) == 0)
//        {
//            buyButton.gameObject.SetActive(true);
//            if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
//            {
//                buyButton.interactable = true;
//            }
//            else
//            {
//                buyButton.interactable = false;
//            }
//            selectButton.gameObject.SetActive(false);
//            //    buyImage.gameObject.SetActive(true);
//            //  buyPrice.text = balls[ballIndex].ballsPrice.ToString();
//        }
//        else
//        {
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //   buyImage.gameObject.SetActive(false);
//        }
//        target_position = new Vector3(balls[ballIndex].ballTransform.position.x, balls[ballIndex].ballTransform.position.y + 2f, balls[ballIndex].ballTransform.position.z - 6);

//    }
//    public void SelectTrail(int b)
//    {

//        particleIndex = b;
//        if (particleIndex < 0)
//        {
//            particleIndex = balls.Length - 1;
//        }

//        if (balls[particleIndex].particlesPrice == 0)
//        {
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //    buyImage.gameObject.SetActive(false);
//        }
//        else if (PlayerPrefs.GetInt("unlockedparticles" + particleIndex) == 0)
//        {
//            buyButton.gameObject.SetActive(true);
//            if (PlayerPrefs.GetInt("coins") >= balls[particleIndex].particlesPrice)
//            {
//                buyButton.interactable = true;
//            }
//            else
//            {
//                buyButton.interactable = false;
//            }
//            selectButton.gameObject.SetActive(false);
//            //    buyImage.gameObject.SetActive(true);
//            //  buyPrice.text = balls[ballIndex].ballsPrice.ToString();
//        }
//        else
//        {
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//            //   buyImage.gameObject.SetActive(false);
//        }
//        for (int i = 0; i < particlesEffects.Length; i++)
//        {
//            particlesEffects[i].SetActive(false);
//        }
//        particlesEffects[particleIndex].SetActive(true);
//        //  target_position = new Vector3(balls[ballIndex].ballTransform.position.x, balls[ballIndex].ballTransform.position.y + 2.5f, balls[ballIndex].ballTransform.position.z - 6);


//    }

//    public void Select()
//    {
//        PlayerPrefs.SetInt("selectedball", ballIndex);
//        SceneManager.LoadScene(2);
//    }

//    public void Buy()
//    {
//        if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
//        {
//            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - balls[ballIndex].ballsPrice);
//            PlayerPrefs.SetInt("unlockedBalls" + ballIndex, 1);
//            buyButton.gameObject.SetActive(false);
//            selectButton.gameObject.SetActive(true);
//        }
//        // PlayerPrefs.SetInt("selectedball", ballIndex)
//    }

//    public void Get500Coins()
//    {
//        ButtonClick();
//         Get500CoinsRV();

//       //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(Get500CoinsRV);
//       //dnt AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//    }

//    public void Get500CoinsRV()
//    {
//        getCoinsPanel.SetActive(true);
//        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 500);
//        SelectBall(ballIndex);
//    }

//    public void Back()
//    {
//        SceneManager.LoadScene(2);
//    }

//    private void Update()
//    {
//        if (m_TurnSmoothing > 0)
//        {
//            camTransform.position = Vector3.Slerp(camTransform.position, target_position, m_TurnSmoothing * Time.deltaTime);
//            balls[ballIndex].ballTransform.Rotate(0f, 0.3f, 0f, Space.Self);
//        }
//        else
//        {

//        }
//    }

//    public void ParticlesSelection()
//    {
//        left.SetActive(false);
//        right.SetActive(false);
//        particlesCamTransform.gameObject.SetActive(true);
//        camTransform.gameObject.SetActive(false);
//        SelectTrail(particleIndex);

//    }

//    public void BallSelectionStart()
//    {
//        left.SetActive(false);
//        right.SetActive(false);
//        particlesCamTransform.gameObject.SetActive(false);
//        camTransform.gameObject.SetActive(true);
//    }

//    public void GetITButton()
//    {
//        ButtonClick();
//        Invoke("GetITButtonDone",2.0f);

//    }
//    public void GetITButtonDone()
//    {


//        getCoins.SetActive(false);
//    }

//    public void ButtonClick()
//    {
//        SoundsManager.Instance.ButtonClickPlay();


//    }

//}

//[System.Serializable]
//public class Balls
//{
//    public Transform ballTransform;
//    public int ballsPrice;
//    public int particlesPrice;
//}
