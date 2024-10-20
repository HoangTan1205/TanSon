using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataUserLogin", menuName = ("Infor/InforUserLogin"), order = 1)]
public class Data_User_Login : ScriptableObject
{
    public int idUser;
    public string userName;
    public string passwordUser;
    public int levelUser;
    public int sound;
    public int diemCao;
}
