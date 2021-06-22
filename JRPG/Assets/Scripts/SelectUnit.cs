using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectUnit : MonoBehaviour
{
    public GameObject currentUnit;
    private GameObject actionsMenu, enemyUnitsMenu, cancelMenu;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle")
        {
            actionsMenu = GameObject.Find("ActionsMenu");
            enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
            cancelMenu = GameObject.Find("CancelMenu");
        }
    }

    public void SelectCurrentUnit(GameObject unit)
    {
        currentUnit = unit;
        actionsMenu.SetActive(true);
        cancelMenu.SetActive(false);
        enemyUnitsMenu.SetActive(false);

        currentUnit.GetComponent<PlayerUnitAction>().UpdateHUD();
    }

    public void SelectAttack(bool isAttack)
    {
        currentUnit.GetComponent<PlayerUnitAction>().SelectAttack(isAttack);
        
        actionsMenu.SetActive(false);
        enemyUnitsMenu.SetActive(true);
        cancelMenu.SetActive(true);
    }

    public void AttackEnemyTarget(GameObject target)
    {
        actionsMenu.SetActive(false);
        enemyUnitsMenu.SetActive(false);
        cancelMenu.SetActive(false);
        
        currentUnit.GetComponent<PlayerUnitAction>().Act(target);
    }

    public void UseHealthPotion()
    {
        UnitStats stats = currentUnit.GetComponent<UnitStats>(); 
        stats.health += 40;
        if (stats.health > stats.maxHealth)
        {
            stats.health = stats.maxHealth;
        }
    }
    
    public void UseManaPotion()
    {
        UnitStats stats = currentUnit.GetComponent<UnitStats>(); 
        stats.mana += 30;
        if (stats.mana > stats.maxMana)
        {
            stats.mana = stats.maxMana;
        }
    }
}
