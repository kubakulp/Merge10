using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelScript : MonoBehaviour
{
    public int levelNumber; 

    public void ChooseLevel ()
    {
        SceneManager.LoadScene("Level" + levelNumber);
    }
}
