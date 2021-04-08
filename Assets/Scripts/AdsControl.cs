using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SocialPlatforms;

using System;
using UnityEngine.Advertisements;

public class AdsControl : MonoBehaviour
{

    public static AdsControl instance;
    string UnityAdsID_IOS = "3454862";
    string UnityAdsID_Android = "3454863";
    public GameObject internetConnectionPanel;
    public GameObject adsNotready;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (!Advertisement.isInitialized)
        {
#if UNITY_IOS
			Advertisement.Initialize (UnityAdsID_IOS); // initialize Unity Ads.
#endif

#if UNITY_ANDROID
            Advertisement.Initialize(UnityAdsID_Android); // initialize Unity Ads.
#endif
        }

    }
    public void ShowVideoOrInterstitialAD()
    {
        //print(Advertisement.IsReady());
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdsResult });
        }
        else
        {
            adsNotready.SetActive(true);
            print("Advertisement.IsReady inside ShowVideoOrInsAd : " + Advertisement.IsReady());
        }

    }


    void HandleAdsResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }

    public void PlayRewardedVideo()
    {

        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdsResult });
        }
        else
        {
            adsNotready.SetActive(true);
            print("Advertisement.IsReady inside PlayRewardedVideo : " + Advertisement.IsReady());
        }

    }
    public void PlayRewardedVideoFor100_Coins()
    {

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            internetConnectionPanel.SetActive(true);
            // GameCtrl.instance.ui.reviveAdsResultTxt.text = "No Internet Access";

        }
        else
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = Handle100_CoinAdsResult });
            }
            else
            {
                adsNotready.SetActive(true);
                print("Advertisement.IsReady inside PlayRewardedVideoFor100_Coins : " + Advertisement.IsReady());
            }

        }

    }

    public void PlayRewardedVideoForFillFuel()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            internetConnectionPanel.SetActive(true);
            // GameCtrl.instance.ui.reviveAdsResultTxt.text = "No Internet Access";

        }
        else
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleFillFuelAdsResult });
            }
            else
            {
                adsNotready.SetActive(true);
                print("Advertisement.IsReady inside PlayRewardedVideoForFillFuel : " + Advertisement.IsReady());

            }
        }
    }

    void Handle100_CoinAdsResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                HomeManager._homeManager.AddCoin(100);
                break;

            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
    void HandleFillFuelAdsResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameManager.instance.FillFuelAfterAds(100);
                break;

            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
    public void CloseInternetConnectionPanel()
    {
        internetConnectionPanel.SetActive(false);
    }
    public void CloseAdsNotReadyPanel()
    {
        adsNotready.SetActive(false);
    }
}

//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Advertisements;

//[RequireComponent(typeof(Button))]
//public class AdsControl : MonoBehaviour, IUnityAdsListener
//{

//#if UNITY_IOS
//    private string gameId = "3454862";
//#elif UNITY_ANDROID
//    private string gameId = "3454863";
//#endif

//    Button myButton;
//    public GameObject internetConnectionPanel;

//    public string myPlacementId = "rewardedVideo";
//    public enum ButtonType
//    {
//        ads,
//        fuel
//    }
//    public ButtonType buttonType;
//    public static AdsControl instance;
//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//    }
//    void Start()
//    {
//        myButton = GetComponent<Button>();
//        print(Advertisement.IsReady(myPlacementId));
//        // Set interactivity to be dependent on the Placement’s status:
//        myButton.interactable = Advertisement.IsReady(myPlacementId);

//        // Map the ShowRewardedVideo function to the button’s click listener:
//        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

//        // Initialize the Ads listener and service:
//        Advertisement.AddListener(this);
//        Advertisement.Initialize(gameId, false);
//    }

//    // Implement a function for showing a rewarded video ad:
//    public void ShowRewardedVideo()
//    {
//        if (Application.internetReachability == NetworkReachability.NotReachable)
//        {
//            internetConnectionPanel.SetActive(true);
//        }
//        else
//        {
//            Advertisement.Show(myPlacementId);
//        }

//    }

//    // Implement IUnityAdsListener interface methods:
//    public void OnUnityAdsReady(string placementId)
//    {
//        // If the ready Placement is rewarded, activate the button: 
//        if (placementId == myPlacementId)
//        {
//            myButton.interactable = true;
//        }
//    }

//    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
//    {
//        // Define conditional logic for each ad completion status:
//        if (showResult == ShowResult.Finished)
//        {
//            if (buttonType == ButtonType.ads)
//            {
//                HomeManager._homeManager.AddCoin(100);
//            }
//            else if (buttonType == ButtonType.fuel)
//            {
//                GameManager.instance.FillFuelAfterAds(100);
//            }

//            // Reward the user for watching the ad to completion.
//        }
//        else if (showResult == ShowResult.Skipped)
//        {
//            // Do not reward the user for skipping the ad.
//        }
//        else if (showResult == ShowResult.Failed)
//        {
//            Debug.LogWarning("The ad did not finish due to an error.");
//        }
//    }

//    public void OnUnityAdsDidError(string message)
//    {
//        // Log the error.
//        Debug.LogWarning("The ad did not finish due to an error." + message);
//    }

//    public void OnUnityAdsDidStart(string placementId)
//    {
//        // Optional actions to take when the end-users triggers an ad.
//    }
//    public void CloseInternetConnectionPanel()
//    {
//        internetConnectionPanel.SetActive(false);
//    }
//}