using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponBehaviour
{
    void Shoot(Transform shootPoint, Weapon weaponData, WeaponSoundPlayer weaponSoundPlayer);
}
