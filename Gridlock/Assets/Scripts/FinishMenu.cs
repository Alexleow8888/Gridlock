using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void RestartButton()
    {
        audioManager.PlaySFX(audioManager.UI);
        SceneManager.LoadScene("Level");
    }
    public void MainMenuButton()
    {
        audioManager.PlaySFX(audioManager.UI);
        SceneManager.LoadScene("MainMenu");
    }
}
