using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Animator ani;
    [SerializeField] bool win;
    void Start()
    {
        
    }


    void Update()
    {
        if (win)
        {
            ani.SetTrigger("win");

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            win = true;
        }
    }
}
