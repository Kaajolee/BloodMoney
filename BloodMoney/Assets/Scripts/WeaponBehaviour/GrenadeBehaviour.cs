using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour, IWeaponBehaviour
{
    public void Shoot(Transform instantiationPoint, Weapon weaponData, AudioSource audioSource)
    {
        if (weaponData.bulletPrefab == null)
        {
            Debug.LogError("Grenade prefab is null");
            return;
        }

        GameObject instantiatedObject = Instantiate(weaponData.bulletPrefab, instantiationPoint.position, instantiationPoint.rotation);

        

        GrenadeMoveScript grenadeScript = instantiatedObject.GetComponent<GrenadeMoveScript>();

        grenadeScript.sprites = weaponData.explosionSprites;

        if (grenadeScript != null)
        {
            Vector2 throwDirection = ((Vector2)Input.mousePosition - (Vector2)instantiationPoint.position).normalized;

            grenadeScript.SetDirection(throwDirection);
            grenadeScript.SetDamage(weaponData.weaponDamage);
            grenadeScript.SetRadius(weaponData.explosionRadius);

        }
        //Destroy(instantiatedObject, 2);
    }

}
