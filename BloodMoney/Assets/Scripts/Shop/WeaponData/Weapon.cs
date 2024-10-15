using System.Collections;
using System.Collections.Generic;
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

    public bool isPurchased;
    public bool isEquiped;

    public GameObject bulletPrefab;

    public WeaponType weaponType;

    public enum WeaponType
    {
        None,
        Handgun,
        Shotgun,
        Automatic,
        Throwable,
        Special
    }

}
