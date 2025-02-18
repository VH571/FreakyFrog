using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit!");
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage();
        }
    }

}
