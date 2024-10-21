using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Create new weapon data")]
public class Weapon : ScriptableObject
{
    public string weaponName;

    public int weaponDamage;
    public int weaponPrice;
    public int bulletsPerShot;

    public float weaponFirerate;
    public float spreadAngle;
    public float explosionRadius;

    public bool isPurchased;
    public bool isEquiped;

    public GameObject bulletPrefab;

    public WeaponType weaponType;
    public WeaponClass weaponClass;

    public Sprite weaponSprite;
    public List<Sprite> explosionSprites;
}
public enum WeaponType
{
    None,
    Handgun,
    Shotgun,
    Automatic,
    Throwable,
    Special
}
public enum WeaponClass
{
    None,
    Gun,
    Throwable,
    Special
}
