using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap3_2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool cham = false;
    [SerializeField] private float moveSpeed = 1500f;
    void Start()
    {

    }
    private void Update()
    {
        if (cham)
        {
            StartCoroutine(ChuyenMan());
        }
    }
    IEnumerator ChuyenMan()
    {      
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed * Time.deltaTime );
        yield return new WaitForSeconds(0.5f);
        moveSpeed = 0;
        yield return new WaitForSeconds(2f);
        moveSpeed = 1500f;
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed * Time.deltaTime* -1);
        yield return new WaitForSeconds(2f);
        moveSpeed = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cham = true;
        }
    }
}
