using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuy : MonoBehaviour
{
    [SerializeField]
    private int blockPrice;

    [SerializeField]
    private float priceMultiplier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyBlock()
    {
        float currentPlayerHealth = PlayerHealthController.Instance.health;

        if (currentPlayerHealth >= blockPrice) 
        {
            PlayerHealthController.Instance.TakeDamage(blockPrice);
            BlockGenerator.Instance.InstantiateBlock();
            blockPrice = (int)((int)blockPrice * priceMultiplier);  
        }
    }
}
