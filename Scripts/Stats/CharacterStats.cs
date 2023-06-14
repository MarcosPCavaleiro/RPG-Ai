using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDeath;

    public Stat damage;

    public event System.Action<int,int> OnHealthChanged;

    public void Update() {
        if (currentHealth <= 0)
        {
            Die();
        }
        
    }


    public virtual void TakeDamage(int damage)
    {
        
        damage = Mathf.Clamp(damage , 0 , int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " tomou " + damage + " de dano.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth,currentHealth);
        }

    }

    public virtual void Die()
    {
        isDeath = true;
    }
}