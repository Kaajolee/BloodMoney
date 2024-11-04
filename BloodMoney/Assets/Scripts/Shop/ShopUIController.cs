using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    [Header("Labels to show item data")]
    [Space]
    [SerializeField]
    private TextMeshProUGUI gunName;

    [SerializeField]
    private TextMeshProUGUI gunDamage;

    [SerializeField]
    private TextMeshProUGUI gunPrice;

    [SerializeField]
    private TextMeshProUGUI gunFirerate;

    [Header("Data manipulation buttons")]
    [Space]
    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private Button sellButton;

    [SerializeField]
    private Button equipButton;

    [Header("^____ button texts")]
    [Space]
    [SerializeField]
    private TextMeshProUGUI buyButtonText;

    [SerializeField]
    private TextMeshProUGUI sellButtonText;

    [SerializeField]
    private TextMeshProUGUI equipButtonText;

    [Header("Backend references")]
    [Space]
    private ShopDataController shopDataController;

    [SerializeField]
    private CameraTransition cameraScript;

    private DataVault dataVault;
    private UIEvents uiEvents;

    private void Start()
    {
        dataVault = DataVault.Instance;
        uiEvents = UIEvents.Instance;

        shopDataController = GetComponent<ShopDataController>();

        UpdateCurrentWeaponUI(dataVault.GetCurrentItem());
    }
    public void ToggleButtons(Weapon weaponData)
    {
        if (weaponData.isPurchased)
        {
            buyButton.interactable = false;
            sellButton.interactable = true;
            equipButton.interactable = true;

            if (weaponData.isEquiped)
            {
                equipButtonText.text = "Unequip";
                Debug.Log("TEST");
            }  
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
        gunName.text = weaponData.weaponName;
        gunDamage.text = "Damage: " + weaponData.weaponDamage.ToString();
        gunPrice.text = "Price: " + weaponData.weaponPrice.ToString();
        gunFirerate.text = "Firerate: " + weaponData.weaponFirerate.ToString();
    }
    private void UpdateCurrentWeaponUI(Weapon currentWeapon)
    {
        ChangeUIText(currentWeapon);
        ToggleButtons(currentWeapon);
    }
    #region Equip/Buy/Sell buttons
    public void EquipButtonClicked()
    {
        Weapon currentWeapon = dataVault.GetCurrentItem();
        shopDataController.EquipItem(currentWeapon);
        UpdateCurrentWeaponUI(currentWeapon);
        uiEvents.ButtonClicked();
    }
    public void BuyButtonClicked()
    {
        Weapon currentWeapon = dataVault.GetCurrentItem();
        shopDataController.BuyItem(currentWeapon);
        UpdateCurrentWeaponUI(currentWeapon);
        uiEvents.ButtonClicked();
    }
    public void SellButtonClicked()
    {
        Weapon currentWeapon = dataVault.GetCurrentItem();
        shopDataController.SellItem(currentWeapon);
        UpdateCurrentWeaponUI(currentWeapon);
        uiEvents.ButtonClicked();
    }
    #endregion
    public void MoveMenuLeftClicked()
    {
        if (cameraScript.transitionEnded)
        {
            uiEvents.ShopLeftClicked();
            uiEvents.ButtonClicked();
            cameraScript.MoveLeft();

            Weapon currentWeapon = dataVault.GetCurrentItem();
            UpdateCurrentWeaponUI(currentWeapon);
        }
    }

    public void MoveMenuRightClicked()
    {
        if (cameraScript.transitionEnded)
        {
            uiEvents.ShopRightClicked();
            uiEvents.ButtonClicked();
            cameraScript.MoveRight();

            Weapon currentWeapon = dataVault.GetCurrentItem();
            UpdateCurrentWeaponUI(currentWeapon);
        }
    }
    #region Shop top tabs
    public void WeaponsTabClicked()
    {
        if (cameraScript.transitionEnded)
        {
            uiEvents.ShopWeaponsTabClicked();
            cameraScript.WeaponsClicked();
            uiEvents.ButtonClicked();

            Weapon currentWeapon = dataVault.GetCurrentItem();
            UpdateCurrentWeaponUI(currentWeapon);
        }
    }
    public void ThrowablesTabClicked()
    {
        if (cameraScript.transitionEnded)
        {
            uiEvents.ShopThrowablesTabClicked();
            cameraScript.ThrowablesClicked();
            uiEvents.ButtonClicked();

            Weapon currentWeapon = dataVault.GetCurrentItem();
            UpdateCurrentWeaponUI(currentWeapon);
        }
    }
    public void SpecialsTabClicked()
    {
        if (cameraScript.transitionEnded)
        {
            uiEvents.ShopSpecialsTabClicked();
            cameraScript.SpecialsClicked();
            uiEvents.ButtonClicked();

            Weapon currentWeapon = dataVault.GetCurrentItem();
            UpdateCurrentWeaponUI(currentWeapon);
        }
    }
    #endregion
}
