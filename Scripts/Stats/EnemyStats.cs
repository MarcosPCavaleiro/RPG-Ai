using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : CharacterStats
{
    public AudioSource sound;
    public AudioClip hitClip;
    public AudioClip deathClip;
    bool soundPlay = false;

    public virtual void Start() {
        sound = GetComponent<AudioSource>();
    }

    public override void Die()
    {
        if (!sound.isPlaying && soundPlay == false)
        {
            soundPlay = true;
            sound.PlayOneShot(deathClip);
        }
        base.Die();
        Destroy(gameObject, 5f);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        sound.PlayOneShot(hitClip);
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }
}
