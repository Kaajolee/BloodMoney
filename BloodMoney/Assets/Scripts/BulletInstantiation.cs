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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateBullet();
        }
    }
    public void InstantiateBullet()
    {
        GameObject instantiatedBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletMoveScript bulletScript = GetComponent<BulletMoveScript>();
        if(bulletScript != null)
        {
            bulletScript.SetDirection(bulletSpawnPoint.up);
        }
        Destroy(instantiatedBullet, destroyTime);
    }
}
