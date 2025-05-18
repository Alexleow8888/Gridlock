using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void ContinueButton()
    {
        audioManager.PlaySFX(audioManager.UI);
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
    }
    public void OptionsButton()
    {
        audioManager.PlaySFX(audioManager.UI);
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Additive);
    }
    public void MainMenuButton()
    {
        
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
