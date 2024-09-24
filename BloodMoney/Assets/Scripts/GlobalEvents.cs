using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Video.VideoPlayer;

public class GlobalEvents : MonoBehaviour
{

    private static GlobalEvents _instance;
    public static GlobalEvents Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Global events is null");
            }
            return _instance;
        }
    }

    public delegate void GameEventHandler();
    public event GameEventHandler HealthAmountChanged;

    private void Awake()
    {
        _instance = this;
    }

    public void HealthChanged()
    {
        HealthAmountChanged?.Invoke();
    }
}
