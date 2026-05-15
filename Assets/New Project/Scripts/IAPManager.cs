//using UnityEngine;
//using UnityEngine.Purchasing;

//namespace Rollance
//{
//    public class IAPManager : MonoBehaviour, IStoreListener
//    {
//        public static IAPManager Instance;

//        //private static IStoreController storeController;
//        //private static IExtensionProvider extensionProvider;

//        //public string removeAdsID = "remove_ads";

//        //private void Awake()
//        //{
//        //    if (Instance == null)
//        //    {
//        //        Instance = this;
//        //        DontDestroyOnLoad(gameObject);
//        //    }
//        //    else
//        //    {
//        //        Destroy(gameObject);
//        //    }
//        //}

//        //void Start()
//        //{
//        //    InitializePurchasing();
//        //}

//        //// 🔹 INIT
//        //public void InitializePurchasing()
//        //{
//        //    if (storeController != null) return;

//        //    var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

//        //    builder.AddProduct(removeAdsID, ProductType.NonConsumable);

//        //    UnityPurchasing.Initialize(this, builder);
//        //}

//        //// 🔹 BUY BUTTON
//        //public void BuyRemoveAds()
//        //{
//        //    if (storeController == null) return;

//        //    Product product = storeController.products.WithID(removeAdsID);

//        //    if (product != null && product.availableToPurchase)
//        //    {
//        //        storeController.InitiatePurchase(product);
//        //    }
//        //    else
//        //    {
//        //        Debug.Log("Product not available");
//        //    }
//        //}

//        //// 🔹 SUCCESS
//        //public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
//        //{
//        //    if (args.purchasedProduct.definition.id == removeAdsID)
//        //    {
//        //        Debug.Log("Remove Ads Purchased!");

//        //        PlayerPrefs.SetInt("RemoveAds", 1);
//        //        PlayerPrefs.Save();

//        //        // 👉 Disable Ads here
//        //        AdsManager.Instance.DisableAds();
//        //    }

//        //    return PurchaseProcessingResult.Complete;
//        //}

//        //// 🔹 FAIL
//        //public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
//        //{
//        //    Debug.Log("Purchase Failed: " + reason);
//        //}

//        //public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//        //{
//        //    storeController = controller;
//        //    extensionProvider = extensions;
//        //}

//        //public void OnInitializeFailed(InitializationFailureReason error)
//        //{
//        //    Debug.Log("IAP Init Failed: " + error);
//        //}



//    }
//}