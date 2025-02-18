using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject slimeBallPrefab; // Assign in Inspector
    public Transform firePoint; // Position where the slime ball appears
    public float fireRate = 2f; // Time between shots
    private float nextFireTime;
    private Transform target;

    void Start()
    {
        // Find Freaky Frog (Make sure he is tagged as "Player")
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (target == null) return;

        Debug.Log("Enemy Shooting!");

        // Spawn slime ball
        GameObject slimeBall = Instantiate(slimeBallPrefab, firePoint.position, Quaternion.identity);

        // Determine direction towards Freaky Frog
        Vector2 shootDirection = (target.position - firePoint.position).normalized;

        // Send direction to the slime ball
        slimeBall.GetComponent<SlimeProjectile>().SetDirection(shootDirection);
    }
}
