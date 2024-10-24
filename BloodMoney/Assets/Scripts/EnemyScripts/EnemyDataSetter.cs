using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDataSetter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Zombie zombieData;

    private SpriteRenderer spriteRenderer;

    private EnemyHealthController healthController;

    private NavMeshAgent agent;

    [SerializeField]
    private EnemyAIDamage attackController;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthController = GetComponent<EnemyHealthController>();
        agent = GetComponent<NavMeshAgent>();

        SetZombieData();
    }
    public void SetZombieData()
    {
        spriteRenderer.sprite = zombieData.zombieSprite;
        healthController.maxHealth = zombieData.maxHealth;
        agent.speed = zombieData.movementSpeed;
        agent.angularSpeed = zombieData.angularSpeed;
        agent.acceleration = zombieData.acceleration;
        attackController.zombieDamage = (int)zombieData.attackDamage;
    }

}
