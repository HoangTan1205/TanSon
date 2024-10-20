using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Data_User_Login;
public class Door : MonoBehaviour
{
    [SerializeField] private Data_User_Login data_User_Login;
    [SerializeField] private Animator ani;
    [SerializeField] private bool win;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private int level;
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
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
            Tanglevel();
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
    private void Tanglevel()
    {
        if(level == data_User_Login.levelUser)
        {
            data_User_Login.levelUser++;
        }
        else return;
                 
    }

}
