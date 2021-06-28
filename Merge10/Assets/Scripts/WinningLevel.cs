using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningLevel : MonoBehaviour
{
    public int nextLevelIndex;

    void Start()
    {
        nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void WinLevel()
    {
        if (nextLevelIndex > PlayerPrefs.GetInt("indexAaaa") && nextLevelIndex < 12)
        {
            PlayerPrefs.SetInt("indexAaaa", nextLevelIndex);
        }

        if (nextLevelIndex > PlayerPrefs.GetInt("indexBbbb") && nextLevelIndex >= 13 && nextLevelIndex < 23)
        {
            PlayerPrefs.SetInt("indexBbbb", nextLevelIndex);
        }

        if (nextLevelIndex > PlayerPrefs.GetInt("indexCccc") && nextLevelIndex >= 24)
        {
            PlayerPrefs.SetInt("indexCccc", nextLevelIndex);
        }
    }
}
