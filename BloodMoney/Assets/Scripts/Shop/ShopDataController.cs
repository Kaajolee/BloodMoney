using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDataController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private TextMeshProUGUI GunName, GunDamage, GunPrice, GunFirerate;

    [SerializeField]
    private Button buyButton, sellButton, equipButton;

    [SerializeField]
    private TextMeshProUGUI buyButtonText, sellButtonText, equipButtonText;

    [SerializeField]
    private Weapon currentWeapon;

    [SerializeField]
    private WeaponSystem weaponSystem;

    private void Start()
    {

    }
    public void ChangeData(Weapon weaponData)
    {
        currentWeapon = weaponData;

        GunName.text = weaponData.weaponName;
        GunDamage.text = "Damage: " + weaponData.weaponDamage.ToString();
        GunPrice.text = "Price: " + weaponData.weaponPrice.ToString();
        GunFirerate.text = "Firerate: " + weaponData.weaponFirerate.ToString();

        ToggleButtons(weaponData);

    }
    public void ToggleButtons(Weapon weaponData)
    {
        if (weaponData.isPurchased)
        {
            buyButton.interactable = false;
            sellButton.interactable = true;
            equipButton.interactable = true;

            if (weaponData.isEquiped)
                equipButtonText.text = "Unequip";
            else 
                equipButtonText.text = "Equip";     
        }
        else
        {
            buyButton.interactable = true;
            sellButton.interactable = false;
            equipButton.interactable = false;

            equipButtonText.text = "Equip";
        }
    }
    public void SellWeaponClicked()
    {
        currentWeapon.isPurchased = false;

        if (weaponSystem.weaponData == currentWeapon)
            weaponSystem.weaponData = null;

        ChangeData(currentWeapon);
        ToggleButtons(currentWeapon);
    }
    public void BuyWeaponClicked()
    {
        currentWeapon.isPurchased = true;
        PlayerHealthController.Instance.TakeDamage(currentWeapon.weaponPrice);
        ChangeData(currentWeapon);
        ToggleButtons(currentWeapon);
    }
    public void EquipWeaponClicked()
    {
        currentWeapon.isEquiped = !currentWeapon.isEquiped;
        weaponSystem.weaponData = currentWeapon;
        weaponSystem.SetWeaponBehaviour(currentWeapon);
        ChangeData(currentWeapon);
        ToggleButtons(currentWeapon);
    }
}
