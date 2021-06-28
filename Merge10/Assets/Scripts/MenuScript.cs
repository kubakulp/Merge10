using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void TryAgain()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 43)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 32);
        if (SceneManager.GetActiveScene().buildIndex > 43 && SceneManager.GetActiveScene().buildIndex <= 53)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 31);
        if (SceneManager.GetActiveScene().buildIndex > 53 && SceneManager.GetActiveScene().buildIndex <= 63)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 30);
        if (SceneManager.GetActiveScene().buildIndex == 95)
            SceneManager.LoadScene("newGame");
    }
    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex <= 72)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 61);
        if (SceneManager.GetActiveScene().buildIndex > 72 && SceneManager.GetActiveScene().buildIndex <= 82)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 60);
        if (SceneManager.GetActiveScene().buildIndex > 82 && SceneManager.GetActiveScene().buildIndex <= 92)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 59);
        if (SceneManager.GetActiveScene().buildIndex == 93)
            SceneManager.LoadScene("LastLevel");
    }
}
