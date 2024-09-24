using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bay1 : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float TocDoChay = 300;
    [SerializeField] float TocDo;
    void Start()
    {
        StartCoroutine(Kichhoat());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Kichhoat()
    {

        yield return new WaitForSeconds(0.5f);
        TocDo = transform.localScale.x * TocDoChay;
        body.velocity = new Vector2(TocDo, 0f);
        yield return new WaitForSeconds(1f);
        body.velocity = new Vector2(0, 0f);

    }
}
