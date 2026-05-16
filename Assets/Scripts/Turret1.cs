using System;
using Unity.VisualScripting;
using UnityEngine;

public class Turret1 : MonoBehaviour
{
    public Transform target;
    public float detectRange = 5f;
    public float rotateSpeed = 40f;

    public GameObject firePrefab;
    public Transform firePoint;
    public float fireSpeed = 8f;
    public float fireRate = 1f;

    public int numberFire = 5;
    public float spreadAngle = 45f;
    private float nextFireTime;


    void Start()
    {
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);


        if(distance <= detectRange)
        {
            RotateToTarget();

             if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    
    }

     void RotateToTarget()
     
     {
        var direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
     }

     void Shoot()
    {
        Vector2 direction = (target.position - firePoint.position).normalized;

        float angleStep = spreadAngle / (numberFire - 1);

        float angle = -spreadAngle / 2;

        for (int i = 0; i < numberFire; i++)
        {
            float bulletDirX =
                direction.x * Mathf.Cos(angle * Mathf.Deg2Rad) -
                direction.y * Mathf.Sin(angle * Mathf.Deg2Rad);

            float bulletDirY =
                direction.x * Mathf.Sin(angle * Mathf.Deg2Rad) +
                direction.y * Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector2 bulletDirection =
                new Vector2(bulletDirX, bulletDirY).normalized;

            // Spawn bullet
            GameObject bullet = Instantiate(
                firePrefab,
                firePoint.position,
                Quaternion.identity
            );

            // Send direction to bullet
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            bulletScript.SetDirection(bulletDirection, fireSpeed);

            angle += angleStep;
        }
    }


}
