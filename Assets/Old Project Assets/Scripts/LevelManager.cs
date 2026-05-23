using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NA;
using NA.Vehicles.Ball;
//using MoreMountains.NiceVibrations;
using DG.Tweening;
//using NA.Utility;
using UnityStandardAssets.Utility;
using System.Security.Cryptography.X509Certificates;
//using UnityStandardAssets.Utility;

public class LevelManager : MonoBehaviour//SimpleSingleton<LevelManager>
{
    // public static LevelManager Instance;
    [System.Serializable]
    public class Levels
    {
        public int levelIndex;
        public int levelReward;
        public int skyboxIndex;
        //  public GameObject levelPrefab;
    }


    [System.Serializable]
    public class Balls
    {
        //  public Transform ballTransform;
        public int ballsPrice;
        public int particlesPrice;
        public int skyboxPrice;
    }

    void Awake()
    {
        // Instance = this;
        Current_Level = PlayerPrefs.GetInt("CurrentLevel");
        Current_Coin = PlayerPrefs.GetInt("coins");
    }

    [Header("==> Scene")]
    public string gp_Name;
    public float gp_Reload;

    public float Lc_Next;

    [Space(10)]
    [Header("==> Just Kiss")]
    public int K_Time;
    public GameObject K_Obj;

    public void Btn_Kiss_Active()
    {
        K_Obj.SetActive(false);
        Btn_Kiss_On();
    }

    void Btn_Kiss_On()
    {
        K_Obj.SetActive(true);
        Invoke(nameof(Btn_Kiss_Off), K_Time);
    }

    void Btn_Kiss_Off()
    {
        K_Obj.SetActive(false);
    }

    [Header("==> SSS_1")]
    public GameObject _Temp_MG;
    public Transform currentCheckpointStore;
    GameObject TempObj;

    public void ActiveMiniGamePanel(bool value)
    {
        // SSS_1
    }

    public void GetReffObj(GameObject temp)
    {
        TempObj = temp;
    }

    [Space(20)]
    public int Current_Coin;
    public int Current_Level;
    public bool Lvl_Rst_Rnd;
    public int Total_Level;
    public bool LeveleCompletedCheck = false;


    [Header("Player")]
    public GameObject _Swp;

    [Header("Player")]
    public GameObject Player_Ball;
    public GameObject Player_Cube;
    public GameObject Player_Mesh;
    public Rigidbody Player_Rb;

    [Header("Water // Lava")]
    public bool Water_Lava;
    public bool Water_Lava_Fog;
    public DropBoundary DropBoundary;
    public ParticleSystem Drop_Splash;

    [Header("Water")]
    public GameObject Btn_Water;
    public GameObject Water;
    public ParticleSystem Water_Splash;
    public Material Water_SkyBox;

    [Header("Lava")]
    public GameObject Btn_Lava;
    public GameObject Lava;
    public ParticleSystem Lava_Splash;
    public Material Lava_SkyBox;

    public void Btn_Water_Lava(bool xXx)
    {
        Water_Lava = xXx;
        if (Water_Lava == true) // Water
        {
            Btn_Water.SetActive(true);
            Water.SetActive(true);
            DropBoundary = Water.GetComponent<DropBoundary>();
            Drop_Splash = Water_Splash;
            Lava.SetActive(false);

            Water_Lava_Fog = false;
            RenderSettings.fog = false;
            RenderSettings.skybox = Water_SkyBox;
        }
        else // Lava
        {
            Btn_Lava.SetActive(true);
            Lava.SetActive(true);
            DropBoundary = Lava.GetComponent<DropBoundary>();
            Drop_Splash = Lava_Splash;
            Water.SetActive(false);

            Water_Lava_Fog = true;
            RenderSettings.fog = true;
            RenderSettings.skybox = Lava_SkyBox;
        }
    }


    [Header("Reward")]
    public GameObject BackCanvas;
    public GameObject Black_Canves;
    public GameObject Reward;

    [Header("Ball")]
    public SwitchBallType BallType;
    public Ball Ball_Ref;
    public BallRotation BallRotation_Ref;
    public float CurDrag, CurAngDrag;
    public float CurMass;
    public Animator LevelNumAnim;

    [Header("BreakAbleObjects")]
    public bool PaperBallChk;
    public bool MetalBallChk;
    public GameObject MetalBallBr;
    public GameObject PaperBallBr;
    public GameObject[] BreakAbleBalls;

    public GameObject skiplvlAD;
    public GameObject notEnoughCoins;

    private string m_Address;
    public GameObject m_LevelInstance;
    public GameObject[] _Levels;
    public Levels[] LevelsData;
    public int currentCheckpoint;
    public Transform currentCheckpointTransform;

    public int chance
    {
        get
        {
            return PlayerPrefs.GetInt("chance");
        }
    }
    [SerializeField] private Rigidbody playerBall;
    public GameObject player;
    public Image[] chanceImages;
    public Transform ballIcon;
    public GameObject pausePanel;
    public GameObject failedPanel;
    public GameObject completePanel;
    public GameObject selectSkyboxPanel;
    public GameObject mainPanel;
    public GameObject inputManager;
    public GameObject[] rotatingBalls;

    public GameObject coinsAnim;



    //public Material[] skyboxes;

    public int skyBoxIndex;
    public Text LevelNumber;
    public Text LevelNumber2;
    public Text OnCompleteLevelNumber;
    public GameObject plusOneCoin;
    public GameObject[] levelsSequence;
    public GameObject chancePanel;
    //public Transform ballSelectionBalls;
    // public Transform camTransform;
    // public Transform particlesCamTransform;
    //public Button left;
    //public Button right;
    public Balls[] balls;
    public Text[] BallsPrice;
    public Text[] ParticlePrice;
    public Text[] WorldPrice;
    public float m_TurnSmoothing;

    //  private int numberOfBalls = 4;
    private int ballIndex;
    private int particleIndex;

    private Vector3 target_position;
    [SerializeField]
    private Button selectButton;
    [SerializeField]
    private Button skyboxSelectButton;
    [SerializeField]
    private Button ParticlesSelectButton;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private Button skyboxBuyButton;
    [SerializeField]
    private Button particlesBuyButton;
    //[SerializeField]
    //private Image buyImage;
    [SerializeField]
    private Text buyPrice;
    [SerializeField]
    private Text particlesBuyPrice;
    [SerializeField]
    private Text skyboxBuyPrice;
    public Button SkipButton;
    public GameObject[] particlesEffects;
    public GameObject getCoinsPanel;
    public GameObject particlesSelection;
    public GameObject left;
    public GameObject right;
    public GameObject getCoins;
    public GameObject[] playerBalls;
    public GameObject PaperBall, MetalBall;
    public GameObject blobShadow;
    public GameObject gameplayBallSelection;
    // private int unlockedBalls;
    // public float ballSelectionZ = 0;

    public GameObject ChanceButtonsGamePlay;
    public GameObject PauseButtonsGamePlay;
    public AudioSource ballSelectionSound;
    public AudioSource particlesSelectionSound;
    public AudioSource settingsSound;

    public GameObject mainCanvas;
    public GameObject gameCanvas;
    public GameObject displayBalls;
    public GameObject RemoveAdsPanel;
    public bool _WB_Allow;
    public bool _WB_Active;
    public GameObject WelcomebackPanel;
    public AudioSource ballLoseSound;
    public AudioSource levelFailed;
    bool selectionIndex;

    [Header("Camera On Fail/Complete")]
    public float Distance;
    public float Height;
    public SmoothFollow FollowCamera;
    public Transform DummyPos;
    public Text BallSwitchTxt;
    public Image BackScreen;


    // FB Event
    int xXx_Kon;
    string xXx_Fb;

    public void Btn_FB_Call(string xXx)
    {
        xXx_Fb = xXx;
        FB_Event(xXx_Fb);
    }

    void FB_Event(string xXx)
    {
        xXx_Kon = Current_Level + 1;
        //if (Admob_other.Instance)
        //{
        //   // Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_" + xXx_Kon + xXx_Fb);
        //    print("FB:=>" + "Level_" + xXx_Kon + xXx_Fb);
        //}
    }
    void FB_Event_Ball()
    {
        xXx_Kon = Current_Level + 1;
        //if (Admob_other.Instance)
        //{
        //    //Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_" + xXx_Kon + "_Ball_" + ballIndex + "_Selected");
        //    print("FB:=>" + "Level_" + xXx_Kon + "_Ball_" + ballIndex + "_Selected");
        //}
    }

    void _WelcomeBackPanel()
    {
        if (PlayerPrefs.GetInt("welcomeback") == 1 && Splash.WelComeOn)
        {
            Splash.WelComeOn = false;
            _WB_Active = true;

            // Allow
            if (_WB_Allow == true)
            {
                if (PlayerPrefs.GetInt("Shop") == 0)
                {
                    FB_Event("_WB_IAP_Show");
                    WelcomebackPanel.SetActive(true);
                }
                else
                {
                    FB_Event("_WB_IAP_Buy");
                    WelcomebackPanel.SetActive(false);
                }
            }
            else
            {
                WelcomebackPanel.SetActive(false);
            }
        }
        else
        {
            Splash.WelComeOn = false;
            _WB_Active = false;
            PlayerPrefs.SetInt("welcomeback", 1);
        }
    }


    void OnEnable()
    {
        ////!! Btn_AO_Check(false);

        //LoadInLevel();
        //load_int();
        //_mr_hide();

        //xXx_Fb = "_Open";
        //Btn_FB_Call(xXx_Fb);

        //if (PlayerPrefs.GetInt("Skip") == 1)
        //{
        //    // int num = CurrentLevel + 1;
        //    // IncreaseLevel();
        //    // PlayerPrefs.SetInt("Skip", 0);
        //}

        //_WelcomeBackPanel();
        //_Swap_Chk();
        //_Net_Chk();

        //_Start();
    }

    void _Net_Chk()
    {
        if (Current_Level != 0)
        {
            PlayerPrefs.SetInt("Internet_Allow", 1);
        }
    }
    void _Swap_Chk()
    {
        if (PlayerPrefs.GetInt("Swap_Hand") == 0)
        {
            _Swp.SetActive(true);
        }
        else
        {
            _Swp.SetActive(false);
        }
    }

    void _Start()
    {
        int xXx = Current_Level + 1;
        LevelNumber.text = (xXx).ToString();
        LevelNumber2.text = (xXx).ToString();

        if (OnCompleteLevelNumber != null)
        {
            OnCompleteLevelNumber.text = (xXx).ToString();
        }

        BackScreen.DOFade(1, 1.5f).OnComplete(delegate
        {
            BackScreen.DOFade(0, 1f).OnComplete(delegate
            {
                BackCanvas.SetActive(false);
                BackScreen.gameObject.SetActive(false);
            });
        });

        // load_bann();
        PlayerPrefs.SetInt("chance", 5);

        // WellCome Back

        PlayerPrefs.SetInt("selectedskybox", 0);
        //skyBoxIndex = PlayerPrefs.GetInt("selectedskybox");

        PlayerPrefs.SetInt("unlockedSkybox" + 0, 1);
        PlayerPrefs.SetInt("unlockedBalls" + 0, 1);
        PlayerPrefs.SetInt("unlockedparticles" + 0, 1);

        //RenderSettings.skybox = skyboxes[LevelsData[PlayerPrefs.GetInt("CurrentLevel")].skyboxIndex];
        //DynamicGI.UpdateEnvironment();
        ChanceSetCallBack(false);
        SetSequence();

        //Ball On Here 
        SetPlayerCurrentBall();
        SetPlayerCurrentParticle();

        FollowCamera.CameraOnBack();
        if (AudioManger_Custom.Instance)
            AudioManger_Custom.Instance.SoundSource.enabled = false;

    }

    public void SetPlayerCurrentBall()
    {
        for (int i = 0; i < playerBalls.Length; i++)
        {
            playerBalls[i].SetActive(false);
        }
        playerBalls[SelectedBallIndex].SetActive(true);
    }
    public void SetPlayerCurrentParticle()
    {
        for (int i = 0; i < particlesEffects.Length; i++)
        {
            particlesEffects[i].SetActive(false);
        }
        particlesEffects[SelectedParticleIndex].SetActive(true);
    }
    public int SelectedBallIndex
    {
        get { return PlayerPrefs.GetInt("SelectedBallIndex", 0); }
        set { PlayerPrefs.SetInt("SelectedBallIndex", value); }
    }

    public int SelectedParticleIndex
    {
        get { return PlayerPrefs.GetInt("SelectedParticleIndex", 0); }
        set { PlayerPrefs.SetInt("SelectedParticleIndex", value); }
    }

    #region Level Data
    void LoadInLevel()
    {
        player.SetActive(true);
        int randomIndex = Current_Level;
        Debug.Log("Random Number " + randomIndex);

        int totalLength = _Levels.Length - 1;
        if (randomIndex > totalLength)
        {
            randomIndex = Random.Range(3, totalLength);
        }

        m_LevelInstance = _Levels[randomIndex];
        m_LevelInstance.SetActive(true);
    }

    bool IncreaseLevelOneTime = false;
    public void IncreaseLevel()
    {
        if (!IncreaseLevelOneTime)
        {
            IncreaseLevelOneTime = true;

            int xXx = Current_Level + 1;
            Inc_Lvl(xXx);
        }
    }
    #endregion
    public void CameraOnFail()
    {
        FollowCamera.distance = 2f;
        FollowCamera.height = 2f;
        FollowCamera.reachDamping = 200f;
        FollowCamera.heightDamping = 1;
        FollowCamera.FailCheck = true;
        FollowCamera.startMove = false;
        //FollowCamera.height = Height;
    }
    public void _loadBannerTest()
    {
        // Aqib
        //AdmobAdsManager_InfiSingle.Instance?.LoadSmallBanner();
    }
    public void _ShowBannerTest()
    {
        // Aqib
        //AdmobAdsManager_InfiSingle.Instance?.ShowSmallBanner();
    }
    public void _loadInterTest()
    {
        load_int();

    }
    public void _ShowInterTest()
    {
        show_int();
    }
    public void _loadRewardTest()
    {
        load_rew();
    }
    public void _ShowRewardTest()
    {
        // Aqib

        Number_xXx = 4;
        show_rew();
        //reward
    }
    void reward()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");
    }
    void Notreward()
    {

    }
    void Reward_Active(int xXx)
    {
        if (xXx == 0)
        {
            Reward.SetActive(false);
        }
        else
        {
            Reward.SetActive(true);
        }
    }
    void load_bann()
    {
        //if (AdmobAdsManager_InfiSingle.Instance)
        //    if (!AdmobAdsManager_InfiSingle.Instance.IsSmallBannerReady())
        //     {
        //      AdmobAdsManager_InfiSingle.Instance.LoadSmallBanner();
        //     }
    }
    void bann()
    {
        // Aqib
        //
        //if (AdmobAdsManager_InfiSingle.Instance)
        //    if (AdmobAdsManager_InfiSingle.Instance.IsSmallBannerReady())
        //    {
        //      AdmobAdsManager_InfiSingle.Instance.ShowSmallBanner();
        //    }
    }
    public void SetSequence()
    {
        int a = Current_Level;
        a = a % 4;
        int b = Current_Level - a;
        for (int i = 0; i < 4; i++)
        {
            if (i < a)
            {
                levelsSequence[i].transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (i == a)
            {
                levelsSequence[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (i > a)
            {
                levelsSequence[i].transform.GetChild(0).gameObject.SetActive(true);
            }

            levelsSequence[i].transform.GetChild(2).gameObject.GetComponent<Text>().text = (b + i + 1).ToString();

        }


        //if(a==0)
        //{
        //    levelsSequence[3].transform.GetComponent<Text>().text = PlayerPrefs.GetInt("CurrentLevel").ToString();
        //}
        //else if (a == 1)
        //{

        //}
        //else if (a == 2)
        //{

        //}
        //else if (a == 3)
        //{

        //}
    }
    // Swap
    public void Paly()
    {
        //!! Btn_AO_Check(true);

        PlayerPrefs.SetInt("Swap_Hand", 1);

        xXx_Fb = "_Swap";
        Btn_FB_Call(xXx_Fb);

        displayBalls.SetActive(true);
        LevelNumAnim.gameObject.SetActive(false);
        Invoke(nameof(DelayMainCanvesOff), .2f);
        //Destroy(mainCanvas, 0.2f);
    }
    void DelayMainCanvesOff()
    {
        mainCanvas.SetActive(false);
    }
    public bool isCompleted = false;
    public bool isFailed = false;

    void Inc_Lvl(int xXx)
    {
        PlayerPrefs.SetInt("CurrentLevel", xXx);
    }

    // Level Complete
    public void InitComplete()
    {
        // Btn_AO_Check(false);

        if (!isCompleted)
        {
            isCompleted = true;

            if (Current_Level <= Total_Level)
            {
                IncreaseLevel();
            }
            else
            {
                if (Lvl_Rst_Rnd == true)
                {
                    Inc_Lvl(0);
                }
                else
                {
                    IncreaseLevel();
                }
            }

            player.GetComponent<Rigidbody>().isKinematic = true;
            gameCanvas.SetActive(false);
            displayBalls.SetActive(false);
            //Destroy(gameCanvas);
            //Destroy(displayBalls);
            //Invoke("ActivatePanel", 0);
            ActivatePanel();

            xXx_Fb = "_Com";
            Btn_FB_Call(xXx_Fb);
        }
    }

    void ActivatePanel()
    {
        Time.timeScale = 1;
        SoundsManager.Instance.PlayBGMusicStop();
        completePanel.SetActive(true);
        if (PlayerPrefs.GetInt("music") == 1)
        {
            // completePanel.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            // completePanel.GetComponent<AudioSource>().volume = 1;
        }
    }

    public void LevelComplete()
    {
        load_int();
        Invoke(nameof(DeactivateLevel), 1f);
        SoundsManager.Instance.ButtonClickPlay();
        //MMVibrationManager.Haptic(HapticTypes.HeavyImpact);

        PlayerPrefs.SetInt("reward", LevelsData[Current_Level].levelReward);
        CoinReward.Instance.CountCoins(LevelsData[Current_Level].levelReward);
    }

    public void Btn_Auto_Coin_LC()
    {
        Invoke(nameof(DeactivateLevel), 1f);
        SoundsManager.Instance.ButtonClickPlay();
        PlayerPrefs.SetInt("reward", LevelsData[Current_Level].levelReward);
        CoinReward.Instance.CountCoins(LevelsData[Current_Level].levelReward);
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevel(Lc_Next));
    }
    void DeactivateLevel()
    {
        if (m_LevelInstance)
            m_LevelInstance.SetActive(false);
        player.SetActive(false);
    }

    IEnumerator LoadLevel(float a)
    {
        Time.timeScale = 1;
        // _mr_show();
        yield return new WaitForSeconds(a);

        _reload();
    }

    void _reload()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        _mr_show();

        SoundsManager.Instance.ButtonClickPlay();
        SoundsManager.Instance.PlayBGMusicStop();
       // BallUserControl.Instance.rollingSound.Pause();
        pausePanel.SetActive(true);

        xXx_Fb = "_Pause";
        Btn_FB_Call(xXx_Fb);

        Time.timeScale = 0f;
    }

    public void Continue()
    {
        _mr_hide();

        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        SoundsManager.Instance.ButtonClickPlay();
        SoundsManager.Instance.PlayBGMusic();
        //  BallUserControl.Instance.rollingSound.Play();
    }

    public void Restart()
    {
        StartCoroutine(LoadLevel(0.2f));
    }


    public void Refill()
    {
        load_rew();
        SoundsManager.Instance.ButtonClickPlay();
        //BallUserControl.Instance.rollingSound.Play();

        show_Refil();
    }
    void show_Refil()
    {
        // Aqib
        Number_xXx = 3;
        show_rew();
        // RestartLevel
        //Reward_Active(0);
    }
    void RestartLevel()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        _mr_hide();

        Reward_Active(0);
        SoundsManager.Instance.ButtonClickPlay();
       // BallUserControl.Instance.rollingSound.Play();
       // BallUserControl.Instance.GetComponent<Rigidbody>().isKinematic = true;
        RespawnPlayer();
    }

    void RewardNotShow_RestartLevel()
    {
        SoundsManager.Instance.ButtonClickPlay();
    }

    public void Claim2X()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //BallUserControl.Instance.rollingSound.Play();

        load_rew();
        Reward_Active(1);
        Invoke(nameof(show_X2), .5f);
    }
    void show_X2()
    {
        // Aqib
        Number_xXx = 2;
        show_rew();
        // X2
        Reward_Active(0);
    }
    void X2()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        Reward_Active(0);
        coinsAnim.SetActive(true);
        //  CoinsManager.Instance.AddCoins(CoinsManager.Instance.levelsRewards[PlayerPrefs.GetInt("CurrentLevel") * 2]);

        int xXx = Current_Level + 1;
        Inc_Lvl(xXx);

        StartCoroutine(LoadLevel(0.20f));
    }
    void RewardNotLoad_X2()
    {

    }
    public GameObject SkipLevelLoading;
    public void SkipLevel(int xXx)
    {
        skiplvlAD.SetActive(true);
        SetStopBall();
        //self   SkipButton.interactable = false;
        SoundsManager.Instance.ButtonClickPlay();
      //  BallUserControl.Instance.rollingSound.Play();

        Get_Coins();
    }
    public void Get_Coins()
    {
        load_rew();
        skiplvlAD.SetActive(false);

        waitAD_now_skip();
    }
    void waitAD_now_skip()
    {
        SetMoveBall();
        // Aqib
        RewardNotAloat_Chk_Coins_skip();
        Number_xXx = 0;
        show_rew();
        // Chk_Coins_skip
        //Reward_Active(0);
    }
    void Chk_Coins_skip()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        SkipLevelLoading.SetActive(true);
        Reward_Active(0);
        SkipLevelReward();
        //coin = PlayerPrefs.GetInt("Total_Currency");
        //coin = coin + coin;
        //PlayerPrefs.SetInt("Total_Currency", coin);
    }
    void RewardNotAloat_Chk_Coins_skip()
    {
        SetStopBall();
    }
    public void SkiActivate()
    {
        //self  SkipButton.interactable = true;
    }

    public void SkipLevelReward()
    {
        skiplvlAD.SetActive(false);
        Invoke(nameof(GiveReward), .1f);
    }

    void GiveReward()
    {
        int xXx = Current_Level + 1;
        Inc_Lvl(xXx);

        // PlayerPrefs.SetInt("Skip", 1);
        PlayerPrefs.Save();
        StartCoroutine(LoadLevel(0.50f));
    }
    public void LevelFailedINIT()
    {
        if (!isCompleted)
            LevelFailed();
        //  chancePanel.SetActive(true);
    }

    public void LevelFailed()
    {
        load_int();
        if (PlayerPrefs.GetInt("chance") <= 0)
        {
            //  levelFailed.Play();
            if (!isFailed)
                isFailed = true;
            failedPanel.SetActive(true);
            //  StartCoroutine(LoadLevel(0.2f));

            //   Reward_Active(1);
            // Aqib



            //if (Admob_other.Instance)
            //{
            //    show_int();
            //    _mr_show();

            //    xXx_Fb = "_Fail";
            //    Btn_FB_Call(xXx_Fb);
            //}
        }
        else
        {
            //  ballLoseSound.Play();
            if (currentCheckpointTransform == null)
            {
                // Aqib
                //


                StartCoroutine(LoadLevel(0.2f));
            }
            else
            {
              //  BallUserControl.Instance.rb.isKinematic = true;
                SmoothFollow.Instance.startMove = false;
                int a = PlayerPrefs.GetInt("chance") - 1;
                //   Debug.Log("A " + a);
                PlayerPrefs.SetInt("chance", a);
                PlayerPrefs.Save();
                ChanceSetCallBack(false);
                RespawnPlayer();

                // Reward_Active(1);
                // Aqib
                show_int();
            }


        }

    }

    public void RespawnPlayer()
    {
        FollowCamera.FailCheck = false;
        SmoothFollow.Instance.distance = SmoothFollow.Instance.GamePlayCamera.Distance;
        SmoothFollow.Instance.height = SmoothFollow.Instance.GamePlayCamera.HeightSub;
        SmoothFollow.Instance.reachDamping = SmoothFollow.Instance.GamePlayCamera.ReachDamping;
        SmoothFollow.Instance.heightDamping = SmoothFollow.Instance.GamePlayCamera.HeightDamping;

        //BallUserControl.Instance.rb.angularDamping = CurAngDrag;
        //BallUserControl.Instance.rb.linearDamping = CurDrag;
        //BallUserControl.Instance.rb.constraints = ~RigidbodyConstraints.FreezeAll;
        DropBoundary.once = false;
        //if (currentCheckpointTransform.childCount > 0)
        //{
        //    BallUserControl.Instance.ReSpawnPlayer(currentCheckpointTransform.GetChild(1).transform);
        //    Debug.Log("Child position ");
        //}
        //else
        //{
      //  BallUserControl.Instance.ReSpawnPlayer(currentCheckpointTransform.transform);
        //Debug.Log("Parent position");
        //}
        FollowCamera.startMove = false;
        FollowCamera.CameraOnBack();
    }
    public void SetChanceUi(bool a)
    {
        //  Debug.Log("Chance = " + chance);
        //  chance =  PlayerPrefs.GetInt("chance");
        if (chance > 5)
        {
            return;
        }
        //ballIcon.gameObject.SetActive(true);
        //ballIcon.DOMove(chanceImages[chance - 1].transform.position, 01.0f).OnComplete(() => ChanceSetCallBack(a));
        //ballIcon.DOScale(0.2f, 1.0f);
        // ballIcon.DOComplete();


    }
    public void SkyboxSelection()
    {
        SoundsManager.Instance.ButtonClickPlay();
        if (PlayerPrefs.GetInt("music") == 1)
        {
            selectSkyboxPanel.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            selectSkyboxPanel.GetComponent<AudioSource>().volume = 1;
        }
        // BallUserControl.Instance.rollingSound.Play();
        skyBoxIndex = PlayerPrefs.GetInt("selectedskybox");
        LevelNumber.gameObject.SetActive(false);
        SkipButton.gameObject.SetActive(false);
        selectSkyboxPanel.SetActive(true);
        mainPanel.SetActive(false);
        inputManager.SetActive(false);

        for (int i = 0; i < WorldPrice.Length; i++)
        {
            if (PlayerPrefs.GetInt("unlockedSkybox" + i) == 0)
                WorldPrice[i].text = balls[i].particlesPrice.ToString();
            else
                WorldPrice[i].text = "Free";
        }

    }
    #region SkyBoxSelection
    //public void LeftChangeSkybox()
    //{
    //    SoundsManager.Instance.ButtonClickPlay();
    //    //  BallUserControl.Instance.rollingSound.Play();
    //    skyBoxIndex--;
    //    if (skyBoxIndex < 0)
    //    {
    //        skyBoxIndex = skyboxes.Length - 1;
    //    }
    //    if (balls[skyBoxIndex].ballsPrice == 0)
    //    {
    //        skyboxBuyButton.gameObject.SetActive(false);
    //        skyboxSelectButton.gameObject.SetActive(true);
    //        //  buyImage.gameObject.SetActive(false);
    //    }
    //    else if (PlayerPrefs.GetInt("unlockedSkybox" + skyBoxIndex) == 0)
    //    {
    //        skyboxBuyButton.gameObject.SetActive(true);
    //        if (PlayerPrefs.GetInt("coins") >= balls[skyBoxIndex].skyboxPrice)
    //        {
    //            skyboxBuyButton.interactable = true;
    //        }
    //        else
    //        {
    //            //  skyboxBuyButton.interactable = false;
    //        }
    //        skyboxSelectButton.gameObject.SetActive(false);
    //        //  buyImage.gameObject.SetActive(true);
    //        // buyPrice.text = balls[ballIndex].ballsPrice.ToString();
    //    }
    //    else
    //    {
    //        skyboxBuyButton.gameObject.SetActive(false);
    //        skyboxSelectButton.gameObject.SetActive(true);
    //        //  buyImage.gameObject.SetActive(false);
    //    }
    //    skyboxBuyPrice.text = balls[skyBoxIndex].skyboxPrice.ToString();
    //    RenderSettings.skybox = skyboxes[skyBoxIndex];
    //    DynamicGI.UpdateEnvironment();
    //}

    //public void RightChangeSkybox()
    //{
    //    SoundsManager.Instance.ButtonClickPlay();
    //    //  BallUserControl.Instance.rollingSound.Play();
    //    skyBoxIndex++;
    //    if (skyBoxIndex >= skyboxes.Length)
    //    {
    //        skyBoxIndex = 0;
    //    }
    //    // skyBoxIndex++;

    //    if (balls[skyBoxIndex].ballsPrice == 0)
    //    {
    //        skyboxBuyButton.gameObject.SetActive(false);
    //        skyboxSelectButton.gameObject.SetActive(true);
    //        //  buyImage.gameObject.SetActive(false);
    //    }
    //    else if (PlayerPrefs.GetInt("unlockedskybox" + skyBoxIndex) == 0)
    //    {
    //        skyboxBuyButton.gameObject.SetActive(true);
    //        if (PlayerPrefs.GetInt("coins") >= balls[skyBoxIndex].skyboxPrice)
    //        {
    //            skyboxBuyButton.interactable = true;
    //        }
    //        else
    //        {
    //            // skyboxBuyButton.interactable = false;
    //        }
    //        skyboxSelectButton.gameObject.SetActive(false);
    //        //  buyImage.gameObject.SetActive(true);
    //        // buyPrice.text = balls[ballIndex].ballsPrice.ToString();
    //    }
    //    else
    //    {
    //        skyboxBuyButton.gameObject.SetActive(false);
    //        skyboxSelectButton.gameObject.SetActive(true);
    //        //  buyImage.gameObject.SetActive(false);
    //    }
    //    skyboxBuyPrice.text = balls[skyBoxIndex].skyboxPrice.ToString();
    //    RenderSettings.skybox = skyboxes[skyBoxIndex];
    //    DynamicGI.UpdateEnvironment();
    //}
    //public void SkyChangeBtn(int SkyNumber)
    //{
    //    SoundsManager.Instance.ButtonClickPlay();
    //    //  BallUserControl.Instance.rollingSound.Play();
    //    skyBoxIndex= SkyNumber;
    //    if (skyBoxIndex >= skyboxes.Length)
    //    {
    //        skyBoxIndex = 0;
    //    }
    //    // skyBoxIndex++;

    //    //if (balls[skyBoxIndex].ballsPrice == 0)
    //    //{
    //    //    skyboxBuyButton.gameObject.SetActive(false);
    //    //    skyboxSelectButton.gameObject.SetActive(true);
    //    //    //  buyImage.gameObject.SetActive(false);
    //    //}
    //    //else
    //    if (PlayerPrefs.GetInt("unlockedSkybox" + skyBoxIndex) == 0)
    //    {
    //        skyboxBuyButton.gameObject.SetActive(true);
    //        if (PlayerPrefs.GetInt("coins") >= balls[skyBoxIndex].skyboxPrice)
    //        {
    //            skyboxBuyButton.interactable = true;
    //        }
    //        else
    //        {
    //            // skyboxBuyButton.interactable = false;
    //        }
    //        skyboxSelectButton.gameObject.SetActive(false);
    //        //  buyImage.gameObject.SetActive(true);
    //        // buyPrice.text = balls[ballIndex].ballsPrice.ToString();
    //    }
    //    else
    //    {
    //        skyboxBuyButton.gameObject.SetActive(false);
    //        skyboxSelectButton.gameObject.SetActive(true);
    //        //  buyImage.gameObject.SetActive(false);
    //    }
    //    skyboxBuyPrice.text = balls[skyBoxIndex].skyboxPrice.ToString();
    //    RenderSettings.skybox = skyboxes[skyBoxIndex];
    //    DynamicGI.UpdateEnvironment();
    //}
    //public void SelectSkbox()
    //{
    //    SoundsManager.Instance.ButtonClickPlay();
    //    //  BallUserControl.Instance.rollingSound.Play();
    //    PlayerPrefs.SetInt("selectedskybox", skyBoxIndex);
    //    selectSkyboxPanel.SetActive(false);
    //    mainPanel.SetActive(true);
    //    inputManager.SetActive(true);
    //    LevelNumber.gameObject.SetActive(true);
    //    RenderSettings.skybox = skyboxes[PlayerPrefs.GetInt("selectedskybox")];
    //    DynamicGI.UpdateEnvironment();

    //}
    //public void SkyboxBackButton()
    //{
    //    blobShadow.SetActive(true);
    //    playerBalls[PlayerPrefs.GetInt("selectedball")].SetActive(true);

    //    particlesSelection.gameObject.SetActive(false);
    //    //ballSelectionBalls.gameObject.SetActive(false);
    //    mainPanel.SetActive(true);
    //    inputManager.SetActive(true);
    //    LevelNumber.gameObject.SetActive(true);
    //    LevelNumber.gameObject.SetActive(true);
    //    //RenderSettings.skybox = skyboxes[PlayerPrefs.GetInt("selectedskybox")];
    //    DynamicGI.UpdateEnvironment();
    //}

    //public void BuySkyBox()
    //{
    //    SoundsManager.Instance.ButtonClickPlay();
    //    if (PlayerPrefs.GetInt("coins") >= balls[skyBoxIndex].skyboxPrice)
    //    {
    //        // PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - balls[ballIndex].ballsPrice);
    //        CoinsManager.Instance.MinusCoins(balls[skyBoxIndex].skyboxPrice);
    //        PlayerPrefs.SetInt("unlockedSkybox" + skyBoxIndex, 1);
    //        Debug.Log("Sky Id " + skyBoxIndex + "  purchased " + PlayerPrefs.GetInt("unlockedSkybox" + skyBoxIndex));
    //        skyboxBuyButton.gameObject.SetActive(false);
    //        skyboxSelectButton.gameObject.SetActive(true);
    //    }
    //    else
    //    {
    //        notEnoughCoins.SetActive(true);
    //    }
    //}
    #endregion

    #region BallSeletion
    public void BallSelection(bool a)
    {
        SoundsManager.Instance.ButtonClickPlay();
        // completePanel.SetActive(true);
        if (PlayerPrefs.GetInt("music") == 1)
        {
            ballSelectionSound.volume = 0;
        }
        else
        {
            ballSelectionSound.volume = 1;
        }
        selectionIndex = a;
        if (a)
        {
            blobShadow.SetActive(false);
            ballIndex = SelectedBallIndex;//PlayerPrefs.GetInt("selectedball")
            particleIndex = SelectedParticleIndex;
            playerBall.constraints = RigidbodyConstraints.FreezeAll;
            // unlockedBalls = PlayerPrefs.GetInt("unlockedballs");
            //  Debug.Log(ballIndex);
            for (int i = 0; i < playerBalls.Length; i++)
            {
                playerBalls[i].SetActive(false);
            }
            playerBalls[ballIndex].SetActive(true);
            //ballSelectionBalls.gameObject.SetActive(true);
            //ballSelectionZ = (ballIndex * 5) + 25;
            //ballSelectionBalls.position = new Vector3(ballSelectionBalls.position.x, ballSelectionBalls.position.y, ballSelectionZ);
            //  camTransform.SetPositionAndRotation(target_position, camTransform.rotation);
            if (mainPanel)
                mainPanel.SetActive(false);
            inputManager.SetActive(false);
            LevelNumber.gameObject.SetActive(false);

            // buyPrice.text = balls[ballIndex].ballsPrice.ToString();

            particlesBuyPrice.text = balls[ballIndex].particlesPrice.ToString();

        }
        else
        {
            blobShadow.SetActive(false);
            ballIndex = SelectedBallIndex;//PlayerPrefs.GetInt("selectedball")
            particleIndex = SelectedParticleIndex;
            playerBall.constraints = RigidbodyConstraints.FreezeAll;
            // unlockedBalls = PlayerPrefs.GetInt("unlockedballs");
            //   Debug.Log(ballIndex);

            for (int i = 0; i < playerBalls.Length; i++)
            {
                playerBalls[i].SetActive(false);
            }
            playerBalls[ballIndex].SetActive(true);

            //playerBalls[ballIndex].SetActive(false);
            //ballSelectionBalls.gameObject.SetActive(true);
            //ballSelectionZ = (ballIndex * 5) + 25;
            //ballSelectionBalls.position = new Vector3(ballSelectionBalls.position.x, ballSelectionBalls.position.y, ballSelectionZ);
            //  camTransform.SetPositionAndRotation(target_position, camTransform.rotation);
            if (mainPanel)
                mainPanel.SetActive(false);
            inputManager.SetActive(false);
            LevelNumber.gameObject.SetActive(false);

            PauseButtonsGamePlay.SetActive(false);
            SkipButton.gameObject.SetActive(false);
            gameplayBallSelection.SetActive(false);
            ChanceButtonsGamePlay.SetActive(false);
            // buyPrice.text = balls[ballIndex].ballsPrice.ToString();

            //   particlesBuyPrice.text = balls[ballIndex].ballsPrice.ToString();

        }

        //for (int i = 0; i < BallsPrice.Length; i++)
        //{
        //    if (PlayerPrefs.GetInt("unlockedBalls" + i) == 0)
        //        BallsPrice[i].text = balls[i].ballsPrice.ToString();
        //    else
        //        BallsPrice[i].text = "Free";
        //}


    }
    public void OnClickBallSelection(int valueIndex)
    {
        SoundsManager.Instance.ButtonClickPlay();

        ballIndex = valueIndex;

        Debug.Log(ballIndex);

        //if (balls[ballIndex].ballsPrice == 0)
        //{
        //    buyButton.gameObject.SetActive(false);
        //    selectButton.gameObject.SetActive(true);
        //    //  buyImage.gameObject.SetActive(false);
        //}
        //else if (PlayerPrefs.GetInt("unlockedBalls" + ballIndex) == 0)
        //{
        //    //buyButton.gameObject.SetActive(true);
        //    //if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
        //    //{
        //    //    buyButton.interactable = true;
        //    //}
        //    //else
        //    //{
        //    //    //  buyButton.interactable = false;
        //    //}
        //    //selectButton.gameObject.SetActive(false);
        //    //buyImage.gameObject.SetActive(true);
        //    //buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    //buyButton.gameObject.SetActive(false);
        //    //selectButton.gameObject.SetActive(true);
        //    //buyImage.gameObject.SetActive(false);
        //}

        // buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //for (int i = 0; i < playerBalls.Length; i++)
        //{
        //    playerBalls[i].SetActive(false);
        //}
        //playerBalls[ballIndex].SetActive(true);

    }
    public void BallSelectionLeft()
    {
        SoundsManager.Instance.ButtonClickPlay();

        //ballIndex--;
        //if (ballIndex < 0)
        //{
        //    ballIndex = playerBalls.Length - 1;
        //}
        //Debug.Log(ballIndex);

        //if (balls[ballIndex].ballsPrice == 0)
        //{
        //    buyButton.gameObject.SetActive(false);
        //    selectButton.gameObject.SetActive(true);
        //    //  buyImage.gameObject.SetActive(false);
        //}
        //else if (PlayerPrefs.GetInt("unlockedBalls" + ballIndex) == 0)
        //{
        //    //buyButton.gameObject.SetActive(true);
        //    //if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
        //    //{
        //    //    buyButton.interactable = true;
        //    //}
        //    //else
        //    //{
        //    //    //  buyButton.interactable = false;
        //    //}
        //    //selectButton.gameObject.SetActive(false);
        //    ////buyImage.gameObject.SetActive(true);
        //    //buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    buyButton.gameObject.SetActive(false);
        //    selectButton.gameObject.SetActive(true);
        //    //buyImage.gameObject.SetActive(false);
        //}

        //buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //for (int i = 0; i < playerBalls.Length; i++)
        //{
        //    playerBalls[i].SetActive(false);
        //}
        //playerBalls[ballIndex].SetActive(true);

    }
    public void BallSelectionRight()
    {
        //SoundsManager.Instance.ButtonClickPlay();
        //ballIndex++;
        //if (ballIndex >= playerBalls.Length)
        //{
        //    ballIndex = 0;
        //}
        //Debug.Log(ballIndex);

        //if (balls[ballIndex].ballsPrice == 0)
        //{
        //    //  Debug.Log("price 0");
        //    //buyButton.gameObject.SetActive(false);
        //    //selectButton.gameObject.SetActive(true);
        //    //  buyImage.gameObject.SetActive(false);
        //}
        //else if (PlayerPrefs.GetInt("unlockedBalls" + ballIndex) == 0)
        //{

        //    //buyButton.gameObject.SetActive(true);
        //    if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
        //    {
        //       // buyButton.interactable = true;
        //    }
        //    else
        //    {
        //        //  buyButton.interactable = false;
        //    }
        //    //selectButton.gameObject.SetActive(false);
        //    //buyImage.gameObject.SetActive(true);
        //    buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    //  Debug.Log("else chala");
        //   // buyButton.gameObject.SetActive(false);
        //   // selectButton.gameObject.SetActive(true);
        //    //buyImage.gameObject.SetActive(false);
        //}
        ////ballSelectionZ = (ballIndex * 5) + 25;
        ////ballSelectionBalls.DOMove(new Vector3(ballSelectionBalls.position.x, ballSelectionBalls.position.y, ballSelectionZ), 0.8f);
        //buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //for (int i = 0; i < playerBalls.Length; i++)
        //{
        //    playerBalls[i].SetActive(false);
        //}
        //playerBalls[ballIndex].SetActive(true);
        // particlesBuyPrice.text = balls[ballIndex].ballsPrice.ToString();
    }
    public void BallSelectionBtn(int BallNumber)
    {
        SoundsManager.Instance.ButtonClickPlay();
        ballIndex = BallNumber;
        //   Debug.Log(ballIndex);
        if (ballIndex >= balls.Length)
        {
            ballIndex = 0;
        }

        //if (balls[ballIndex].ballsPrice == 0)
        //{
        //    //  Debug.Log("price 0");
        //    buyButton.gameObject.SetActive(false);
        //    selectButton.gameObject.SetActive(true);
        //    //  buyImage.gameObject.SetActive(false);
        //}
        //else 
        //if (PlayerPrefs.GetInt("unlockedBalls" + ballIndex) == 0)
        //{

        //    //buyButton.gameObject.SetActive(true);
        //    if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
        //    {
        //       // buyButton.interactable = true;
        //    }
        //    else
        //    {
        //        //  buyButton.interactable = false;
        //    }
        //   // selectButton.gameObject.SetActive(false);
        //    //   buyImage.gameObject.SetActive(true);
        //    // //  buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    //  Debug.Log("else chala");
        //   // buyButton.gameObject.SetActive(false);
        //   // selectButton.gameObject.SetActive(true);
        //   // selectButton.gameObject.SetActive(true);
        //    //    buyImage.gameObject.SetActive(false);
        //}

        for (int i = 0; i < playerBalls.Length; i++)
        {
            playerBalls[i].SetActive(false);
        }
        playerBalls[ballIndex].SetActive(true);

        //ballSelectionZ = (ballIndex * 5) + 25;
        //ballSelectionBalls.DOMove(new Vector3(ballSelectionBalls.position.x, ballSelectionBalls.position.y, ballSelectionZ), 0.8f);
        //buyPrice.text = balls[ballIndex].ballsPrice.ToString();

        // particlesBuyPrice.text = balls[ballIndex].ballsPrice.ToString();
    }

    #endregion

    #region ParticleSelection
    public void ParticlesSelectionLeft()
    {
        //SoundsManager.Instance.ButtonClickPlay();
        //particleIndex--;
        ////  Debug.Log(particleIndex);
        //if (particleIndex < 0)
        //{
        //    particleIndex = particlesEffects.Length;
        //}

        ////if (balls[particleIndex].ballsPrice == 0)
        ////{
        ////    particlesBuyButton.gameObject.SetActive(false);
        ////    ParticlesSelectButton.gameObject.SetActive(true);
        ////    //  buyImage.gameObject.SetActive(false);
        ////}
        ////else 
        //if (PlayerPrefs.GetInt("unlockedparticles" + particleIndex) == 0)
        //{
        //    particlesBuyButton.gameObject.SetActive(true);
        //    if (PlayerPrefs.GetInt("coins") >= balls[particleIndex].particlesPrice)
        //    {
        //        particlesBuyButton.interactable = true;
        //    }
        //    else
        //    {
        //        //   particlesBuyButton.interactable = false;
        //    }
        //    ParticlesSelectButton.gameObject.SetActive(false);
        //    //  buyImage.gameObject.SetActive(true);
        //    // buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    particlesBuyButton.gameObject.SetActive(false);
        //    ParticlesSelectButton.gameObject.SetActive(true);
        //    //  buyImage.gameObject.SetActive(false);
        //}

        //for (int i = 0; i < particlesEffects.Length; i++)
        //{
        //    particlesEffects[i].SetActive(false);
        //}
        //if (particleIndex == 0)
        //{
        //    particlesEffects[particleIndex].SetActive(false);
        //    particlesBuyPrice.text = balls[particleIndex].particlesPrice.ToString();
        //    return;
        //    // 
        //}
        //else
        //{
        //    particlesEffects[particleIndex - 1].SetActive(true);
        //}
        ////  particlesBuyPrice.text = balls[ballIndex].particlesPrice.ToString();

        //particlesBuyPrice.text = balls[particleIndex].particlesPrice.ToString();
    }
    public void ParticlesSelectionBtn(int ParticleNumber)
    {
        //SoundsManager.Instance.ButtonClickPlay();
        //particleIndex= ParticleNumber;
        ////  Debug.Log(particleIndex);
        //if (particleIndex < 0)
        //{
        //    particleIndex = particlesEffects.Length;
        //}

        ////if (balls[particleIndex].ballsPrice == 0)
        ////{
        ////    particlesBuyButton.gameObject.SetActive(false);
        ////    ParticlesSelectButton.gameObject.SetActive(true);
        ////    //  buyImage.gameObject.SetActive(false);
        ////}
        ////else
        //if (PlayerPrefs.GetInt("unlockedparticles" + particleIndex) == 0)
        //{
        //    particlesBuyButton.gameObject.SetActive(true);
        //    if (PlayerPrefs.GetInt("coins") >= balls[particleIndex].particlesPrice)
        //    {
        //        particlesBuyButton.interactable = true;
        //    }
        //    else
        //    {
        //        //   particlesBuyButton.interactable = false;
        //    }
        //    ParticlesSelectButton.gameObject.SetActive(false);
        //    //  buyImage.gameObject.SetActive(true);
        //    // buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    particlesBuyButton.gameObject.SetActive(false);
        //    ParticlesSelectButton.gameObject.SetActive(true);
        //    //  buyImage.gameObject.SetActive(false);
        //}

        //for (int i = 0; i < particlesEffects.Length; i++)
        //{
        //    particlesEffects[i].SetActive(false);
        //}
        //if (particleIndex == 0)
        //{
        //    particlesEffects[particleIndex].SetActive(false);
        //    particlesBuyPrice.text = balls[particleIndex].particlesPrice.ToString();
        //    return;
        //    // 
        //}
        //else
        //{
        //    particlesEffects[particleIndex - 1].SetActive(true);
        //}
        ////  particlesBuyPrice.text = balls[ballIndex].particlesPrice.ToString();

        //particlesBuyPrice.text = balls[particleIndex].particlesPrice.ToString();
    }

    public void ParticlesSelectionRight()
    {
        //SoundsManager.Instance.ButtonClickPlay();
        //particleIndex++;
        ////  Debug.Log(particleIndex);
        //if (particleIndex > particlesEffects.Length)
        //{
        //    particleIndex = 0;
        //}

        ////if (balls[particleIndex].ballsPrice == 0)
        ////{
        ////     Debug.Log("price 0");
        ////    particlesBuyButton.gameObject.SetActive(false);
        ////    ParticlesSelectButton.gameObject.SetActive(true);
        ////      buyImage.gameObject.SetActive(false);
        ////}
        ////else 
        //if (PlayerPrefs.GetInt("unlockedparticles" + particleIndex) == 0)
        //{

        //    particlesBuyButton.gameObject.SetActive(true);
        //    if (PlayerPrefs.GetInt("coins") >= balls[particleIndex].ballsPrice)
        //    {
        //        particlesBuyButton.interactable = true;
        //    }
        //    else
        //    {
        //        //  particlesBuyButton.interactable = false;
        //    }
        //    ParticlesSelectButton.gameObject.SetActive(false);
        //    //   buyImage.gameObject.SetActive(true);
        //    // //  buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    //  Debug.Log("else chala");
        //    particlesBuyButton.gameObject.SetActive(false);
        //    ParticlesSelectButton.gameObject.SetActive(true);
        //    //    buyImage.gameObject.SetActive(false);
        //}
        //for (int i = 0; i < particlesEffects.Length; i++)
        //{
        //    particlesEffects[i].SetActive(false);
        //}
        //if (particleIndex == 0)
        //{
        //    particlesEffects[particleIndex].SetActive(false);
        //    particlesBuyPrice.text = balls[particleIndex].particlesPrice.ToString();
        //    return;
        //    // 
        //}
        //else
        //{
        //    particlesEffects[particleIndex - 1].SetActive(true);
        //}
        //// particlesBuyPrice.text = balls[ballIndex].particlesPrice.ToString();

        //particlesBuyPrice.text = balls[particleIndex].particlesPrice.ToString();
    }
    public void ParticlesSelect()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //PlayerPrefs.SetInt("particles", particleIndex);
        //blobShadow.SetActive(true);
        //playerBalls[particleIndex].SetActive(true);
        //ballSelectionBalls.gameObject.SetActive(false);
    }

    public void ParticlesBuy()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //if (PlayerPrefs.GetInt("coins") >= balls[particleIndex].particlesPrice)
        //{
        //    // PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - balls[particleIndex].ballsPrice);
        //    CoinsManager.Instance.MinusCoins(balls[particleIndex].particlesPrice);
        //    PlayerPrefs.SetInt("unlockedparticles" + particleIndex, 1);
        //    particlesBuyButton.gameObject.SetActive(false);
        //    ParticlesSelectButton.gameObject.SetActive(true);
        //}
        //else
        //{
        //    notEnoughCoins.SetActive(true);
        //}
        // PlayerPrefs.SetInt("selectedball", ballIndex)
    }

    public void particlesBackButton()
    {
        blobShadow.SetActive(true);
        playerBalls[SelectedBallIndex].SetActive(true);//PlayerPrefs.GetInt("selectedball");
      //  BallUserControl.Instance.UpdateParticles();
        particlesSelection.gameObject.SetActive(false);
        Activity.Instance.TrackObj.SetActive(true);
        //ballSelectionBalls.gameObject.SetActive(false);
        mainPanel.SetActive(true);
        inputManager.SetActive(true);
        LevelNumber.gameObject.SetActive(true);

        SmoothFollow.Instance.InGamplayCam();
        SetPlayerCurrentParticle();
    }

    public void ParticlesSelection()
    {
        SoundsManager.Instance.ButtonClickPlay();
        if (PlayerPrefs.GetInt("music") == 1)
        {
            particlesSelectionSound.volume = 0;
        }
        else
        {
            particlesSelectionSound.volume = 1;
        }
        mainPanel.SetActive(false);
        inputManager.SetActive(false);
        ballIndex = SelectedBallIndex;//PlayerPrefs.GetInt("selectedball")
        particleIndex = SelectedParticleIndex;
        // unlockedBalls = PlayerPrefs.GetInt("unlockedballs");
        //  Debug.Log(ballIndex);
        playerBalls[ballIndex].SetActive(false);
        particlesSelection.gameObject.SetActive(true);
        blobShadow.SetActive(false);
        LevelNumber.gameObject.SetActive(false);
        //if (particleIndex < 0)
        //{
        //    particleIndex = balls.Length;
        //}

        //if (balls[particleIndex].particlesPrice == 0)
        //{
        //    buyButton.gameObject.SetActive(false);
        //    selectButton.gameObject.SetActive(true);
        //    //    buyImage.gameObject.SetActive(false);
        //}
        //else
        //if (PlayerPrefs.GetInt("unlockedparticles" + particleIndex) == 0)
        //{
        //    buyButton.gameObject.SetActive(true);
        //    if (PlayerPrefs.GetInt("coins") >= balls[particleIndex].particlesPrice)
        //    {
        //        buyButton.interactable = true;
        //    }
        //    else
        //    {
        //        buyButton.interactable = false;
        //    }
        //    selectButton.gameObject.SetActive(false);
        //    //    buyImage.gameObject.SetActive(true);
        //    //  buyPrice.text = balls[ballIndex].ballsPrice.ToString();
        //}
        //else
        //{
        //    buyButton.gameObject.SetActive(false);
        //    selectButton.gameObject.SetActive(true);
        //    //   buyImage.gameObject.SetActive(false);
        //}
        //for (int i = 0; i < particlesEffects.Length; i++)
        //{
        //    particlesEffects[i].SetActive(false);
        //}


        //for (int i = 0; i < ParticlePrice.Length; i++)
        //{
        //    if (PlayerPrefs.GetInt("unlockedparticles" + i) == 0)
        //        ParticlePrice[i].text = balls[i].particlesPrice.ToString();
        //    else
        //        ParticlePrice[i].text = "Free";
        //}
        Activity.Instance.TrackObj.SetActive(false);
        //if (particleIndex == 0)
        //{
        //    return;
        //    //  particlesEffects[particleIndex].SetActive(false);
        //}
        //else
        //{
        //    particlesEffects[particleIndex - 1].SetActive(true);
        //}



    }


    #endregion

    public void Select()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //PlayerPrefs.SetInt("selectedball", ballIndex);
        SelectedBallIndex = ballIndex;//PlayerPrefs.GetInt("selectedball")

        if (selectionIndex)
        {
            // Debug.Log("Select 1");

            blobShadow.SetActive(true);
            playerBalls[ballIndex].SetActive(true);
            mainPanel.SetActive(true);
            inputManager.SetActive(true);
            //ballSelectionBalls.gameObject.SetActive(false);
           // BallUserControl.Instance.UpdateBall();
            LevelNumber.gameObject.SetActive(true);
            playerBall.constraints = RigidbodyConstraints.None;
        }
        else
        {
            //  Debug.Log("Select 2");
            blobShadow.SetActive(true);
            playerBalls[ballIndex].SetActive(true);

            inputManager.SetActive(true);
            //ballSelectionBalls.gameObject.SetActive(false);
           // BallUserControl.Instance.UpdateBall();
            LevelNumber.gameObject.SetActive(true);
            playerBall.constraints = RigidbodyConstraints.None;
            ChanceButtonsGamePlay.SetActive(true);
            PauseButtonsGamePlay.SetActive(true);
            SkipButton.gameObject.SetActive(true);
            gameplayBallSelection.SetActive(true);
        }

        FB_Event_Ball();
    }

    public void Buy()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //if (PlayerPrefs.GetInt("coins") >= balls[ballIndex].ballsPrice)
        //{
        //    // PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - balls[ballIndex].ballsPrice);
        //    CoinsManager.Instance.MinusCoins(balls[ballIndex].ballsPrice);
        //    PlayerPrefs.SetInt("unlockedBalls" + ballIndex, 1);
        //    buyButton.gameObject.SetActive(false);
        //    selectButton.gameObject.SetActive(true);
        //}
        //else
        //{
        //    notEnoughCoins.SetActive(true);
        //}
        // PlayerPrefs.SetInt("selectedball", ballIndex)
    }
    public void SetLevelReward(int value)
    {
        if (LevelsData.Length > Current_Level)
            LevelsData[Current_Level].levelReward = value;

    }
    public int GetLevelReward()
    {
        if (LevelsData.Length > Current_Level)
            return LevelsData[Current_Level].levelReward;
        else
            return 100;
    }

    public void Get500Coins()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //  ButtonClick();a
        // Get500CoinsRV();


        load_rew();
        Reward_Active(1);
        Invoke(nameof(show_Get500), 6f);
    }
    void show_Get500()
    {
        Number_xXx = 1;
        show_rew();
        // Get500CoinsRV
    }
    private void Get500CoinsRV()
    {
        //?1? AdmobAdsManager_Infi.Instance.Btn_Reward_Done("You Have Done Reward Successfully");

        Reward_Active(0);
        CoinsManager.Instance.AddCoinsCounter(500);

    }
    void RewardNotShow_Get500CoinsRV()
    {

    }

    public void Back()
    {
        _reload();
    }

    //private void Update()
    //{
    //    if (m_TurnSmoothing > 0)
    //    {
    //        //  camTransform.position = Vector3.Slerp(camTransform.position, target_position, m_TurnSmoothing * Time.deltaTime);
    //        //  balls[ballIndex].ballTransform.Rotate(0f, 0.3f, 0f, Space.Self);
    //    }
    //    else
    //    {

    //    }
    //}
    public void SelectTrail()
    {
        SoundsManager.Instance.ButtonClickPlay();
        // PlayerPrefs.SetInt("selectedball", ballIndex);
        blobShadow.SetActive(true);
        mainPanel.SetActive(true);
        inputManager.SetActive(true);
        playerBalls[SelectedBallIndex].SetActive(true);//PlayerPrefs.GetInt("selectedball")
        LevelNumber.gameObject.SetActive(true);
        // ballSelectionBalls.gameObject.SetActive(false);
        //  playerBalls[ballIndex].SetActive(false);
        particlesSelection.gameObject.SetActive(false);
        Activity.Instance.TrackObj.SetActive(true);
        //  blobShadow.SetActive(false);
        //PlayerPrefs.SetInt("particles", particleIndex);
        //BallUserControl.Instance.UpdateParticles();
        SmoothFollow.Instance.InGamplayCam();

    }



    public void BackButtonSelection()
    {
        if (selectionIndex)
        {
            blobShadow.SetActive(true);
            //for (int i = 0; i < playerBalls.Length; i++)
            //{
            //    playerBalls[i].SetActive(false);
            //}
            //playerBalls[PlayerPrefs.GetInt("selectedball")].SetActive(true);
            particlesSelection.gameObject.SetActive(false);
            //ballSelectionBalls.gameObject.SetActive(false);
            mainPanel.SetActive(true);
            inputManager.SetActive(true);
            LevelNumber.gameObject.SetActive(true);
            LevelNumber.gameObject.SetActive(true);
            playerBall.constraints = RigidbodyConstraints.None;
        }
        else
        {
            blobShadow.SetActive(true);
            // playerBalls[PlayerPrefs.GetInt("selectedball")].SetActive(true);
            particlesSelection.gameObject.SetActive(false);
            //ballSelectionBalls.gameObject.SetActive(false);
            mainPanel.SetActive(true);
            inputManager.SetActive(true);
            //  LevelNumber.gameObject.SetActive(true);
            LevelNumber.gameObject.SetActive(true);
            playerBall.constraints = RigidbodyConstraints.None;
            //ChanceButtonsGamePlay.SetActive(true);
            PauseButtonsGamePlay.SetActive(true);
            SkipButton.gameObject.SetActive(true);
            gameplayBallSelection.SetActive(true);
        }
        SmoothFollow.Instance.InGamplayCam();

    }





    public void BallSelectionStart()
    {
        left.SetActive(false);
        right.SetActive(false);
        //  particlesCamTransform.gameObject.SetActive(false);
        //  camTransform.gameObject.SetActive(true);
    }

    public void GetITButton()
    {
        SoundsManager.Instance.ButtonClickPlay();
        //  ButtonClick();
        Invoke("GetITButtonDone", 2.0f);

    }
    public void GetITButtonDone()
    {


        getCoins.SetActive(false);
    }

    //  public void ButtonClick()
    // {
    //  SoundsManager.Instance.ButtonClickPlay();


    // }
    public void ChanceSetCallBack(bool a)
    {
        ballIcon.gameObject.SetActive(false);
        if (a)
        {
            plusOneCoin.SetActive(true);
        }

        for (int i = 0; i < 5; i++)
        {
            if (i < chance)
            {
                //chanceImages[i].transform.GetChild(0).gameObject.SetActive(true);
                chanceImages[i].enabled = false;
                rotatingBalls[i].gameObject.SetActive(true);
                int ballIndex = SelectedBallIndex;
                for (int j = 0; j < rotatingBalls[i].transform.childCount; j++)
                {
                    if (j == ballIndex)
                    {
                        rotatingBalls[i].transform.GetChild(j).gameObject.SetActive(true);
                    }
                    else
                    {
                        rotatingBalls[i].transform.GetChild(j).gameObject.SetActive(false);
                    }

                }
            }
            else
            {
                //chanceImages[i].transform.GetChild(0).gameObject.SetActive(false);
                rotatingBalls[i].gameObject.SetActive(false);
                chanceImages[i].enabled = true;
            }
        }
    }

    public void Haptics(bool a)
    {
        if (a)
        {
            PlayerPrefs.SetInt("haptics", 1);
        }
        else
        {
            PlayerPrefs.SetInt("haptics", 0);
        }
        SoundsManager.Instance.SetSoundsVolume();

    }

    public void SFX(bool s)
    {
        if (s)
        {
            PlayerPrefs.SetInt("sfx", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sfx", 0);
        }
        SoundsManager.Instance.SetSoundsVolume();
    }
    public void Music(bool s)
    {
        if (s)
        {
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
        }

        SoundsManager.Instance.SetSoundsVolume();
        Settingsss();

    }

    public void ButtonClick()
    {
        SoundsManager.Instance.ButtonClickPlay();
        // MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        //  if (PlayerPrefs.GetInt("sfx") == 0)
        //  {

        //  }

        //  if (PlayerPrefs.GetInt("haptics") == 0)
        //   {

        // }

    }
    public void SetStopBall()
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void SetMoveBall()
    {
        player.GetComponent<Rigidbody>().isKinematic = false;
    }
    public void SetMass()
    {
        // player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().mass = 100000;
    }
    public void PrivacyPolicy()
    {
        SoundsManager.Instance.ButtonClickPlay();
        Application.OpenURL("https://limestudio01.blogspot.com/2019/03/privacy-policy.html");
    }

    public void MoreGames()
    {
        SoundsManager.Instance.ButtonClickPlay();
        Application.OpenURL("https://play.google.com/store/apps/developer?id=lime+Studio");
    }

    public void Settings()
    {
        _mr_show();
        Settingsss();
    }
    void Settingsss()
    {
        LevelNumber.gameObject.SetActive(false);
        SoundsManager.Instance.PlayBGMusicStop();
        if (PlayerPrefs.GetInt("music") == 1)
        {
            settingsSound.volume = 0;
        }
        else
        {
            settingsSound.volume = 1;
        }
    }
    public void PurchaseDone()
    {
        //   Debug.Log("Purchase Done");
    }
    public void SettingsContinue()
    {
        _mr_hide();

        LevelNumber.gameObject.SetActive(true);
        SoundsManager.Instance.PlayBGMusic();
    }
    public void Spin()
    {
        SoundsManager.Instance.PlayBGMusicStop();
        SoundsManager.Instance.ButtonClickPlay();
        LevelNumber.gameObject.SetActive(false);
        // BGMusic OFF
    }
    public void SpinOff()
    {
        SoundsManager.Instance.ButtonClickPlay();
        LevelNumber.gameObject.SetActive(true);
        SoundsManager.Instance.PlayBGMusic();
    }
    void load_int()
    {
       // zWork.Instance.Btn_Load_Int();
    }
    void show_int()
    {
      //  zWork.Instance.Btn_Show_Int();
        Invoke(nameof(load_int), 1f);
    }

    int Number_xXx;
    void call_rew()
    {
        if (Number_xXx == 0)
        {
            Chk_Coins_skip();
        }
        if (Number_xXx == 1)
        {
            Get500CoinsRV();
        }
        if (Number_xXx == 2)
        {
            X2();
        }
        if (Number_xXx == 3)
        {
            RestartLevel();
        }
        if (Number_xXx == 4)
        {
            reward();
        }

    }

    void load_rew()
    {
       // zWork.Instance.Btn_Load_Rew();
    }
    void show_rew()
    {

       // zWork.Instance.Btn_Show_Rew(call_rew);
        Invoke(nameof(load_rew), 1f);
    }

    void _mr_load()
    {
        //if (!AdmobAdsManager.Instance.IsMediumBannerReady())
        //{
        //    AdmobAdsManager.Instance.LoadMediumBanner();
        //}
    }
    void _mr_show()
    {
        _mr_load();
       // if (Admob_other.Instance.Internet == true)
        {
            // AdmobAdsManager_Super.Instance.ShowMediumBanner();

            //if (!AdmobAdsManager.Instance.IsMediumBannerReady())
            //{
            //  //  AdmobAdsManager.Instance.LoadMediumBanner();
            //    Invoke(nameof(call_try), 1f);
            //}
            //else
            //{
            // //   AdmobAdsManager.Instance.ShowMediumBanner();
            //}
        }
    }

    void call_try()
    {
        _mr_show();
    }

    void _mr_hide()
    {
        CancelInvoke("call_try");
        CancelInvoke("call_try");
        CancelInvoke("call_try");
       // AdmobAdsManager.Instance.HideMediumBanner();
    }

    bool xXx_AO;
    public void Btn_AO_Check(bool xXx)
    {
        xXx_AO = xXx;
        //AdmobAdsManager_Super.Instance.Btn_Ao_After_Int(xXx_AO);

       // AdmobAdsManager.Instance.Click_Int_Rew = xXx_AO;
    }
}