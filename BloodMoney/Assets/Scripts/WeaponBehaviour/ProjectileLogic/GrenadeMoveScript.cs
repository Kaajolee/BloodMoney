using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMoveScript : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    private Vector2 direction;

    [HideInInspector]
    public float grenadeDamage;
    public float grenadeTimer;

    public float throwForce;
    public float explosionRadius;

    public List<Sprite> sprites;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on Grenade object.");
            return;
        }

        direction = transform.up;
        ThrowGrenade();
    }
    public void SetDirection(Vector2 setDirection)
    {
        direction = setDirection.normalized;
    }
    public void SetRadius(float radius)
    {
        explosionRadius = radius;
    }
    public void SetDamage(float damage)
    {
        grenadeDamage = damage;
    }

    void ThrowGrenade()
    {
        //Debug.Log("Grenade thrown");
        rb.AddForce(direction * throwForce, ForceMode2D.Impulse);
        StartCoroutine(GrenadeTimer());
    }
    private void CollisionDetection()
    {


        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var item in collisions)
        {
            if (item.gameObject.tag == "Enemy")
            {
                EnemyHealthController enemyHealthController = item.GetComponent<EnemyHealthController>();
                DoDamage(enemyHealthController);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(0, 0);
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
    }
    public void DoDamage(EnemyHealthController enemyHealthController)
    {
        enemyHealthController.TakeDamage(grenadeDamage);
    }
    public void InitializeAnimation()
    {
        SpriteAnimator anim = spriteRenderer.gameObject.AddComponent<SpriteAnimator>();

        anim.animSpeed = 0.08f;
        anim.sprites = sprites;
        anim._spriteRenderer = spriteRenderer;

        spriteRenderer.transform.localScale = new Vector3(300, 300, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        anim.StartAnimation();

        rb.velocity = Vector3.zero;
        rb.freezeRotation = true;

        CollisionDetection();
        Destroy(gameObject, 0.7f);
    }
    IEnumerator GrenadeTimer()
    {
        float elapsedTime = 0f;

        while (elapsedTime <= grenadeTimer)
        {

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        InitializeAnimation();
    }
}

