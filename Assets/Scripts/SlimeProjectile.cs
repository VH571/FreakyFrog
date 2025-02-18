using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private Vector2 moveDirection;

    void Start()
    {
        // Destroy slime ball after 5 seconds to prevent memory leaks
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // Move the slime ball
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }

    // ✅ Function to Set Direction When Instantiated
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized; // Ensure it moves correctly
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip sprite if moving left
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Make sure Freaky Frog is tagged as "Player"
        {
            Debug.Log("Freaky Frog hit!");
            collision.GetComponent<FreakyFrogHealth>().TakeDamage(damage);
            Destroy(gameObject); // Destroy slime ball on hit
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject); // Destroy if it hits the ground
        }
        else if (collision.CompareTag("Enemy")) 
        {
            Debug.Log("Ignored Enemy Hit");
        }
    }

}
