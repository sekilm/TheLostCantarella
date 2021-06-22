using UnityEngine;
using UnityEngine.UI;

public class ShowPotions : MonoBehaviour
{
    public bool isHp;
    
    private GameObject potions;
    private PersistPotions potionsScript;
    
    void Start()
    {
        potions = GameObject.Find("Potions");
        potionsScript = potions.GetComponent<PersistPotions>();
    }

    void Update()
    {
        if (isHp)
        {
            gameObject.GetComponent<Text>().text = "HP Pots: " + potionsScript.GetHealthPotions();
        }
        else
        {
            gameObject.GetComponent<Text>().text = "MP Pots: " + potionsScript.GetManaPotions();
        }
    }
}
