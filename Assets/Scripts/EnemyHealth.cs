using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2; 

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
        Destroy(gameObject); 
    }
}
