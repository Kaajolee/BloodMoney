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
    }
}
