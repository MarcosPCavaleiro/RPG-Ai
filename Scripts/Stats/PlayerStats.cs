using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public AudioSource sound;
    public AudioClip hitClip;
    public AudioClip deathClip;
    public Scene currentScene;
    private string sceneName;
    bool soundPlay = false;

    public override void Die()
    {
        if (!sound.isPlaying && soundPlay == false)
        {
            soundPlay = true;
            sound.PlayOneShot(deathClip);
        }
        base.Die();
        PlayerManager.instance.KillPlayer();
    }

    public override void TakeDamage(int damage){
        base.TakeDamage(damage);
        sound.PlayOneShot(hitClip);
    }

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Phase1")
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = NextScene.oldHealth;
        }
    }
}
