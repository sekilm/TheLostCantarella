using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour, IComparable
{
    public int maxHealth;
    public int maxMana;
    public int attack;
    public int magic;
    public int defense;
    public int magicDefense;
    public int initiative;
    public int specialCost;
    
    public int health;
    public int mana;

    public int nextTurn;

    public Animator animator;
    public GameObject damageTextPrefab;
    public AudioSource hitSound;

    private bool dead;

    private void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }

    public void ComputeNextTurn(int currentTurn)
    {
        nextTurn = currentTurn + (int) Math.Ceiling(100.0f / initiative);
    }

    public int CompareTo(object otherStats)
    {
        return nextTurn.CompareTo(((UnitStats) otherStats).nextTurn);
    }

    public bool IsDead()
    {
        return dead;
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;

        StartCoroutine(Destroy());

        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, HUDCanvas.transform);

        damageText.GetComponent<Text>().text = "" + damage;
		damageText.GetComponent<Text>().color = Color.black;
        damageText.transform.position = new Vector2(gameObject.transform.position.x + 5.0f, gameObject.transform.position.y + 0.5f);
        damageText.transform.localScale = new Vector2(5.0f, 5.0f);
    }

    private IEnumerator Destroy()
    {
        animator.Play("TakeHit");
        hitSound.Play();

        if (health <= 0)
        {
            dead = true;
            gameObject.tag = "DeadUnit";

            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }
    }
}
