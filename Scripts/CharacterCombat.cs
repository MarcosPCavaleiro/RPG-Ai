using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    const float combatCooldown = 5;
    float lastAttackTime;

    public float attackDelay = .6f;

    public bool inCombat { get; private set; }
    public event System.Action OnAttack;

    CharacterStats myStats;


    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
        }

        if (myStats.currentHealth <= 0)
        {
            inCombat = false;
        }
    }

    public void Attack(CharacterStats targetStats)
    {

        if (targetStats.currentHealth > 0)
        {
            if (attackCooldown <= 0f)
            {
                StartCoroutine(DoDamage(targetStats, attackDelay));

                if (OnAttack != null)
                    OnAttack();

                attackCooldown = 1f / attackSpeed;
                inCombat = true;
                lastAttackTime = Time.time;
            }
        }
        else {
            inCombat = false;
        }
    }

    public void SuperAttack(CharacterStats targetStats)
    {

        if (targetStats.currentHealth > 0)
        {
            if (attackCooldown <= 0f)
            {
                StartCoroutine(DoSuperDamage(targetStats, attackDelay));

                if (OnAttack != null)
                    OnAttack();

                attackCooldown = 1f / attackSpeed;
                inCombat = true;
                lastAttackTime = Time.time;
            }
        }
        else {
            inCombat = false;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }

    IEnumerator DoSuperDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue() + 10);
    }


}
