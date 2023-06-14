using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChest : Interactable
{
    public GameObject dialog;
    public PlayerStats stats;

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(delay());

    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        dialog.SetActive(true);
        stats.currentHealth = 200;
        Time.timeScale = 0;
    }   
}
