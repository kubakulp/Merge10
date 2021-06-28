using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    Text text;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 32 - (SceneManager.GetActiveScene().buildIndex / 12));
        }
        text.text = "Time left: " + Mathf.Round(timeLeft);
    }
}
