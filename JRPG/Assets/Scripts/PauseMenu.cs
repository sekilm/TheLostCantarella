using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;

    public GameObject pauseMenu;
    
    private AudioSource buttonSound;

    private void Start()
    {
        GameObject buttonSoundObject = GameObject.Find("ButtonSound");
        buttonSound = buttonSoundObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    
    public void Resume()
    {
        buttonSound.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Quit()
    {
        buttonSound.Play();
        Time.timeScale = 1;
        isPaused = false;
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
