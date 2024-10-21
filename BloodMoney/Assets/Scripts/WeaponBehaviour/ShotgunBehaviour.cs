using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : MonoBehaviour, IWeaponBehaviour
{
    void IWeaponBehaviour.Shoot(Transform shootPoint, Weapon weaponData, AudioSource audioSource)
    {
        Quaternion newRotation = shootPoint.rotation;
        Debug.Log("Bullets: " + weaponData.bulletsPerShot);

        for (int i = 0; i < weaponData.bulletsPerShot; i++)
        {
            float spread = (i - (weaponData.bulletsPerShot / 2) * weaponData.spreadAngle);
            
            newRotation = Quaternion.Euler(shootPoint.eulerAngles.x, shootPoint.eulerAngles.y, shootPoint.eulerAngles.z + spread);
            GameObject instantiatedBullet = Instantiate(weaponData.bulletPrefab, shootPoint.position, newRotation);
            BulletMoveScript bulletScript = instantiatedBullet.GetComponent<BulletMoveScript>();

            if (bulletScript != null)
            {
                bulletScript.SetDirection(shootPoint.up);
                bulletScript.SetDamage(weaponData.weaponDamage);
            }
            Destroy(instantiatedBullet, 2);
        }

    }
}
