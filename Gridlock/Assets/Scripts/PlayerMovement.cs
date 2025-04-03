using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 10f;

    private Rigidbody2D player;

    private float Horizontal;
    private float Vertical;

    public PerksValues PerksValues;
    public ShopValues ShopValues;

    private int IsRunning = 1;
    private int NumberofSeconds = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        PerksValues.PerkPoints = 0;
        PerksValues.SpeedLevel = 0;

        ShopValues.Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        // Detects for the inputs A/D or Left/Right arrow keys.
        Vertical = Input.GetAxisRaw("Vertical");
        // Detects for the inputs W/S or Up/Down arrow keys.

        if (Input.GetKeyDown("e"))   
        {
            speed = speed + 1f;
        }
        if (Input.GetKeyDown("q"))
        {
            speed = speed - 1f;
        }
        if (Input.GetKeyDown("n") && !SceneManager.GetSceneByName("ShopUI").isLoaded)
        {
            SceneManager.LoadScene("ShopUI", LoadSceneMode.Additive);
            Time.timeScale = 0;
            PerksValues.PerkPoints += 1;
        }
        if (Input.GetKeyDown("m") && SceneManager.GetSceneByName("PerksUI").isLoaded)
        {
            SceneManager.UnloadSceneAsync("PerksUI");
            Time.timeScale = 1;
            
        }
        Debug.Log("Player Speed = " + speed + ". Points = " + ShopValues.Points);

        if (IsRunning == 1)
        {
            StartCoroutine(timer());
        }
    }
    private void FixedUpdate()
    {
        player.velocity = new Vector2(Horizontal, Vertical).normalized * speed;
    }
    public IEnumerator timer()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        ShopValues.Points += 1;
        IsRunning = 1;
    }
}
