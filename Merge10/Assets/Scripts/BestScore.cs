using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BestScore : MonoBehaviour
{
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("High Score", 0).ToString();
    }

    public void ifHighScore()
    {
        if(ScoreScript.scoreValue > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", ScoreScript.scoreValue);
            highScore.text = "High Score: " + ScoreScript.scoreValue.ToString();
        }
    }
}
