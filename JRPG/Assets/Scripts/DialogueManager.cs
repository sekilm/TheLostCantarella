using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences = new Queue<string>();

    public GameObject text;
    public Text dialogueText;

    public static bool isActive;

    private GameObject player;

    public static bool endGame;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        text.SetActive(true);
        isActive = true;

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
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void EndDialogue()
    {
        if (endGame)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        sentences.Clear();
        isActive = false;
        text.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Forest")
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
