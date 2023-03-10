using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCollectible : MonoBehaviour
{
    [SerializeField] private Text collectibleText;
    [SerializeField] private CollectibleData collectibleData;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetCollectibleCount;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetCollectibleCount;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectibleData.countCollected++;
            collectibleText.text = collectibleData.countCollected.ToString();

            AudioManager.instance.Play("Collectables");
            Destroy(gameObject);
        }
    }

    private void ResetCollectibleCount(Scene scene, LoadSceneMode mode)
    {
        collectibleData.countCollected = 0;
    } 
}
