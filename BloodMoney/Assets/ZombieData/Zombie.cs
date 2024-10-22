using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie type", menuName = "Zombie/Create new zombie data")]
public class Zombie : ScriptableObject
{
    
    public float movementSpeed;
    public float angularSpeed;
    public float acceleration;
    public float attackSpeed;
    public float attackDamage;
    public float maxHealth;

    public Sprite zombieSprite;
}
public enum ZombieType
{
    RegularZombie,
    FastZombie,
    TankZombie
}
