using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] sentences = {"Default", "Text"};
    private int index;

    [SerializeField]private GameObject nextButton;
    [SerializeField]private Animator anim;
    [SerializeField]private float typingSpeed; 

    public DialogueData dialogueData;

    private void Start()
    {
        sentences = dialogueData.m_responses;
        StartCoroutine(TypeDialogue());
    }

    /*private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            nextButton.SetActive(true);
        }
    }*/
    IEnumerator TypeDialogue()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
        yield return new WaitForSeconds(0.5f);
        NextSentence();
    }
    public void NextSentence()
    {
        anim.SetTrigger("Change");
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = "";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}