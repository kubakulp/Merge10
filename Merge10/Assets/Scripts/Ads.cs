using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour
{
    public WinningLevel winningLevel;

    public void StandardAd()
    {
        AdController.ShowStandardAd();
    }

    public void RewardedAd()
    {
        AdController.ShowRewardedAd(Success,Failed,Skipped);
    }

    public void Success()
    {
        if (SceneManager.GetActiveScene().name != "Level30")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 62 - (SceneManager.GetActiveScene().buildIndex / 12));
            winningLevel.WinLevel();
        }
        else
        {
            SceneManager.LoadScene("LastLevel");
            winningLevel.WinLevel();
        }
    }

    public void Failed()
    {

    }

    public void Skipped()
    {

    }
}
