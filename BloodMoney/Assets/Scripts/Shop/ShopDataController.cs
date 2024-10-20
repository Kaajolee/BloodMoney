using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDataController : MonoBehaviour
{

    DataVault dataVault;

    [Header("Player's currently quipped item controller")]
    [SerializeField]
    private EquipmentController equipmentController;

    private void Start()
    {
        dataVault = DataVault.Instance;
    }
    public void SellItem(Weapon weapon)
    {
        if (weapon.isPurchased)
        {
            weapon.isPurchased = false;
            weapon.isEquiped = false;

            PlayerHealthController.Instance.GainHealth(weapon.weaponPrice * 0.75f);
        }
    }
    public void BuyItem(Weapon weapon)
    {

        if (!weapon.isPurchased)
        {
            weapon.isPurchased = true;
            weapon.isEquiped = false;

            PlayerHealthController.Instance.TakeDamage(weapon.weaponPrice);
        }
    }
    public void EquipItem(Weapon weapon)
    {
        dataVault.SetAllUnequiped(weapon);
        weapon.isEquiped = !weapon.isEquiped;

        equipmentController.EquipItem(weapon);
    }


}
