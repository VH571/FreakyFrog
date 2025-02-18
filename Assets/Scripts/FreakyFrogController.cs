using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreakyFrogController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 12f;
    private bool isJumping = false;
    private bool isAttacking = false;
    public GameObject tongue;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        
        if (AnimatorHasParameter("isRunning"))
        {
            animator.SetBool("isRunning", move != 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        
        if (move > 0)
        {
            spriteRenderer.flipX = false; // Face Right
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true; // Face Left
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true);
        animator.Play("FreakyFrog_Attack");
        tongue.SetActive(true);

        yield return new WaitForSeconds(0.3f);


        tongue.SetActive(false);
        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }


    private bool AnimatorHasParameter(string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
                return true;
        }
        return false;
    }
}
