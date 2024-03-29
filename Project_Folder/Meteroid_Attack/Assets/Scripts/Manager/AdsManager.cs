using UnityEngine;
using GoogleMobileAds.Api;
using System;
using Random = UnityEngine.Random;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;
    string AppID = "ca-app-pub-6536263809755106~2766678922";

    string interstitialAdd = "ca-app-pub-8824047777559558/8900912242";
    string rewarded_Add = "ca-app-pub-8824047777559558/1545166401";

    InterstitialAd interstitial;
    RewardedAd rewardedAd;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.rewardedAd = new RewardedAd(rewarded_Add);
        RequestRewardAd();
       
        //event handler
       
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

    }
    #region Callbacks
    public void RequestRewardAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    public void RequestInterstitial()
    { 
        if (this.interstitial != null)
            this.interstitial.Destroy();

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitialAdd);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.

        this.interstitial.LoadAd(request);


    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.ToString());
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        UIManager.instance.ShowNoAdsPanel();
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                            );
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        GameManager.instance.RewardPlayer();
    }
    #endregion



    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else
        {
            UIManager.instance.ShowNoAdsPanel();
        }
    }

    public void onGameStartLoadInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
          if(Random.Range(0,4)==0)
                this.interstitial.Show();
                
        }
    }
}
