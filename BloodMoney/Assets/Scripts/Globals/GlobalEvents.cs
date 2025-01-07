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
    public event GameEventHandler SlotSpinClicked;
    public event GameEventHandler SlotSpinEnded;
    public event GameEventHandler EnemyDied;
    public event GameEventHandler EndWave;
    public event GameEventHandler PlayerIsDeadCasino;
    public event GameEventHandler PlayerIsDeadOther;
    public event GameEventHandler Respawn;
    public event GameEventHandler NukeExploded;

    private void Awake()
    {
        _instance = this;
    }

    public void HealthChanged()
    {
        HealthAmountChanged?.Invoke();
    }
    public void SpinClicked()
    {
        SlotSpinClicked?.Invoke();
    }
    public void SpinEnded()
    {
        SlotSpinEnded?.Invoke();
    }
    public void EnemyKilled()
    {
        EnemyDied?.Invoke();
    }
    public void WaveEnded()
    {
        EndWave?.Invoke();
    }
    public void PlayerDiedCasino()
    {
        PlayerIsDeadCasino?.Invoke();
    }
    public void PlayerDiedOther()
    {
        PlayerIsDeadOther?.Invoke();
    }
    public void Reload()
    {
        Respawn?.Invoke();
    }
    public void NukeBoom()
    {
        NukeExploded?.Invoke();
    }
}
