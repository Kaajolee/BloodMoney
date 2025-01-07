using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    private Coroutine shootingCoroutine;

    public bool isMouseOverUI = false;
    void Start()
    {
       // SetWeaponBehaviour(gunData);

    }

    // Update is called once per frame
    void Update()
    {
        isMouseOverUI = DetectMouse();

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isMouseOverUI)
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

        else if (Input.GetKeyDown(KeyCode.G) && !isMouseOverUI)
        {
            UtilityUsage();
        }
        else if (Input.GetKeyDown(KeyCode.N) && !isMouseOverUI)
        {
            SpecialUsage();
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
                currentWeaponBehaviour.Shoot(shootPoint, gunData, WeaponSoundPlayer.Instance);
                yield return new WaitForSeconds(1f / gunData.weaponFirerate);
            }
        }
    }
    private void UtilityUsage()
    {
        if (grenadeData != null)
        {
            currentGrenadeBehaviour.Shoot(shootPoint, grenadeData, WeaponSoundPlayer.Instance);
        }
    }
    private void SpecialUsage()
    {
        if (specialData != null)
        {
            GameObject clone = Instantiate(specialData.bulletPrefab, shootPoint.position, Quaternion.identity);
        }
    }
    bool DetectMouse()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
