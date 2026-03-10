using UnityEngine;

public class EnemyShooting : MonoBehaviour, IShooter
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 7f;
    public float shootInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * projectileSpeed;
    }
}
