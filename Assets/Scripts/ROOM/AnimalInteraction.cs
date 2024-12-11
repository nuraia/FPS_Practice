using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalInteraction : MonoBehaviour
{
    public bool isCatinRange = false;

    void OnTriggerEnter(Collider col)
    {
        isCatinRange = true;
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
    void OnTriggerExit(Collider col)
    {
        isCatinRange = false;
    }
}
