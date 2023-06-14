using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    CharacterCombat combat;
    CharacterStats stats;

    const float locomationAnimationSmoothTime = .1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
        stats = GetComponent<CharacterStats>();
        combat.OnAttack += onAttack;
    }


    void Update()
    {

        float speedPercent = agent.velocity.magnitude / agent.speed;

        if (speedPercent > 0)
        {
            animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("speedPercent", 0);
        }
        
        animator.SetBool("inCombat", combat.inCombat);

        animator.SetBool("isDeath", stats.isDeath);
    }

    public virtual void onAttack()
    {
        animator.SetTrigger("attack");
    }

}
