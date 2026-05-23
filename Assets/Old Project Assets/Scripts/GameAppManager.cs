//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using MoreMountains.NiceVibrations;

//using UnityEngine.Purchasing;
//using NA;
//[Serializable]
//public class InAppItem
//{
//    public string iapItem_Name;
//    public ProductType producttype;

//}

//public class GameAppManager : Singleton<GameAppManager>, IStoreListener
//{
//    public static GameAppManager instance_;
//    public static GameAppManager instance
//    {
//        get
//        {
//            if (!instance_)
//                instance_ = GameObject.FindObjectOfType<GameAppManager>();

//            return instance_;
//        }
//    }
//    public InAppItem[] iapitems = null;
//    public static event EventHandler consumable_events;
//    private static IStoreController m_StoreController;          // The Unity Purchasing system.
//    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
//    public static bool check_Unlockall = false;
//    public static string remove_AdsString = "removeadss";
//    public static string UnlockAll = "unlockall";
//    public static string UnlockCars = "unlockcars";
//    private static string kProductNameAppleSubscription = "com.unity3d.subscription.new";
//    private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";
//    void Awake()
//    {
//        //		instance = this;
//        DontDestroyOnLoad(instance);
//    }
//    public GameObject shopPanel;
//    public GameObject unlockAllPanel;
//    void Start()
//    {

//        if (m_StoreController == null)
//        {
//            Invoke("InitializePurchasing", 3f);
//            print("dasda");
//            InitializePurchasing();
//        }
//    }

//    public void RemoveAdsInapp()
//    {
//        Buy_Product(0);
//    }
//    public void Buy575Diamonds()
//    {
//        Buy_Product(1);
//    }
//    public void Buy1200Diamonds()
//    {
//        Buy_Product(2);
//    }
//    public void Buy3125Diamonds()
//    {
//        Buy_Product(3);
//    }
//    public void Buy10000Diamonds()
//    {
//        Buy_Product(4);
//    }
//    public void Buy10000Gold()
//    {
//        Buy_Product(5);
//    }
//    public void Buy240000Gold()
//    {
//        Buy_Product(6);
//    }
//    public void Buy650000Gold()
//    {
//        Buy_Product(7);
//    }
//    public void Buy1500000Gold()
//    {
//        Buy_Product(8);
//    }
//    public void UnlockAllModes()
//    {
//        Buy_Product(9);
//    }
//    public void UnlockAllLevels()
//    {
//        Buy_Product(10);
//    }
//    public void UnlockEverything()
//    {
//        Buy_Product(11);
//    }
//    public void UnlockAllCars()
//    {
//        Buy_Product(12);
//    }

//    public void InitializePurchasing()
//    {
//        if (IsInitialized())
//        {

//            ... we are done here.
//            return;
//        }


//        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

//        builder.AddProduct(remove_AdsString, ProductType.NonConsumable);
//        builder.AddProduct(UnlockAll, ProductType.NonConsumable);
//        for (int i = 0; i < GameAppManager.Instance.iapitems.Length; i++)
//        {
//            builder.AddProduct(GameAppManager.Instance.iapitems[i].iapItem_Name, GameAppManager.Instance.iapitems[i].producttype);
//        }
//        builder.Configure<IGooglePlayConfiguration>().SetDeferredPurchaseListener(OnDeferredPurchase);
//        UnityPurchasing.Initialize(this, builder);
//    }
//    void OnDeferredPurchase(Product product)
//    {
//        Debug.Log($"Purchase of {product.definition.id} is deferred");
//        btnGold.enabled = false;

//    }
//    public void OnPurchaseDeferred(Product product)
//    {

//        Debug.Log("Deferred product " + product.definition.id.ToString());
//    }
//    public bool IsInitialized()
//    {
//        print("Pass");
//        return m_StoreController != null && m_StoreExtensionProvider != null;
//    }


//    public void Buy_noAds()
//    {
//        print("Buy_noAds");
//        if (IsInitialized())
//        {
//            print("IsInitialized*****************");

//            if (!CheckProductID_Status(remove_AdsString))
//            {
//                BuyProductID(remove_AdsString);
//            }
//        }
//    }
//    public void Buy_unlockall()
//    {
//        if (IsInitialized())
//        {
//            if (!CheckProductID_Status(UnlockAll))
//            {
//                BuyProductID(UnlockAll);
//            }
//        }

//    }



//    public void Buy_Product(int iapID)
//    {
//        if (IsInitialized())
//        {
//            if (GameAppManager.Instance.iapitems[iapID].producttype == ProductType.NonConsumable)
//            {
//                if (!CheckProductID_Status(GameAppManager.Instance.iapitems[iapID].iapItem_Name))
//                {
//                    BuyProductID(GameAppManager.Instance.iapitems[iapID].iapItem_Name);
//                }
//            }
//            else
//            {
//                BuyProductID(GameAppManager.Instance.iapitems[iapID].iapItem_Name);
//            }
//        }
//    }

//    public bool CheckProductID_Status(string productId)
//    {
//        Product product = m_StoreController.products.WithID(productId);
//        if (product != null && product.hasReceipt)
//        {

//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    void BuyProductID(string productId)
//    {
//        if (IsInitialized())
//        {
//            Product product = m_StoreController.products.WithID(productId);
//            if (product != null && product.availableToPurchase)
//            {
//                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
//                m_StoreController.InitiatePurchase(product);
//            }
//            else
//            {
//                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
//            }
//        }

//        else
//        {
//            Debug.Log("BuyProductID FAIL. Not initialized.");
//        }
//    }



//    public void RestorePurchases()
//    {

//        if (!IsInitialized())
//        {
//            Debug.Log("RestorePurchases FAIL. Not initialized.");
//            return;
//        }


//        if (Application.platform == RuntimePlatform.IPhonePlayer ||
//            Application.platform == RuntimePlatform.OSXPlayer)
//        {

//            Debug.Log("RestorePurchases started ...");


//            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

//            apple.RestoreTransactions((result) =>
//            {

//                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
//            });
//        }

//        else
//        {

//            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
//        }
//    }



//     --- IStoreListener


//    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//    {
//        m_StoreController = controller;

//        m_StoreExtensionProvider = extensions;
//        if (IsInitialized())
//        {
//            if (CheckProductID_Status(remove_AdsString))
//            {
//                Tenlogiclocal.Ads_purchase = true;
//                Debug.Log("ads are purchase");
//            }

//            if (CheckProductID_Status(UnlockAll))
//            {
//                check_Unlockall = true;
//                Debug.Log("ads are purchase");
//            }
//        }
//    }


//    public void OnInitializeFailed(InitializationFailureReason error)
//    {

//        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
//    }


//    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
//    {

//        if (String.Equals(args.purchasedProduct.definition.id, remove_AdsString, StringComparison.Ordinal))
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            AdIDs.Ads_Purchase = true;

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[0].iapItem_Name, StringComparison.Ordinal)) // R Ads
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("ls18_removeads", 1);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[1].iapItem_Name, StringComparison.Ordinal)) // 1000
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("diamonds", PlayerPrefs.GetInt("diamonds") + 575);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[2].iapItem_Name, StringComparison.Ordinal)) // 5000
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("diamonds", PlayerPrefs.GetInt("diamonds") + 1200);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[3].iapItem_Name, StringComparison.Ordinal)) // 10000
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("diamonds", PlayerPrefs.GetInt("diamonds") + 3125);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[4].iapItem_Name, StringComparison.Ordinal)) // 50000
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("diamonds", PlayerPrefs.GetInt("diamonds") + 10000);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[5].iapItem_Name, StringComparison.Ordinal)) // Level
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 10000);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[6].iapItem_Name, StringComparison.Ordinal)) // Level
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 240000);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[7].iapItem_Name, StringComparison.Ordinal)) // Level
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 650000);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[8].iapItem_Name, StringComparison.Ordinal)) // Level
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 1500000);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[9].iapItem_Name, StringComparison.Ordinal)) // Level
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("modes", 4);
//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[10].iapItem_Name, StringComparison.Ordinal)) // Level
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("unlockedLevels", CoinsManager.Instance.levelsRewards.Length);
//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[11].iapItem_Name, StringComparison.Ordinal)) // Jumbo
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 1500000);
//            PlayerPrefs.SetInt("Shop", 1);

//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, GameAppManager.Instance.iapitems[12].iapItem_Name, StringComparison.Ordinal)) // Jumbo
//        {
//            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//            PlayerPrefs.SetInt("unlocked", 3);
//            PlayerPrefs.SetInt("Shop", 1);

//        }
//        else
//        {
//            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
//        }


//        return PurchaseProcessingResult.Complete;
//    }


//    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
//    {

//        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
//    }

//    public void give_CosumeEvent()
//    {
//        if (consumable_events != null)
//            consumable_events(null, null);
//    }

//    public void removeall_ConsumeEvent()
//    {
//        consumable_events = null;
//    }

//    public void ShowUnlockEverything()
//    {
//        unlockAllPanel.SetActive(true);
//    }
//    public void ShowShop()
//    {
//        shopPanel.SetActive(true);
//        CoinsManager.Instance.GoldDiamondActivation();
//    }

//    public void VideoAdRewardDiamonds()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }
//        AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//        Invoke("waitAD_now1", 0.2f);

//    }


//    void waitAD_now1()
//    {
//       //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(AddDimond);
//        if (PlayerPrefs.GetInt("LoadReward") == 0)
//        {
//            AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//            Invoke("waitAD_Later1", 6f);
//        }
//    }
//    void waitAD_Later1()
//    {
//       //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(AddDimond);

//    }

//    void AddDiamonds(object sender, System.EventArgs e)
//    {
//        AddDimond();
//    }
//    void AddDimond()
//    {
//        PlayerPrefs.SetInt("diamonds", PlayerPrefs.GetInt("diamonds") + 100);
//        MainAdsManagerController.instance.removeall_rewardevent();
//    }
//    public void VideoAdRewardGold()
//    {
//        if (SoundsManager.Instance)
//        {
//            SoundsManager.Instance.ButtonClickPlay();
//        }
//        if (PlayerPrefs.GetInt("haptics") == 0)
//        {
//            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
//        }
//        AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//        Invoke("waitAD_now", 0.2f);

//    }


//    void waitAD_now()
//    {
//       //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetGold);
//        if (PlayerPrefs.GetInt("LoadReward") == 0)
//        {
//            AdmobAdsManager_InfiSingle.Instance.LoadRewardedVideo();
//            Invoke("waitAD_Later", 6f);
//        }
//        else
//        {
//            Reward.SetActive(false);
//        }
//    }
//    void waitAD_Later()
//    {
//        //dnt AdmobAdsManager_InfiSingle.Instance.ShowRewardedVideo(GetGold);
//        if (PlayerPrefs.GetInt("LoadReward") == 0)
//        {
//            Reward.SetActive(false);
//        }
//        else
//        {

//            Reward.SetActive(false);
//        }
//    }

//    void IncreaseGold(object sender, System.EventArgs e)
//    {
//        GetGold();
//    }
//    void GetGold()
//    {
//        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 3000);
//        MainAdsManagerController.instance.removeall_rewardevent();
//    }

//    public void MainMenuOpen()
//    {
//        MainMenu.Instance.MM.SetActive(true);
//        SoundsManager.Instance.ButtonClickPlay();
//    }


//}

