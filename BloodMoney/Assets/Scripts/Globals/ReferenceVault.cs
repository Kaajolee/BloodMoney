using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceVault : MonoBehaviour
{
    private static ReferenceVault _instance;
    public static ReferenceVault Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("ReferenceVault is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public GameObject BlockBuyPopUp;
}
