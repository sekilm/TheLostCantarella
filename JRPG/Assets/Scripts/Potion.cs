using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool isHpPotion;
    public DialogueTrigger notice;
    public int amount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PersistPlayer.spawners.Add(gameObject.name);
        
            GameObject potions = GameObject.Find("Potions");
            PersistPotions potionsScript = potions.GetComponent<PersistPotions>();
            
            notice.TriggerDialogue();
            if (isHpPotion)
            {
                potionsScript.AddHealthPotions(amount);
            }
            else
            {
                potionsScript.AddManaPotions(amount);
            }

            gameObject.SetActive(false);
        }
    }
}
