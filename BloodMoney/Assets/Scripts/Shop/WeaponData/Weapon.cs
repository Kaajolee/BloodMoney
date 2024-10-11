using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Create new weapon data")]
public class Weapon : ScriptableObject
{
    public string GunName;
    public int GunDamage;
    public int GunPrice;
    public int GunFirerate;

}
