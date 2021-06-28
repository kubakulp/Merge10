using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour, IUnityAdsListener
{

    private static readonly string StoreId = "3707973";
    private static readonly string video_Ad = "video";
    private static readonly string rewardedVideo_AD = "rewardedVideo";

    private Action adSuccess;
    private Action adSkipped;
    private Action adFailed;

#if UNITY_EDITOR
    private static bool testMode = true;
#else
    private static bool testMode = false;
#endif

    public static AdController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(StoreId, testMode);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void ShowStandardAd()
    {
        if(Advertisement.IsReady(video_Ad))
        {
            Advertisement.Show(video_Ad);
        }
    }

    public static void ShowRewardedAd(Action success, Action skipped, Action failed)
    {
        instance.adSuccess = success;
        instance.adSkipped = skipped;
        instance.adFailed = failed;

        if (Advertisement.IsReady(rewardedVideo_AD))
        {
            Advertisement.Show(rewardedVideo_AD);
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == rewardedVideo_AD)
        {
            switch(showResult)
            {
                case ShowResult.Finished:
                    adSuccess();
                    break;
                case ShowResult.Skipped:
                    adSkipped();
                    break;
                case ShowResult.Failed:
                    adFailed();
                    break;
            }
        }
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

}
