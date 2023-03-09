using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCollectible : MonoBehaviour
{
    [SerializeField] private Text collectibleText;
    [SerializeField] private CollectibleData collectibleData;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectibleData.countCollected++;
            collectibleText.text = collectibleData.countCollected.ToString();

            Destroy(gameObject);
        }
    }
}
