using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level");
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Additive);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
