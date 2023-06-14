using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : EnemyStats
{
public GameObject Ellysia;
public GameObject Gate;
NextScene End;

    public override void Start(){
        base.Start();
        End = Gate.GetComponent<NextScene>();
    }


    public override void Die()
    {
        base.Die();
        Ellysia.SetActive(true);
        End.enabled = true;

    }   
}
