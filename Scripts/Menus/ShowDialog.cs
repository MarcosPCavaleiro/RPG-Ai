using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : Interactable
{
    public GameObject dialog;

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(delay());

    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        dialog.SetActive(true);
        Time.timeScale = 0;
    }   
}
