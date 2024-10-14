using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawnPoint;

    [SerializeField]
    private float destroyTime;

    [SerializeField]
    private float attackSpeed;

    private Coroutine shootingCoroutine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(shootingCoroutine == null)
                shootingCoroutine = StartCoroutine(InstantiateBullet(attackSpeed));
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
                
        }
    }
    public IEnumerator InstantiateBullet(float attackSpeed)
    {
        
        while (true)
        {
            GameObject instantiatedBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            BulletMoveScript bulletScript = GetComponent<BulletMoveScript>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(bulletSpawnPoint.up);
            }
            Destroy(instantiatedBullet, destroyTime);
            yield return new WaitForSeconds(1 / attackSpeed);
        }

    }
}
