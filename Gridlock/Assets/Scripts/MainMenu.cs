using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level");
    }
    public void OptionsButton()
    {
        audioManager.PlaySFX(audioManager.UI);
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Additive);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
