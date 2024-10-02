using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baylv1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool cham = false;
    public float tocDo = 3f;
    float moveSpeed = 50f;

    void Start()
    {
        
    }

    
    void Update()
    {
        
        if (cham)
        {
            
            rb.velocity = new Vector2( moveSpeed * Time.deltaTime, rb.velocity.y);


            if (transform.position.x < 10f) 
            {
                Destroy(gameObject); 
            }

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cham = true;
        }
    }


}
