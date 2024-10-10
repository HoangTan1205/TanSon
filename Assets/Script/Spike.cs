using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Spike : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOMove(new Vector3(2, -1.1f, 0), 0.25f);
        }
    }

    
}
