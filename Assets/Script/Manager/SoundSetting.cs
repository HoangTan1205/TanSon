using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Data_User_Login;
public class SoundSetting : MonoBehaviour
{
    public Toggle soundToggle;
    public AudioManager audioMusic;
    public Data_User_Login data_User_Login;
    public int soundContent;
    void Start()
    {
        audioMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        soundContent = data_User_Login.sound;
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
            audioMusic.PlayMusic(audioMusic.backGround);
            audioMusic.musicSource.Play();
            data_User_Login.sound = 1;

        }
        else
        {
            audioMusic.PlayMusic(audioMusic.backGround);
            audioMusic.musicSource.Stop();
            data_User_Login.sound = 0;
        }
    }
}
