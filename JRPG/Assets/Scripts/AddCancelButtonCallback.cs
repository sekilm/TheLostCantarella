using UnityEngine;
using UnityEngine.UI;

public class AddCancelButtonCallback : MonoBehaviour
{
    private AudioSource buttonSound;
    void Start()
    {
        GameObject buttonSoundObject = GameObject.Find("ButtonSound");
        buttonSound = buttonSoundObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddCallback());
    }

    private void AddCallback()
    {
        buttonSound.Play();
        GameObject turnSystem = GameObject.Find("TurnSystem");
        turnSystem.GetComponent<TurnSystem>().CancelAction();
    }
}