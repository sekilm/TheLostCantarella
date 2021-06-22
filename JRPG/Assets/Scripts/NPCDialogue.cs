using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public DialogueTrigger dialogue;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue.TriggerDialogue();
        }
    }
}
