using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float health;
    public float maxHealth;


    void Start()
    {
        health = maxHealth;
        GlobalEvents.Instance.NukeExploded += Die;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health < 0)
        {
            Die();
        }
    }
    public void Die()
    {
        PlayerHealthController.Instance.GainHealth(maxHealth / 10);
        GlobalEvents.Instance.EnemyKilled();
        Destroy(gameObject);
    }
}
