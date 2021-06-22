using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyUnitAction : MonoBehaviour
{
    public GameObject attack, special;
    
    private GameObject currentAttack;

    private UnitStats stats;

    private void Awake()
    {
        attack = Instantiate(attack);
        special = Instantiate(special);
        
        attack.GetComponent<AttackTarget>().owner = gameObject;
        special.GetComponent<AttackTarget>().owner = gameObject;

        currentAttack = attack;

        stats = gameObject.GetComponent<UnitStats>();
    }
    
    public void Act()
    {
        GameObject target = FindBestTarget();
        currentAttack.GetComponent<AttackTarget>().Hit(target);
    }
    
    GameObject FindBestTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("PlayerUnit");
        int targetsLength = possibleTargets.Length;
        int[] evaluations = new int[targetsLength];
        GameObject[] attacks = new GameObject[targetsLength];

        if (possibleTargets.Length > 0)
        {
            foreach (GameObject player in possibleTargets)
            {
                int targetIndex = Array.IndexOf(possibleTargets, player);

                UnitStats targetStats = player.GetComponent<UnitStats>();

                int attackEvaluation = stats.attack - targetStats.defense;
                int specialEvaluation = stats.magic - targetStats.magicDefense;

                if (attackEvaluation > specialEvaluation)
                {
                    evaluations[targetIndex] = attackEvaluation;
                    attacks[targetIndex] = attack;
                }
                else
                {
                    evaluations[targetIndex] = specialEvaluation;
                    attacks[targetIndex] = special;
                }

                if (targetStats.health <= evaluations[targetIndex])
                {
                    evaluations[targetIndex] += 100;
                }
            }
            int maxEval = evaluations.Max();
            ArrayList targetIndexes = new ArrayList();

            for (int i = 0; i < evaluations.Length; i++)
            {
                if (evaluations[i] == maxEval)
                {
                    targetIndexes.Add(i);
                }
            }

            int finalTargetIndex = Random.Range(0, targetIndexes.Count);

            currentAttack = attacks[finalTargetIndex];

            GameObject finalTarget = possibleTargets[finalTargetIndex];
            return finalTarget;
        }

        return null;
    }
}
