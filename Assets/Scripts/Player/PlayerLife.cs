using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Vector2 respawnPoint;

    [SerializeField] private Slider healthSlider;
    private int playerHealth = 3;
    private int damageAmt = 1;
    [SerializeField] private GameObject fallDetector;   
    public UnityEvent OnPlayerDeath;
    [SerializeField] private GameObject gameoverPanel; 

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        respawnPoint = transform.position;

        healthSlider.maxValue = playerHealth;
        healthSlider.value = playerHealth;
    }

    private void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Trap"))
        {
            playerHealth -= damageAmt;
            healthSlider.value = playerHealth;

            if (playerHealth <= 0)
            {
                OnPlayerDeath.Invoke();
                AudioManager.instance.Play("Respawn");
            }
            else
            {
                RespawnAtCheckpoint();
                AudioManager.instance.Play("Respawn");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
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
        yield return new WaitForSeconds(1.0f);
        gameoverPanel.SetActive(true);
        
        yield return new WaitForSeconds(3.0f);
        AudioManager.instance.Play("Respawn");
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
        yield return new WaitForSeconds(2.0f);

        AudioManager.instance.Play("Respawn");
        transform.position = respawnPoint;
        rb.bodyType = RigidbodyType2D.Dynamic;
        sprite.enabled = true;
    }
}