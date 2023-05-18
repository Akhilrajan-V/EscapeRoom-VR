using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSystem : MonoBehaviour
{
    [HideInInspector] private Transform enemy;
    public float range = 12f;
    public float Rayrange = 6000f;
    public Transform turretHead;
    
    public Transform target;

    public float turnSpeed = 0.3f;

    public float fireRate = 1f;
    public float fireCountDown = 0f; 

    public Transform bulletSpawnPt;
    public GameObject bulletPrefab;
    CrossbowBuild crossBowed;
    
    ShotBehavior_Turret turret_bullet;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        if(crossBowed.counter >= 3)
        {
            float distanceToTarget = Vector3.Distance(transform.position, enemy.position);
            if(distanceToTarget <= range)
            {
                target = enemy;
            }
            else
            {
                target = null;
            } 
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        turret_bullet.setTarget(target.position);
        Vector3 dirToPoint = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dirToPoint);
        Vector3 rotation = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * turnSpeed) .eulerAngles;
        turretHead.rotation = Quaternion.Euler(0f, rotation.y, 0f); 
        if (fireCountDown <= 0f)
        {
            shoot();
            fireCountDown = 1f/fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void shoot()
    {
    Debug.Log("Shoot");
    Instantiate(bulletPrefab, bulletSpawnPt.position, bulletSpawnPt.rotation);
    
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
