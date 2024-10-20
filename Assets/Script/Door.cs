using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator ani;
    [SerializeField] private bool win;
    [SerializeField] private GameObject panelWin;
    void Start()
    {
        
    }


    void Update()
    {
        if (win)
        {
            ani.SetBool("nv",true);
            

        }
        else ani.SetBool("nv", false);
    }
  
 
    IEnumerator ChuyenMan()
    {
        yield return new WaitForSeconds(2f);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            win = true;
            Destroy(collision.gameObject, 0.7f);
            StartCoroutine(HienPanel());
            //StartCoroutine(ChuyenMan());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            win = false;
        }
    }
    IEnumerator HienPanel()
    {
        yield return new WaitForSeconds(1f);
        panelWin.SetActive(true);
    }

}
