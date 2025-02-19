using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;
    public GameObject coinPrefab;

    public void TakeDamage()
    {
        health--;
        Debug.Log("Enemy took damage! Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Defeated!");

        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
