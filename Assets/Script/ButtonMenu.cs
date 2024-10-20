using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Data;
using UnityEditor;
using UnityEngine.SceneManagement;
using static Scr_TableOject;
public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private string file = "Data_User";
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Scr_TableOject data;
    [SerializeField] private Data_User_Login Data_User_Login;
    [SerializeField] private TextMeshProUGUI hienTTUserName;
    [SerializeField] private TextMeshProUGUI hienTTDiemCao;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Login;

    private void Awake()
    {
        if (Data_User_Login.idUser != 0)
        {
            SetActiveMenu();
            addTT();
        }
        else
        {
            SetPanelLogin();
        }
    }
    public void DangNhap()
    {
        string username = usernameField.text;
        string password = passwordField.text;
        if (CheckInput(username, password))
        {
            messageText.text = "Đăng nhập thành công! Đang tải dữ liệu...";

        }
        else
        {
            messageText.text = "Sai tên đăng nhập hoặc mật khẩu!";
        }
    }

    private bool CheckInput(string username, string password)
    {
        var user = data.List_User.FirstOrDefault(u => u.UserName == username && u.Pass == password);
        if (user != null)
        {
            Data_User_Login.idUser = user.Id;
            Data_User_Login.userName = user.UserName;
            Data_User_Login.passwordUser = user.Pass;
            Data_User_Login.levelUser = user.Level;
            Data_User_Login.diemCao = user.DiemCao;
            Data_User_Login.sound = user.AmThanh;

            hienTTUserName.text = "User: " + user.UserName;
            hienTTDiemCao.text = "High Score: " + user.DiemCao.ToString();
            Invoke("SetActiveMenu", 1.5f);
            Invoke("ClearInput", 2f);
            return true;
        }
        return false;
    }
    public int ThemID()
    {
        int tim = data.List_User.Max(tt => tt.Id);
        return tim + 1;
    }
    private void addTT()
    {
        hienTTUserName.text = "User: " + Data_User_Login.userName;
        hienTTDiemCao.text = "High Score: " + Data_User_Login.diemCao.ToString();
    }
    public void DangKy()
    {
        if (string.IsNullOrEmpty(usernameField.text))
        {
            messageText.text = "Tên Đăng Nhập không được để trống";
            return;
        }
        else if (string.IsNullOrEmpty(passwordField.text))
        {
            messageText.text = "Mật khẩu không được để trống";
            return;
        }

        // Kiểm tra xem tài khoản đã tồn tại chưa
        if (KiemTraUserName(usernameField.text))
        {
            messageText.text = "Tên Đăng Nhập đã tồn tại";
        }
        else
        {
            TableObject list = new TableObject(ThemID(), usernameField.text, passwordField.text, 1, 1, 0);
            data.List_User.Add(list);
            if (CheckInput(usernameField.text, passwordField.text))
            {
                messageText.text = "Đăng Ký thành công! Đang tải dữ liệu...";

            }
            else
            {
                messageText.text = "Đăng ký thất bại...";
            }
            


            
        }
    }
    public void Play()
    {
        int level = Data_User_Login.levelUser;
        SceneManager.LoadScene(level);

    }

    private bool KiemTraUserName(string usernameToCheck)
    {
        // Kiểm tra xem username đã tồn tại chưa
        foreach (var account in data.List_User)
        {
            string accountData = account.UserName;

            if (accountData == usernameToCheck)
            {
                return true;
            }
        }
        return false;
    }
    private void SetActiveMenu()
    {
        Login.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
    }
    private void SetPanelLogin()
    {
        Login.gameObject.SetActive(true);
        Menu.gameObject.SetActive(false);
    }
    private void ClearInput()
    {
        usernameField.text = "";
        passwordField.text = "";
        messageText.text = "";

    }
}
