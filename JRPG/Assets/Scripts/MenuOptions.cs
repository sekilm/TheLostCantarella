using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject menuBgCanvas;
    public GameObject optionsCanvas;
    public GameObject optionsBgCanvas;

    private AudioSource buttonSound;

    private void Start()
    {
        GameObject buttonSoundObject = GameObject.Find("ButtonSound");
        buttonSound = buttonSoundObject.GetComponent<AudioSource>();
    }

    public void BeginGame()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Forest");
    }
    
    public void Exit()
    {
        buttonSound.Play();
        Application.Quit();
    }

    public void Options()
    {
        buttonSound.Play();
        optionsCanvas.SetActive(true);
        optionsBgCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        menuBgCanvas.SetActive(false);
    }
    
    public void Back()
    {
        buttonSound.Play();
        optionsCanvas.SetActive(false);
        optionsBgCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        menuBgCanvas.SetActive(true);
    }
}
