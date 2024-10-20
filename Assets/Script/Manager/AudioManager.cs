using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Data_User_Login Data_User_Login;

    public AudioSource musicSource;
    public AudioSource SFX_Source;

    public AudioClip backGround;
    public AudioClip jump;
    public AudioClip gameOver;
    //public AudioClip finish;
    public AudioClip click;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);  
        }
        PlayMusic(backGround);
    }
    private void Start()
    {
        if (Data_User_Login.sound == 1)
        {
            
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }

    public void PlaySFX(AudioClip clip)
    {     
        SFX_Source.clip = clip;
        if (Data_User_Login.sound == 1)
        {
            SFX_Source.PlayOneShot(clip);
        }
       
    }
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
    }
}
