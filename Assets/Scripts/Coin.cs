using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;
    private Rigidbody2D rb;
    private bool hasTouchedGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            PlayCoinSound();
            Destroy(gameObject); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!hasTouchedGround)  
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5f);  
                hasTouchedGround = true;  
            }
            else
            {
                rb.linearVelocity = Vector2.zero; 
                rb.gravityScale = 0;
                rb.isKinematic = true;  
            }
        }
    }

    void PlayCoinSound()
    {
        if (coinSound != null)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }
    }
}
