using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void RetryButton()
    {
        SceneManager.LoadScene("Level");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
