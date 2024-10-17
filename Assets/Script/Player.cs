using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; 
    [SerializeField] private float jumpForce = 10f; 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector2 movement;
    [SerializeField] Animator ani;

    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        Jump();

    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveInput, 0);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

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
            //audioManager.PlaySFX(audioManager.jump);
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
            // audioManager.PlaySFX(audioManager.gameOver);
            moveSpeed = 0f;
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
