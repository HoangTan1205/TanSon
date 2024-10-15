using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataUser", menuName = ("Infor/ThongTin"), order = 1)]
public class Scr_TableOject : ScriptableObject
{
    public List<TableObject> List_User = new List<TableObject>();
    [System.Serializable]
    public class TableObject
    {
        public int Id;
        public string UserName;
        public string Pass;
        public int Level;
        public int AmThanh;
        public int DiemCao;

        public TableObject(int id, string userName, string pass, int level, int amThanh, int diemCao)
        {
            Id = id;
            UserName = userName;
            Pass = pass;
            Level = level;
            AmThanh = amThanh;
            DiemCao = diemCao;
        }

        
    }
}
