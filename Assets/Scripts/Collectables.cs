using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameManager.collectable++;
            PlayerPrefs.SetInt("NumbersOfCollectibles", GameManager.collectable);
            Destroy(gameObject);

            AudioManager.instance.Play("Collectables");
        }
    }
}
