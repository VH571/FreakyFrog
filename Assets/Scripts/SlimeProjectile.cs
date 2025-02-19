using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private Vector2 moveDirection;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;

        transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        if (direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true; 
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Debug.Log("Freaky Frog hit!");
            collision.GetComponent<FreakyFrogHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject); 
        }
        else if (collision.CompareTag("Enemy")) 
        {
            Debug.Log("Ignored Enemy Hit");
        }
    }

}
