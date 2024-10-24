using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIDamage : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //private Collider2D slashCollider;

    [SerializeField]
    private SpriteAnimator spriteAnimator;

    public int zombieDamage;

    void Start()
    {
        //slashCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DoDamageToPlayer(zombieDamage);
            Debug.Log("Player damaged");
        }
            
    }
    public void DoDamageToPlayer(int damageAmount)
    {
        spriteAnimator.StartAnimation();
        PlayerHealthController.Instance.TakeDamage(damageAmount);
    }
}
