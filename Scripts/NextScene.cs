using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : Interactable
{
    public string sceneName;
    public AudioSource sound;
    public AudioClip openSound;
    public float timeToGo;
    public static int oldHealth;
    public PlayerStats stats;

    public override void Interact()
    {
        base.Interact();
        sound.PlayOneShot(openSound);
        StartCoroutine(delay());
        oldHealth = stats.currentHealth;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(timeToGo);
        SceneManager.LoadScene(sceneName);
    }

    
}
