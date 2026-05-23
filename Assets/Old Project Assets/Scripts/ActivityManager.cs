using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NA;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
using UnityStandardAssets.Utility;

public class ActivityManager : SimpleSingleton<ActivityManager>
{
    public bool IsTestMode;
    public int TestLevelNum;
    [SerializeField]
    private string m_Address;
    private GameObject m_LevelInstance;
    public GameObject[] Levels; 
    //private AsyncOperationHandle<GameObject> m_LevelLoadOpHandle;


    //[SerializeField]
    // private AssetReference m_HatAssetReference;
    //  private ResourceRequest m_HatLoadingRequest;
    // public GameObject[] levels;
    // public int Index;

    private void OnEnable()
    {
        if (IsTestMode)
        {
            PlayerPrefs.SetInt("CurrentLevel", TestLevelNum);
        }
        if (PlayerPrefs.GetInt("Skip") == 1)
        {
            int num = PlayerPrefs.GetInt("CurrentLevel") + 1;
            PlayerPrefs.SetInt("CurrentLevel", num);
            PlayerPrefs.SetInt("Skip", 0);
        }
        Invoke(nameof(LoadInLevel), 1);
    }
    private void Start()
    {
       // PlayerPrefs.SetInt("CurrentLevel", Index);
        //  Debug.Log("Current Level =" + PlayerPrefs.GetInt("CurrentLevel"));
        //if(PlayerPrefs.GetInt("CurrentLevel")>=levels.Length)
        //{
        //    PlayerPrefs.SetInt("CurrentLevel", 0);
        //}
        //for(int i = 0;i<levels.Length;i++)
        //{
        //    int j = i;
        //    if (PlayerPrefs.GetInt("CurrentLevel") == j)
        //    {
        //        //levels[j].SetActive(true);

        //    }
        //   // else levels[j].SetActive(false);
        //}
        
    }
    private void LoadInLevel()
    {
        int randomIndex = PlayerPrefs.GetInt("CurrentLevel",0);
        Debug.Log("Random Number " + randomIndex);
        //    Debug.Log("Random Number " + randomIndex%4);
        int totalLength = Levels.Length - 1;
        if (randomIndex> totalLength)
        {
            randomIndex = Random.Range(3, totalLength);
        }
       // m_LevelInstance= Instantiate(Levels[randomIndex]);
        m_LevelInstance = Levels[randomIndex];
        m_LevelInstance.SetActive(true);
        //if(randomIndex%4== 0 && randomIndex <= 10) 
        //{

        //    string hatAddress = "BonusLevel1";

        //    m_LevelLoadOpHandle = Addressables.LoadAssetAsync<GameObject>(hatAddress);
        //    m_LevelLoadOpHandle.Completed += OnHatLoadComplete;

        //}
        //else if (randomIndex % 4 == 0 && randomIndex <= 20)
        //{

        //    string hatAddress = "BonusLevel2";

        //    m_LevelLoadOpHandle = Addressables.LoadAssetAsync<GameObject>(hatAddress);
        //    m_LevelLoadOpHandle.Completed += OnHatLoadComplete;

        //}
        //else if (randomIndex % 4 == 0 && randomIndex <30)
        //{

        //    string hatAddress = "BonusLevel3";

        //    m_LevelLoadOpHandle = Addressables.LoadAssetAsync<GameObject>(hatAddress);
        //    m_LevelLoadOpHandle.Completed += OnHatLoadComplete;

        //}else if (randomIndex % 4 == 0 && randomIndex >30)
        //{

        //    string hatAddress = "BonusLevel4";

        //    m_LevelLoadOpHandle = Addressables.LoadAssetAsync<GameObject>(hatAddress);
        //    m_LevelLoadOpHandle.Completed += OnHatLoadComplete;

        //}
        //else
        //{
        //string hatAddress = string.Format("Level{0:00}", randomIndex);

        //Debug.Log("Hat Address = " + hatAddress);
        //m_LevelLoadOpHandle = Addressables.LoadAssetAsync<GameObject>(hatAddress);
        //m_LevelLoadOpHandle.Completed += OnHatLoadComplete;
        //}

    }
   
    
}
