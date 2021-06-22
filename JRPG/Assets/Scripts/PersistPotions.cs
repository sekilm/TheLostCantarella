using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistPotions : MonoBehaviour
{
    private int healthPotions, manaPotions;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        healthPotions = 5;
        manaPotions = 5;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
    }
    
    public bool UseHealthPotion()
    {
        if (healthPotions != 0)
        {
            healthPotions -= 1;
            return true;
        }
        return false;
    }
    
    public bool UseManaPotion()
    {
        if (manaPotions != 0)
        {
            manaPotions -= 1;
            return true;
        }
        
        return false;
    }

    public void AddHealthPotions(int amount)
    {
        healthPotions += amount;
    }
    
    public void AddManaPotions(int amount)
    {
        manaPotions += amount;
    }

    public int GetHealthPotions()
    {
        return healthPotions;
    }
    
    public int GetManaPotions()
    {
        return manaPotions;
    }
}
