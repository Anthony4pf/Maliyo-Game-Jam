using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContinueGame : MonoBehaviour
{
    private int sceneToContinue;

    public void OnGameContinue()
    {
        sceneToContinue = PlayerPrefs.GetInt("");

        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
        }
        else
        {
            return;
        }
    }
}

