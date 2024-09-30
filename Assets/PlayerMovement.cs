using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rb_sprite;
    [SerializeField] float speed = 7f;
    [SerializeField] float jumpForce = 14f;
    float dirX = 0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb_sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * speed, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SSSSSSSSSSSSSSSS");
            rb.velocity = new Vector2 (rb.velocity.x,jumpForce);
        }
    }
}
