using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baylv1 : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool cham = false;
    [SerializeField] float moveSpeed = 1300f;
    void Start()
    {
        
    }

  
    void Update()
    {       
        if (cham)
        {

            rb.velocity = new Vector2( moveSpeed * Time.deltaTime, rb.velocity.y);

            Destroy(gameObject, 1f);

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
