using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f; 
    [SerializeField] float jumpForce = 10f; 
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool isGrounded;

    [SerializeField] Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();

    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput != 0)
        {
            ani.SetBool("Run", true);
        }
        else
        {
            ani.SetBool("Run", false);
        }


        if (moveInput > 0)
        {

            transform.localScale = new Vector3(1, 1, 1);
        }          
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Nen"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("VucMap"))
        {
            ani.SetTrigger("Die");
            Destroy(gameObject, 0.5f);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Nen"))
        {
            isGrounded = false;
        }
    }
}
