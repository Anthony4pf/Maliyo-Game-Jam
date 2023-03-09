using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int collectable;
    public GameObject pauseMenuScreen;

    [SerializeField] private Text collectablesText;

    private void Awake()
    {
        collectable = PlayerPrefs.GetInt("NumberOfCollectable", 0);
    }

    private void Update()
    {
        collectablesText.text = "" + collectable;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
