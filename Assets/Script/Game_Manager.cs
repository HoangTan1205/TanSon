using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scr_TableOject;

using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private List<ThongTin> listTT = new List<ThongTin>();
    [SerializeField] private Scr_TableOject data;
    [SerializeField] private string file;

    private void Start()
    {
        file = "Data_User";
        LoadTextLinh(file);
        
    }
    public void LoadTextLinh(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            ThongTin tt = new ThongTin();
            tt.Id = Convert.ToInt32(cols[0]);
            tt.UserName = cols[1];
            tt.Pass = cols[2];
            tt.Level = Convert.ToInt32(cols[3]);
            tt.AmThanh = Convert.ToInt32(cols[4]);
            tt.DiemCao = Convert.ToInt32(cols[5]);
            listTT.Add(tt);
            TableObject list = new TableObject(tt.Id, tt.UserName, tt.Pass, tt.Level, tt.AmThanh, tt.DiemCao);
            data.List_User.Add(list);

        }
    }

    // public int ThemID()
    // {
    //     int tim = listTT.Max(tt => tt.Id);
    //     return tim + 1;
    // }

    public void AppendData( string playerName, string pass)
    {
        
        string newLine =  + '\t' + playerName + '\t' + pass + '\t'+ 1 + '\t'+ 1 + '\t'+ 0;

        File.AppendAllText(file, newLine + "\n");

    }
    



}
[System.Serializable]
public class ThongTin
{
    public int Id;
    public string UserName;
    public string Pass;
    public int Level;
    public int AmThanh;
    public int DiemCao;
}