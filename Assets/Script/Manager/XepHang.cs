using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
public class XepHang : MonoBehaviour
{
    [SerializeField] private Scr_TableOject listUser;
    [SerializeField] private TextMeshProUGUI TenTop3;
    [SerializeField] private TextMeshProUGUI DiemTop3;
    void Start()
    {

        var tim = listUser.List_User.OrderByDescending(p => p.DiemCao).Take(3).ToList();


        foreach (var player in tim)
        {
            TenTop3.text += player.UserName.ToString() + '\n';
            DiemTop3.text += player.DiemCao.ToString() + '\n';
        }


    }
}
