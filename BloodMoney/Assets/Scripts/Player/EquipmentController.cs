using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentController : MonoBehaviour
{
    [Header("Currently equipped gun")]
    [SerializeField]
    private Weapon currentGun;

    [Space]
    [Header("Currently equipped throwable")]
    [SerializeField]
    private Weapon currentThrowable;

    [Space]
    [Header("Currently equipped special")]
    [SerializeField]
    private Weapon currentSpecial;

    [Space]
    [Header("Current weapon logic")]
    [SerializeField]
    private WeaponUsageLogic weaponLogicType;

    [Space]
    [Header("Hotbar sprites")]
    [SerializeField]
    private Image gunSprite;
    [SerializeField]
    private Image throwableSprite;
    [SerializeField]
    private Image specialSprite;

    private void Start()
    {
        weaponLogicType = GetComponent<WeaponUsageLogic>();
        SetInitialState();
    }
    public void EquipItem(Weapon item)
    {
        switch (item.weaponClass)
        {
            case WeaponClass.None:
                break;
            case WeaponClass.Gun:
                EquipGun(item);
                break;
            case WeaponClass.Throwable:
                EquipThrowable(item);
                break;
            case WeaponClass.Special:
                EquipSpecial(item);
                break;
        }
        ChangeHotbarSprite(item);

        Debug.Log("Item equipped, name: " + item.weaponName);
    }
    private void EquipGun(Weapon gun)
    {
        currentGun = gun;
        weaponLogicType.SetWeaponBehaviour(gun);
    }
    private void EquipThrowable(Weapon throwable)
    {
        currentThrowable = throwable;
        weaponLogicType.SetWeaponBehaviour(throwable);
    }
    private void EquipSpecial(Weapon special)
    {
        currentSpecial = special;
        weaponLogicType.SetWeaponBehaviour(special);
    }
    private void ChangeHotbarSprite(Weapon item)
    {
        switch (item.weaponClass)
        {
            case WeaponClass.Gun:
                gunSprite.sprite = item.weaponSprite;
                break;
            case WeaponClass.Throwable:
                throwableSprite.sprite = item.weaponSprite;
                break;
            case WeaponClass.Special:
                specialSprite.sprite = item.weaponSprite;
                break;
        }
    }

    private void SetInitialState()
    {

        gunSprite.sprite = null;
        specialSprite.sprite = null;
        throwableSprite.sprite = null;
    }
}
