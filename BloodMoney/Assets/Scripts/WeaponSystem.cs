using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon weaponData;

    [SerializeField]
    private IWeaponBehaviour currentWeaponBehaviour;

    public Transform shootPoint;

    private Coroutine shootingCoroutine;
    void Start()
    {
        SetWeaponBehaviour(weaponData);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(ShootCoroutine());
            }    
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }

        }
    }
    public void SetWeaponBehaviour(Weapon weaponData)
    {
        switch (weaponData.weaponType)
        {
            case Weapon.WeaponType.None:
                //currentWeaponBehaviour = ne
                break;
            case Weapon.WeaponType.Handgun:
                currentWeaponBehaviour = new HandgunBehaviour();
                break;
            case Weapon.WeaponType.Automatic:

                break;
            case Weapon.WeaponType.Shotgun:
                currentWeaponBehaviour = new ShotgunBehaviour();
                break;
            case Weapon.WeaponType.Special:

                break;

        }
    }
    private IEnumerator ShootCoroutine()
    {
        if (weaponData != null)
        {
            while (true)
            {
                currentWeaponBehaviour.Shoot(shootPoint, weaponData);
                yield return new WaitForSeconds(1f / weaponData.weaponFirerate);
            }
        }
    }
}
