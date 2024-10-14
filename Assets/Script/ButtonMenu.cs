using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private string file = "Data_User";
    public InputField usernameInput;
    public InputField passwordInput;
    public Text messageText;
    [SerializeField] private Scr_TableOject data;
    public int ThemID()
    {
        int tim = data.List_User.Max(tt => tt.Id);
        return tim + 1;
    }
    public void DangKy()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            messageText.text = "Username and password cannot be empty!";
            return;
        }

        using (StreamWriter writer = new StreamWriter(file, true))
        {
            writer.WriteLine($"{ThemID()}'\t'{username}'\t'{password}'\t'{1}'\t'{1}'\t'{0}");
        }

        messageText.text = "Registration successful!";
    }

    public void DangNhap()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            messageText.text = "Username and password cannot be empty!";
            return;
        }

        // Đọc file và kiểm tra thông tin đăng nhập
        bool loginSuccessful = false;
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] credentials = line.Split(',');

                if (credentials.Length == 2 && credentials[0] == username && credentials[1] == password)
                {
                    loginSuccessful = true;
                    break;
                }
            }
        }

        messageText.text = loginSuccessful ? "Login successful!" : "Invalid username or password.";
    }
}
