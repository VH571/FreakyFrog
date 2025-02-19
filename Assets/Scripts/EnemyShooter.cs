using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject slimeBallPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float nextFireTime;
    private Transform target;
    public AudioClip slimeSound;
    void Start()
    {

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
        PlaySound();
        Debug.Log("Enemy Shooting!");

        GameObject slimeBall = Instantiate(slimeBallPrefab, firePoint.position, Quaternion.identity);

        slimeBall.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        Vector2 shootDirection = (target.position - firePoint.position).normalized;

        slimeBall.GetComponent<SlimeProjectile>().SetDirection(shootDirection);
    }
    void PlaySound()
    {
        if (slimeSound != null)
        {
            AudioSource.PlayClipAtPoint(slimeSound, transform.position);
        }
    }
}
