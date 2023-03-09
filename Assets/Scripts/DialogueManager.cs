using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI m_dialogue;
    private string[] m_sentences = {"Default", "Text"};
    private int index;

    public GameObject nextButton;
    public GameObject endButton;

    private void Start()
    {
        
    }

}