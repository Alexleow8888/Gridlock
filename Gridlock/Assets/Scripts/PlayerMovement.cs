using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static int PlayerHealth;
    public static int MaxPlayerHealth ;

    public static int PlayerArmour;
    public static int MaxPlayerArmour;

    [SerializeField] FloatingHealthBar PlayerHealthBar;
    [SerializeField] FloatingHealthBar PlayerArmourBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        IsRunning = 1;
        NumberofSeconds = 5;

        speed = 10f;
        PerksValues.PerkPoints = 0;
        PerksValues.IncreasedSpeedLevel = 0;
        PerksValues.IncreasedDamageLevel = 0;
        PerksValues.IncreasedHealthLevel = 0;
        PerksValues.IncreasedAmmoLevel = 0;
        PlayerHealth = 100;
        MaxPlayerHealth = 100;

        PlayerArmour = 50;
        MaxPlayerArmour = 50;

        ShopValues.Points = 0;


        PlayerHealthBar.UpdateHealthBar(PlayerHealth, MaxPlayerHealth);
        PlayerArmourBar.UpdateHealthBar(PlayerArmour, MaxPlayerArmour);
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

        if (PlayerHealth <= 0)
        {
            SceneManager.LoadScene("DeathMenu");

        }

        PlayerHealthBar.UpdateHealthBar(PlayerHealth, MaxPlayerHealth);
        PlayerArmourBar.UpdateHealthBar(PlayerArmour, MaxPlayerArmour);
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
}
