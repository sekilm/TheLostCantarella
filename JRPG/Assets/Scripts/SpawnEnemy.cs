using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Sprite bgImage;
    
    private bool spawning;
    public GameObject slime, bat, snake, dragon;
    private List<GameObject> enemies;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
        
        enemies = new List<GameObject>();
        enemies.Add(slime);
        enemies.Add(bat);
        enemies.Add(snake);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Battle")
        {
            if(spawning)
            {
                RandomizeEncounter();
                Destroy(gameObject);
                
                GameObject.Find("BgImage").GetComponent<Image>().sprite = bgImage;

                foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("Spawner"))
                {
                    spawn.SetActive(false);
                }
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        if (scene.name == "MainMenu")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }

        if (scene.name == "Forest")
        {
            foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("Spawner"))
            {
                spawn.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PersistPlayer.spawners.Add(gameObject.name);
            spawning = true;
            SceneManager.LoadScene("Battle");
        }
    }
    
    private void RandomizeEncounter()
    {
        int enemiesNumber = Random.Range(3, 6);

        if (gameObject.name == "DragonSpawner")
        {
            GameObject boss = Instantiate(dragon, dragon.transform);
            Vector3 position = dragon.transform.position;

            boss.transform.position = new Vector2(position.x + 5f, position.y);
        }

        else
        {
            for (int enemyCounter = 0; enemyCounter < enemiesNumber; enemyCounter++)
            {
                int enemyToSpawn = Random.Range(0, enemies.Count);

                GameObject prefab = enemies[enemyToSpawn];
                GameObject enemy = Instantiate(prefab, prefab.transform);

                EnemyPositions positions = null;
                if (enemiesNumber == 3)
                {
                    positions = new ThreeEnemiesTemplate();
                }

                if (enemiesNumber == 4)
                {
                    positions = new FourEnemiesTemplate();
                }

                if (enemiesNumber == 5)
                {
                    positions = new FiveEnemiesTemplate();
                }

                if (positions != null)
                {
                    enemy.transform.position =
                        new Vector2(positions.GetX()[enemyCounter], positions.GetY()[enemyCounter]);
                }
            }
        }
    }
}
