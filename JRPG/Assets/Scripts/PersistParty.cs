using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistParty : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        gameObject.SetActive(false);
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
            gameObject.SetActive(scene.name == "Battle");
        }
    }
}
