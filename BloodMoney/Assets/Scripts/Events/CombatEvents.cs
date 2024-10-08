using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Video.VideoPlayer;

public class CombatEvents : MonoBehaviour
{

    private static CombatEvents _instance;
    public static CombatEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Combat events is null");
            }
            return _instance;
        }
    }

    public delegate void CombatEventHandler();
    public event CombatEventHandler HealthAmountChanged; // test

    private void Awake()
    {
        _instance = this;
    }

    public void HealthChanged()
    {
        HealthAmountChanged?.Invoke();
    }
}
