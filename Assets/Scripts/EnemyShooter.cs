using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject slimeBallPrefab; 
    public Transform firePoint;
    public float fireRate = 2f; 
    private float nextFireTime;
    private Transform target;

    private Animator animator; 


    void Start()
    {
        animator = GetComponent<Animator>();
        
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
        if (animator != null)
        {
        animator.SetTrigger("Attack");
        }

        GameObject slimeBall = Instantiate(slimeBallPrefab, firePoint.position, Quaternion.identity);

        slimeBall.transform.localScale = new Vector3(0.5f, 0.5f, 1f); // Adjust this based on your desired size

        Vector2 shootDirection = (target.position - firePoint.position).normalized;

        slimeBall.GetComponent<SlimeProjectile>().SetDirection(shootDirection);
    }

}
