using UnityEngine;

public class FreakyFrogHealth : MonoBehaviour
{
    public int health = 5;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Freaky Frog took damage! Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Freaky Frog has been defeated!");

        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); 
    }
}
