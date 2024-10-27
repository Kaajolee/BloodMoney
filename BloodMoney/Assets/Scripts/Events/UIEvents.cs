using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Video.VideoPlayer;

public class UIEvents : MonoBehaviour
{

    private static UIEvents _instance;
    public static UIEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Events is null");
            }
            return _instance;
        }
    }

    public delegate void UIEventsHandler();
    public event UIEventsHandler HealthAmountChanged;
    public event UIEventsHandler ShopTriggered;
    public event UIEventsHandler WeaponEquiped;

    //shop ui
    public event UIEventsHandler ShopMoveLeftClicked;
    public event UIEventsHandler ShopMoveRightClicked;
    public event UIEventsHandler ShopWeaponsClicked;
    public event UIEventsHandler ShopThrowablesClicked;
    public event UIEventsHandler ShopSpecialsClicked;

    //sound
    public event UIEventsHandler AnyButtonClicked;

    private void Awake()
    {
        _instance = this;
    }
    public void PlayerTriggeredShop()
    {
        ShopTriggered?.Invoke();
    }
    public void PlayerEquipedWeapon()
    {
        WeaponEquiped?.Invoke();
    }
    public void ShopLeftClicked()
    {
        ShopMoveLeftClicked?.Invoke();
    }
    public void ShopRightClicked()
    {
        ShopMoveRightClicked?.Invoke();
    }
    public void ShopWeaponsTabClicked()
    {
        ShopWeaponsClicked?.Invoke();
    }
    public void ShopThrowablesTabClicked()
    {
        ShopThrowablesClicked?.Invoke();
    }
    public void ShopSpecialsTabClicked()
    {
        ShopSpecialsClicked?.Invoke();
    }
    public void ButtonClicked()
    {
        AnyButtonClicked?.Invoke();
    }
}
