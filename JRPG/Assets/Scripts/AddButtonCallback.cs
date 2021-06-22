using UnityEngine;
using UnityEngine.UI;

public class AddButtonCallback : MonoBehaviour
{
    public bool isAttack;
    
    private AudioSource buttonSound;

    public DialogueTrigger dialogueTrigger;
    void Start()
    {
        GameObject buttonSoundObject = GameObject.Find("ButtonSound");
        buttonSound = buttonSoundObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddCallback());
    }

    private void AddCallback()
    {
        buttonSound.Play();
        GameObject playerParty = GameObject.Find("PlayerParty");
        SelectUnit selectUnit = playerParty.GetComponent<SelectUnit>();
        UnitStats unitStats = selectUnit.currentUnit.GetComponent<UnitStats>();
        
        if (!isAttack)
        {
            if (unitStats.mana >= unitStats.specialCost)
            {
                selectUnit.SelectAttack(isAttack);
            }
            else
            {
                dialogueTrigger.TriggerDialogue();
            }
        }
        else
        {
            selectUnit.SelectAttack(isAttack);
        }
    }
}
