using System;
using Unity.VisualScripting;
using UnityEngine;

public class Turret2 : MonoBehaviour
{
    public Transform target;
    public float detectSnipeRange = 5f;
    public GameObject snipePrefab;
    public Transform snipePoint;
    public float snipeSpeed = 8f;
    public float snipeRate = 1f;
    private float nextFireTime;


    void Start()
    {
    }

    void Update()
    {
       Vector2 directionToTarget =
        (target.position - transform.position).normalized;

        Vector2 forward = transform.right;

        float dot = Vector2.Dot(forward, directionToTarget);

        float distance =
            Vector2.Distance(transform.position, target.position);

        if (dot > 0.98f && distance <= detectSnipeRange)
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + snipeRate;
            }
        
        }
    }

     void Shoot()
    {
        Vector2 direction = (target.position - snipePoint.position).normalized;

        
        GameObject bullet = Instantiate(
                snipePrefab,
                snipePoint.position,
                Quaternion.identity
        );

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.SetDirection(direction, snipeSpeed);
        
    }


}
