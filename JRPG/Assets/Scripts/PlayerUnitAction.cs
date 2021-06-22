using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitAction : MonoBehaviour
{
    public GameObject attack, special;
    public Sprite face;

    private GameObject currentAttack;
    private void Awake()
    {
        attack = Instantiate(attack, transform);
        special = Instantiate(special, transform);

        attack.GetComponent<AttackTarget>().owner = gameObject;
        special.GetComponent<AttackTarget>().owner = gameObject;

        currentAttack = attack;
    }

    public void Act(GameObject target)
    {
        currentAttack.GetComponent<AttackTarget>().Hit(target);
    }

    public void SelectAttack(bool isAttack)
    {
        if (isAttack)
        {
            currentAttack = attack;
        }
        else
        {
            currentAttack = special;
        }
    }

    public void UpdateHUD()
    {
        GameObject playerUnitFace = GameObject.Find("PlayerUnitFace");
        GameObject playerUnitHealth = GameObject.Find("PlayerUnitHealth");
        GameObject playerUnitMana = GameObject.Find("PlayerUnitMana");

        playerUnitFace.GetComponent<Image>().sprite = face;
        playerUnitHealth.GetComponent<ShowUnitHealth>().ChangeUnit(gameObject);
        playerUnitMana.GetComponent<ShowUnitMana>().ChangeUnit(gameObject);
    }
}
