
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source ")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("Audio Clip ")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip bullet;
    public AudioClip GameOver;
    public AudioClip Jump;
    public AudioClip ShowrdHit;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX (AudioClip clip)
    {
        SFXSource.PlayOneShot (clip);
    }

}
