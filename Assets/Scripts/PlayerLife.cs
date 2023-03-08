using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Transform playerRespawnPoint;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private int playerHealth = 3;
    private int damageAmt = 1;    
    public UnityEvent OnPlayerDeath; 

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerHealthText.text = playerHealth.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Trap"))
        {
            playerHealth -= damageAmt;
            playerHealthText.text = playerHealth.ToString();
            if (playerHealth <= 0)
            {
                OnPlayerDeath.Invoke();
            }
            else
            {
                RespawnAtCheckpoint();
            }
        }
    }
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RespawnAtCheckpoint()
    {
        rb.bodyType = RigidbodyType2D.Static;
        sprite.enabled = false;

        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        rb.bodyType = RigidbodyType2D.Dynamic;
        sprite.enabled = true;
    }
}