using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float bulletSpeed;

    Rigidbody2D rb;

    [SerializeField]
    private Vector2 direction;

    public float bulletDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        direction = transform.up;

        rb.velocity = direction * bulletSpeed * Time.deltaTime;
    }
    public void SetDirection(Vector2 setDirection)
    {
        direction = setDirection.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBullet();
    }

    public void MoveBullet()
    {
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealthController enemyHealthController = collision.gameObject.GetComponent<EnemyHealthController>();
            DoDamage(enemyHealthController);
            Destroy(gameObject);
        }
    }
    public void DoDamage(EnemyHealthController enemyHealthController)
    {
        enemyHealthController.TakeDamage(bulletDamage);
    }
}
