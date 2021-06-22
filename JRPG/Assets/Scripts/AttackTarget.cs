using System.Collections;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public GameObject owner;
    public bool isSpecial;

    public void Hit(GameObject target)
    {
        UnitStats ownerStats = owner.GetComponent<UnitStats>();
        UnitStats targetStats = target.GetComponent<UnitStats>();
        
        int damage;

        if (isSpecial && ownerStats.mana >= ownerStats.specialCost)
        {
            damage = ownerStats.magic - targetStats.magicDefense;
            ownerStats.mana -= ownerStats.specialCost;
        }
        else
        {
            damage = ownerStats.attack - targetStats.defense;
        }

        StartCoroutine(DealDamage(targetStats, damage));
        StartCoroutine(PlayAttackSound());
    }

    private IEnumerator DealDamage(UnitStats targetStats, int damage)
    {
        Animator anim = owner.GetComponent<Animator>();
        if (isSpecial)
        {
            anim.Play("Special");
        }
        else
        {
            anim.Play("Attack");
        }

        float time = 0;
        foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "Attack" || clip.name == "Special")
            {
                time = clip.length;
            }
        }
            
        yield return new WaitForSeconds(time);

        targetStats.ReceiveDamage(damage);
        targetStats.hitSound.Play();
    }
    
    private IEnumerator PlayAttackSound()
    {
        Animator anim = owner.GetComponent<Animator>();
        float time = 0;
        foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "Attack" || clip.name == "Special")
            {
                time = clip.length;
            }
        }
        yield return new WaitForSeconds(time - 0.5f);
    }
}