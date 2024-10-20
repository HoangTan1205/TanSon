using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapLv3 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 900;
    void Start()
    {
        
    }
    private void Update()
    {
       
        StartCoroutine(ChuyenMan());
    }
    IEnumerator ChuyenMan()
    {
        yield return new WaitForSeconds(2f);
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
        yield return new WaitForSeconds(2.1f);
        moveSpeed = 0;
    }



}
