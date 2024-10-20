using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscEvents : MonoBehaviour
{
    private static MiscEvents _instance;
    public static MiscEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MiscEvents is null");
            }
            return _instance;
        }
    }

    public delegate void MiscEventsHandler();


    private void Awake()
    {
        _instance = this;
    }

}
