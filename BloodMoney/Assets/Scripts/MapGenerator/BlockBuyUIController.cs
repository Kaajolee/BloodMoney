using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuyUIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReferenceVault.Instance.BlockBuyPopUp.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ReferenceVault.Instance.BlockBuyPopUp.SetActive(false);
    }
}
