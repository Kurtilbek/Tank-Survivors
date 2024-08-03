using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float projectileSpeed = 10f;
    public float enemyShootDistance = 10f;

    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if (CompareTag("Player") && Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else if (CompareTag("Enemy"))
            {
                Transform player = GameObject.FindWithTag("Player").transform;
                if (Vector3.Distance(transform.position, player.position) < enemyShootDistance)
                {
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projScript = projectile.GetComponent<Projectile>();
        projScript.shooterTag = tag; // ”станавливаем тег стрел€ющего объекта
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * projectileSpeed + GetComponent<Rigidbody>().velocity; // —кладываем скорости
        nextFireTime = Time.time + 1f / fireRate;
    }
}