using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossUi : Ui
{
    public Image slider;
    public EnemyStats boss;
    public GameObject bossBar;

    public override void Update()
    {
        base.Update();
        float healthPercent = (float)boss.currentHealth / boss.maxHealth;
        slider.fillAmount = healthPercent;
        if (boss.currentHealth <= 0)
        {
            Destroy(bossBar);
        }
    }
}
