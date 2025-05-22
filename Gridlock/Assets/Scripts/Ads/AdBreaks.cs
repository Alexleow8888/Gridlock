using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdBreaks : MonoBehaviour
{
    
    public int randomValue;
    int AdIntermission = 1;

    public PerksValues PerksValues;
    public ShopValues ShopValues;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        randomValue = Random.Range(20, 31);
        PlayerMovement.Countdown = randomValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (AdIntermission == 1)
        {
            StartCoroutine(PlayTime());
        }
        Debug.Log(Maze.Phase);
    }
    public IEnumerator PlayTime()
    {
        // Will trigger after a random interval and will cause the Ads and Shop to appear whilst restricting player movement.
        AdIntermission = 0;
        yield return new WaitForSeconds(randomValue);
        Debug.Log("Done " + randomValue);
        if (!SceneManager.GetSceneByName("ShopUI").isLoaded && !SceneManager.GetSceneByName("PerksUI").isLoaded)
        {
            SceneManager.LoadScene("Ads", LoadSceneMode.Additive);
            SceneManager.LoadScene("ShopUI", LoadSceneMode.Additive);
            audioManager.PlaySFX(audioManager.MazeMovement);
            Time.timeScale = 0;
            PerksValues.PerkPoints += 1;
            
            if (Maze.Phase == 4)
            {
                Maze.Phase = 0;
            }
            
            Maze.Phase += 1;
        }
        randomValue = Random.Range(20, 31);
        PlayerMovement.Countdown = randomValue;
        AdIntermission = 1;
    }
}
