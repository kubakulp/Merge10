using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] ButtonsA;
    public Button[] ButtonsB;
    public Button[] ButtonsC;
    // Start is called before the first frame update
    void Start()
    {
        int indexA = PlayerPrefs.GetInt("indexAaaa", 2);
        int indexB = PlayerPrefs.GetInt("indexBbbb", 13);
        int indexC = PlayerPrefs.GetInt("indexCccc", 24);

        for (int i = 0; i < ButtonsA.Length; i++)
        {
            if (i + 2 > indexA)
            {
                ButtonsA[i].interactable = false;
            }
        }

        for (int i = 0; i < ButtonsB.Length; i++)
        {
            if (i + 13 > indexB)
            {
                ButtonsB[i].interactable = false;
            }
        }

        for (int i = 0; i < ButtonsC.Length; i++)
        {
            if (i + 24 > indexC)
            {
                ButtonsC[i].interactable = false;
            }
        }
    }
}
