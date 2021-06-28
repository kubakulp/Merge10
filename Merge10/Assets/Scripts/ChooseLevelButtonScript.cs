using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelButtonScript : MonoBehaviour
{
    public void ChooseLevelButton()
    {
        SceneManager.LoadScene("chooseLevel");
    }
}

