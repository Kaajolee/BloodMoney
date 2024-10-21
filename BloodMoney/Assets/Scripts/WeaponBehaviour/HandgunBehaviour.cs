using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunBehaviour : MonoBehaviour, IWeaponBehaviour
{
    public void Shoot(Transform shootPoint, Weapon weaponData, AudioSource audioPlayer)
    {
        if(weaponData.bulletPrefab == null)
        {
            Debug.LogError("Handgun bullet prefab is null");
            return;
        }

        GameObject instantiatedBullet = Instantiate(weaponData.bulletPrefab, shootPoint.position, shootPoint.rotation);
        BulletMoveScript bulletScript = instantiatedBullet.GetComponent<BulletMoveScript>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(shootPoint.up);
            bulletScript.SetDamage(weaponData.weaponDamage);
        }
        audioPlayer.clip = weaponData.weaponAudio;
        audioPlayer.Play();
        Destroy(instantiatedBullet, 2);
    }
}
