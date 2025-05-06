using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ContinueButton()
    {

        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Additive);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
