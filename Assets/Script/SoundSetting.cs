using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Data_User_Login;
public class SoundSetting : MonoBehaviour
{
    public Toggle soundToggle;
    public AudioSource backgroundMusic;
    public Data_User_Login Data_User_Login;
    public int soundContent;
    void Start()
    {
        soundContent = Data_User_Login.sound;
        LoadToggleState();

        soundToggle.onValueChanged.AddListener(delegate { ToggleSound(soundToggle); });
    }

    void LoadToggleState()
    {
        if (soundContent == 1)
        {
            
            soundToggle.isOn=true;
        }
        else
        {
            soundToggle.isOn = false;
        }
    }

    public void ToggleSound(Toggle toggle)
    {
        if (toggle.isOn)
        {
            backgroundMusic.Play();

        }
        else
        {
            backgroundMusic.Stop();

        }
    }
}
