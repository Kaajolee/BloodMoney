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
    public event UIEventsHandler HealthAmountChanged; // test
    public event UIEventsHandler ShopTriggered; // test
    public event UIEventsHandler WeaponEquiped; // test

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
}
