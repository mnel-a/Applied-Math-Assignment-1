using System;
using Unity.VisualScripting;
using UnityEngine;

public class Turret3 : MonoBehaviour
{
    public Transform target;
    public float detectGunRange = 5f;
    public float rotateSpeed = 40f;
    public GameObject gunPrefab;
    public Transform gunPoint;
    public float gunSpeed = 8f;
    public float gunRate = 1f;
    private float nextFireTime;
    public GameObject flashPrefab;
    public float flashDuration = 0.3f;
    public float shootDelay = 0.1f;


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


        if(distance <= detectGunRange)
        {
            RotateToTarget();

             if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + gunRate;
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
        StartCoroutine(ShootRoutine());
    }

    System.Collections.IEnumerator ShootRoutine()
    {

    GameObject flash = Instantiate(
        flashPrefab,
        gunPoint.position,
        transform.rotation
    );

    Destroy(flash, flashDuration);

    yield return new WaitForSeconds(shootDelay);

  
    Vector2 direction =
        (target.position - gunPoint.position).normalized;

    GameObject bullet = Instantiate(
        gunPrefab,
        gunPoint.position,
        Quaternion.identity
    );

    Bullet bulletScript = bullet.GetComponent<Bullet>();

    bulletScript.SetDirection(direction, gunSpeed);
    }


}

