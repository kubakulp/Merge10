using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreToWin : MonoBehaviour
{

    Text ToWin;
    public static int scoreWinValue = 0;
    
    void Start()
    {
        ToWin = GetComponent<Text>();
    }

    void Update()
    {
        ToWin.text = "To win : " + scoreWinValue;
    }
}
