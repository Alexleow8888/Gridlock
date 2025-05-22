using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static float speed;

    private Rigidbody2D player;

    private float Horizontal;
    private float Vertical;

    public PerksValues PerksValues;
    public ShopValues ShopValues;

    private int IsRunning;
    private int NumberofSeconds;
    public static int Countdown;
    private int CountdownRunning;
    public Text CountdownTxt;

    public static int PlayerHealth;
    public static int MaxPlayerHealth ;

    public static int PlayerArmour;
    public static int MaxPlayerArmour;

    [SerializeField] FloatingHealthBar PlayerHealthBar;
    [SerializeField] FloatingHealthBar PlayerArmourBar;

    private int EndingRequirements;
    private int StartTutorial;
    private int EndTutorial;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        IsRunning = 1;
        NumberofSeconds = 3;

        CountdownRunning = 1;

        speed = 10f;
        PerksValues.PerkPoints = 0;
        PerksValues.IncreasedSpeedLevel = 0;
        PerksValues.IncreasedDamageLevel = 0;
        PerksValues.IncreasedHealthLevel = 0;
        PerksValues.IncreasedAmmoLevel = 0;
        // Resets the Perk levels.
        PlayerHealth = 100;
        MaxPlayerHealth = 100;

        PlayerArmour = 50;
        MaxPlayerArmour = 50;

        ShopValues.Points = 0;

        Maze.Phase = 0;

        PlayerHealthBar.UpdateHealthBar(PlayerHealth, MaxPlayerHealth);
        PlayerArmourBar.UpdateHealthBar(PlayerArmour, MaxPlayerArmour);

        StartTutorial = 1;
        EndTutorial = 0;

        CountdownTxt.text = "Next Ad Break : " + Countdown + "s";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Speed " + PlayerMovement.speed + " | Damage " + EnemyMovement.Damage + " | Health " + PlayerMovement.MaxPlayerHealth + " | Ammo " + Gun.MaxStoredAmmo);
        Horizontal = Input.GetAxisRaw("Horizontal");
        // Detects for the inputs A/D or Left/Right arrow keys.
        Vertical = Input.GetAxisRaw("Vertical");
        // Detects for the inputs W/S or Up/Down arrow keys.


        if (Input.GetKeyDown("escape"))
        {
            if (!SceneManager.GetSceneByName("PauseMenu").isLoaded && !SceneManager.GetSceneByName("OptionsMenu").isLoaded && !SceneManager.GetSceneByName("PerksUI").isLoaded && !SceneManager.GetSceneByName("ShopUI").isLoaded)
            {
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
                Time.timeScale = 0;
            }

        }
        //Debug.Log("Player Speed = " + speed + ". Points = " + ShopValues.Points);

        if (IsRunning == 1)
        {
            StartCoroutine(timer());
        }
        if (CountdownRunning == 1)
        {
            StartCoroutine(CountdownTimer());
        }
        if (PlayerHealth <= 0)
        {
            audioManager.PlaySFX(audioManager.Death);
            SceneManager.LoadScene("DeathMenu");

        }
        // Triggers Tutorials
        if (StartTutorial == 1)
        {
            StartCoroutine(Tutorial1());
        }
        if (EndTutorial == 1)
        {
            StartCoroutine(Tutorial2());
        }


        PlayerHealthBar.UpdateHealthBar(PlayerHealth, MaxPlayerHealth);
        PlayerArmourBar.UpdateHealthBar(PlayerArmour, MaxPlayerArmour);
    }
    private void FixedUpdate()
    {
        player.velocity = new Vector2(Horizontal, Vertical).normalized * speed;
    }
    public IEnumerator timer()
    // Coroutine that adds points every few seconds.    
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        ShopValues.Points += 1;
        IsRunning = 1;
    }
    public IEnumerator CountdownTimer()
    {
        // Coroutine that displays how long until the next ad break.
        CountdownRunning = 0;
        Countdown -= 1;
        yield return new WaitForSeconds(1);
        CountdownTxt.text = "Next Ad Break : " + Countdown + "s";
        if (Countdown != 0)
        {
            CountdownRunning = 1;
        }
    }
    public IEnumerator Tutorial1()
    {
        StartTutorial = 0;
        SceneManager.LoadScene("StartTutorial", LoadSceneMode.Additive);
        yield return new WaitForSeconds(5);
        SceneManager.UnloadSceneAsync("StartTutorial");
    }
    public IEnumerator Tutorial2()
    {
        EndTutorial = 0;
        SceneManager.LoadScene("EndTutorial", LoadSceneMode.Additive);
        yield return new WaitForSeconds(5);
        SceneManager.UnloadSceneAsync("EndTutorial");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (PlayerArmour > 0)
            {
                PlayerArmour -= 1;
                PlayerArmourBar.UpdateHealthBar(PlayerArmour, MaxPlayerArmour);
            }
            if (PlayerArmour == 0)
            {
                PlayerHealth -= 1;
                PlayerHealthBar.UpdateHealthBar(PlayerHealth, MaxPlayerHealth);

            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Artefact")
        {
            EndingRequirements = 1;
            collision.gameObject.SetActive(false);
            EndTutorial = 1;
        }
        if (collision.gameObject.tag == "Ending")
        {
            if (EndingRequirements == 1)
            {
                audioManager.PlaySFX(audioManager.Winning);
                SceneManager.LoadScene("FinishMenu");
            }
        }
    }
}
