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
    private WeaponSystem weaponSystem;

    [SerializeField]
    private Weapon currentWeapon;

    [SerializeField]
    private Weapon equipedWeapon;

    [SerializeField]
    private Weapon[] gunsData, throwablesData, specialsData;


    [SerializeField]
    private Transform[] weaponClassParents;

    private void Start()
    {
        gunsData = SetInitialData(weaponClassParents[0]);
        throwablesData = SetInitialData(weaponClassParents[1]);
        specialsData = SetInitialData(weaponClassParents[3]);
    }
    public void ChangeData(WeaponClass weaponClass, int index)
    {
        switch (weaponClass)
        {
            case WeaponClass.None:

                break;


            case WeaponClass.Gun:
                currentWeapon = gunsData[index];
                break;


            case WeaponClass.Throwable:
                currentWeapon = throwablesData[index];
                break;


            case WeaponClass.Special:
                currentWeapon = specialsData[index];
                break;
        }

        ChangeUIText(currentWeapon);

        ToggleButtons(currentWeapon);

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
    public void ChangeUIText(Weapon weaponData)
    {
        GunName.text = weaponData.weaponName;
        GunDamage.text = "Damage: " + weaponData.weaponDamage.ToString();
        GunPrice.text = "Price: " + weaponData.weaponPrice.ToString();
        GunFirerate.text = "Firerate: " + weaponData.weaponFirerate.ToString();
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
    public void UnequipOtherItems(Weapon[] dataArray, Weapon equipedWeapon)
    {

        //problema: equip/unequip neveikia, kaip atskirti change data kad nedarytu per daug
        foreach (var item in dataArray)
        {
            item.isEquiped = false;
        }
        equipedWeapon.isEquiped = true;
    }
    public Weapon[] SetInitialData(Transform weaponClassParent)
    {
        DataHolder[] dataHolders = weaponClassParent.GetComponentsInChildren<DataHolder>();
        
        Weapon[] arrayToFill = new Weapon[dataHolders.Length];

        for (int i = 0; i < dataHolders.Length; i++)
        {
            if (dataHolders[i].DataObject is Weapon weapon)
                arrayToFill[i] = weapon;
            else
                Debug.LogWarning("Data holder is not of type Weapon");
        }
        return arrayToFill;
    }
}
