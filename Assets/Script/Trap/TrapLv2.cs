using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLv2 : MonoBehaviour
{

    public GameObject Bay1;
    public GameObject Bay2;

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Bay1.SetActive(false);
            Bay2.SetActive(true);
        }
    }
}
