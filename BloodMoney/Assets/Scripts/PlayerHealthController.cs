using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private static PlayerHealthController _instance;
    public static PlayerHealthController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("PlayerHealthController is null");
            }
            return _instance;
        }
    }

    public float health;
    public float maxHealth;

    private GlobalEvents globalEvents;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {

        health = maxHealth;

        globalEvents = GlobalEvents.Instance;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0)
        {
            Die();
        }
        globalEvents.HealthChanged();
    }
    public void Die()
    {
        Debug.Log("Player has died");
    }
    public void GainHealth(float amount)
    {
        health += amount;
        globalEvents.HealthChanged();
    }
}
