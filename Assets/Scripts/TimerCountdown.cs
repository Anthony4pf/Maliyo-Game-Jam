using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private bool timeIsRunning = false;
    [SerializeField] private float timeRemaining = 60.0f;
    public UnityEvent OnTimerOver;

    private void Start()
    {
        timeIsRunning = true;
    }

    private void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timeIsRunning = false;
                OnTimerOver.Invoke();
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60.0f);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60.0f);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void RestartGame()
    {
        StartCoroutine(RestartCorountine());
    }

    IEnumerator RestartCorountine()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}