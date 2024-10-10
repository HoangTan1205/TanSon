using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChainLv3 : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.DOMove(new Vector3(1, -1.24f, 0), 3f);
        }
    }
}
