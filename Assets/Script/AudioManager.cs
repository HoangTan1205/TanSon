using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------------Audio Source---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFX_Source;

    [Header("---------------Audio Clip---------------")]
    public AudioClip backGround;
    public AudioClip jump;
    public AudioClip gameOver;
    public AudioClip finish;
    public AudioClip click;

    private void Start()
    {
           musicSource.clip = backGround;
           musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
       SFX_Source.PlayOneShot(clip);
    }
}
