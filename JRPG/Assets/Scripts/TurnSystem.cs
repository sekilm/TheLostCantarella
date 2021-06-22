using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnSystem : MonoBehaviour
{
    private List<UnitStats> unitsStats;
    private UnitStats currentUnitStatsBackup;

    public GameObject playerParty;
    public GameObject actionsMenu, enemyUnitsMenu, cancelMenu;
    
    void Start()
    {
        playerParty = GameObject.Find("PlayerParty");

        unitsStats = new List<UnitStats>();
        
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (GameObject unit in playerUnits)
        {
            UnitStats currentUnitStats = unit.GetComponent<UnitStats>();
            currentUnitStats.ComputeNextTurn(0);
            unitsStats.Add(currentUnitStats);
        }
        
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject unit in enemyUnits)
        {
            UnitStats currentUnitStats = unit.GetComponent<UnitStats>();
            currentUnitStats.ComputeNextTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        unitsStats.Sort();
        
        actionsMenu.SetActive(false);
        enemyUnitsMenu.SetActive(false);
        cancelMenu.SetActive(false);

        NextTurn();
    }

    public void CancelAction()
    {
        GameObject currentUnit = currentUnitStatsBackup.gameObject; 
        
        playerParty.GetComponent<SelectUnit>().SelectCurrentUnit(currentUnit.gameObject);
    }

    public void NextTurn()
    {
        GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");

        if (remainingEnemyUnits.Length == 0)
        {
            SceneManager.LoadScene("Forest");
        }

        GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        
        if (remainingPlayerUnits.Length == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        UnitStats currentUnitStats = unitsStats[0];
        currentUnitStatsBackup = unitsStats[0];
        unitsStats.Remove(currentUnitStats);

        if (!currentUnitStats.IsDead())
        {
            GameObject currentUnit = currentUnitStats.gameObject;

            currentUnitStats.ComputeNextTurn(currentUnitStats.nextTurn);
            unitsStats.Add(currentUnitStats);
            unitsStats.Sort();

            if (currentUnit.CompareTag("PlayerUnit"))
            {
                playerParty.GetComponent<SelectUnit>().SelectCurrentUnit(currentUnit.gameObject);
            }
            else
            {
                currentUnit.GetComponent<EnemyUnitAction>().Act();
            }
        }
        else
        {
            NextTurn();
        }
    }
}
