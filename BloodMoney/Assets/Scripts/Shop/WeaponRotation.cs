using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationIncrement;
    void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(0, 0, rotationIncrement * Time.deltaTime);
    }

}
