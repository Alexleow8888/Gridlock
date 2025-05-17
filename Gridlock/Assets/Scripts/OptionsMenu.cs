using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void BackButton()
    {
        audioManager.PlaySFX(audioManager.UI);
        SceneManager.UnloadSceneAsync("OptionsMenu");
    }
}
