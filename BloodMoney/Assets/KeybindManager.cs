using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject performanceGO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleObject(performanceGO);
        }
    }
    void ToggleObject(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
