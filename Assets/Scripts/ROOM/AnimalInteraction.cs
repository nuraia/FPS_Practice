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
        DialogueManager.Instance.EndDialogue();
        //DialogueManager.Instance.animator.SetBool("IsOpen", false);
    }
}
