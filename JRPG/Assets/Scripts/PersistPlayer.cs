using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistPlayer : MonoBehaviour
{
    public static List<string> spawners;

    private bool playDialogue;
    public DialogueTrigger startingDialogue;
    public DialogueTrigger endingDialogue;

    private bool spawnEncounters;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        gameObject.SetActive(false);
        playDialogue = true;
        spawnEncounters = true;
        DialogueManager.endGame = false;
        spawners = new List<string>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(scene.name == "Forest");
            if (scene.name == "Forest")
            {
                if (playDialogue)
                {
                    startingDialogue.TriggerDialogue();
                    playDialogue = false;
                }
                
                DestroySpawners();
            }
        }
    }

    private void DestroySpawners()
    {
        foreach (string spawn in spawners)
        {
            if (spawn == "DragonSpawner")
            {
                DialogueManager.endGame = true;
                endingDialogue.TriggerDialogue();
            }
            Destroy(GameObject.Find(spawn));
        }
    }
}