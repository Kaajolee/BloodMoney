using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUsageLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Currently equipped weapon data objects")]
    [SerializeField]
    public Weapon gunData;
    [SerializeField]
    public Weapon grenadeData;
    [SerializeField]
    public Weapon specialData;


    [SerializeField]
    private IWeaponBehaviour currentWeaponBehaviour;

    [SerializeField]
    private IWeaponBehaviour currentGrenadeBehaviour;

    [SerializeField]
    private IWeaponBehaviour currentSpecialBehaviour;

    [Space]
    public Transform shootPoint;

    [Space]
    public AudioSource audioSource;

    private Coroutine shootingCoroutine;
    void Start()
    {
       // SetWeaponBehaviour(gunData);

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

        else if (Input.GetKeyDown(KeyCode.G))
        {
            UtilityUsage();
        }
    }
    public void SetWeaponBehaviour(Weapon weaponData)
    {
        switch (weaponData.weaponType)
        {
            case WeaponType.None:
                //currentWeaponBehaviour = ne
                break;

            case WeaponType.Handgun:
                currentWeaponBehaviour = new HandgunBehaviour();
                gunData = weaponData;
                break;

            case WeaponType.Automatic:
                gunData = weaponData;
                break;

            case WeaponType.Shotgun:
                currentWeaponBehaviour = new ShotgunBehaviour();
                gunData = weaponData;
                break;

            case WeaponType.Throwable:
                currentGrenadeBehaviour = new GrenadeBehaviour();
                grenadeData = weaponData;
                //Debug.Log("Grenade behaviour set");
                break;

            case WeaponType.Special:
                specialData = weaponData;
                break;

        }
    }
    private IEnumerator ShootCoroutine()
    {
        if (gunData != null)
        {
            while (true)
            {
                currentWeaponBehaviour.Shoot(shootPoint, gunData, audioSource);
                yield return new WaitForSeconds(1f / gunData.weaponFirerate);
            }
        }
    }
    private void UtilityUsage()
    {
        if (grenadeData != null)
        {
            currentGrenadeBehaviour.Shoot(shootPoint, grenadeData, audioSource);
        }
    }
}
