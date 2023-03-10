using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCompletion : MonoBehaviour
{
    [SerializeField] private CollectibleData[] collectibles;
    [SerializeField] private GameObject feedbackText;
    [SerializeField] private GameObject levelCompletePanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        bool allCollected = true;

        for (int i = 0; i < collectibles.Length; i++)
        {
            if (collectibles[i].countCollected < collectibles[i].countRequired)
            {
                allCollected = false;
                break;
            }
        }

        if (allCollected)
        {
            levelCompletePanel.SetActive(true);
            StartCoroutine(LevelCompletedCoroutine());
        }
        else
        {
            feedbackText.SetActive(true);
            StartCoroutine(RemoveFeedback());
        }
    }

    IEnumerator LevelCompletedCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator RemoveFeedback()
    {
        yield return new WaitForSeconds(1f);
        feedbackText.SetActive(false);
    }
}