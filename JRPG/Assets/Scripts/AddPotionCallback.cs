using UnityEngine;
using UnityEngine.UI;

public class AddPotionCallback : MonoBehaviour
{
    public bool isHealthPotion;
    
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
        GameObject potions = GameObject.Find("Potions");
        GameObject playerParty = GameObject.Find("PlayerParty");
        PersistPotions potionsScript = potions.GetComponent<PersistPotions>();

        SelectUnit selectScript = playerParty.GetComponent<SelectUnit>();
        UnitStats stats = selectScript.currentUnit.GetComponent<UnitStats>();

        if (isHealthPotion)
        {
            if (stats.health < stats.maxHealth)
            {
                if (potionsScript.UseHealthPotion())
                {
                    selectScript.UseHealthPotion();
                }
            }
        }
        else
        {
            if (stats.mana < stats.maxMana)
            {
                if (potionsScript.UseManaPotion())
                {
                    selectScript.UseManaPotion();
                }
            }
        }
    }
}
