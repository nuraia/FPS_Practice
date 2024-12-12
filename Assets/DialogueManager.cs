using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Animator animator;
    public RectTransform dialogueBox;
    private Queue<string> sentences = new Queue<string>();
    public static DialogueManager Instance;
    void Awake()
    {
        Instance = this;
        dialogueBox.DOAnchorPos(new Vector2(-100, -800), 0.0001f);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        dialogueBox.DOAnchorPos(new Vector2(-100, -200), 0.25f);
        Debug.Log($"Hey + {dialogue.name}");
        nameText.text =  dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        dialogueBox.DOAnchorPos(new Vector2(-100, -800), 0.25f);
        //animator.SetBool("IsOpen", false);
    }
    
}
