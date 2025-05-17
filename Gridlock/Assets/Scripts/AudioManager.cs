using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("-- Audio Source --")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-- SFX --")]
    public AudioClip MazeMovement;
    public AudioClip Enemy;
    public AudioClip Death;
    public AudioClip Footsteps;
    public AudioClip Static;
    public AudioClip GunShot;
    public AudioClip GunReload;
    public AudioClip GunNoAmmo;
    public AudioClip Winning;
    public AudioClip UI;

    [Header("-- Music --")]
    public AudioClip MainMenuTheme;
    public AudioClip GameplayTheme;

    private void Start()
    {
        if (SceneManager.GetSceneByName("MainMenu").isLoaded)
        {
            MusicSource.clip = MainMenuTheme;
            MusicSource.Play();
        }
        if (SceneManager.GetSceneByName("Level").isLoaded)
        {
            MusicSource.clip = GameplayTheme;
            MusicSource.Play();
        }

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
