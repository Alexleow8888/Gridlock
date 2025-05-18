using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private Camera MainCam;
    private Vector3 mousePos;

    public GameObject Bullet;
    public Transform BulletTransform;
    public bool CanFire;
    private float Timer;
    public float TimeBetweenFiring;

    public static int CurrentLoadedAmmo;
    public static int CurrentStoredAmmo;
    public static int MaxLoadedAmmo;
    public static int MaxStoredAmmo;
    public static int AmmoDifference;
    public Text AmmoTxt;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        

        CurrentLoadedAmmo = 6;
        CurrentStoredAmmo = 30;
        MaxLoadedAmmo = 6;
        MaxStoredAmmo = 30;
        AmmoTxt.text = "Ammo : " + CurrentLoadedAmmo + " / " + CurrentStoredAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        if(!SceneManager.GetSceneByName("ShopUI").isLoaded && !SceneManager.GetSceneByName("PerksUI").isLoaded)
        {
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        if(SceneManager.GetSceneByName("ShopUI").isLoaded || SceneManager.GetSceneByName("PerksUI").isLoaded || SceneManager.GetSceneByName("PauseMenu").isLoaded)
        {
            CanFire = false;
        }


        if (CurrentLoadedAmmo > 0 || CurrentStoredAmmo > 0)
        {
            if (!CanFire)
            {
                Timer += Time.deltaTime;
                if(Timer > TimeBetweenFiring)
                {
                    CanFire = true;
                    Timer = 0;
                }
            }
        }


        if (Input.GetMouseButton(0) && CanFire == true && CurrentLoadedAmmo > 0)
        {
            CanFire = false;
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.GunShot);
            CurrentLoadedAmmo -= 1;
            AmmoTxt.text = "Ammo : " + CurrentLoadedAmmo + " / " + CurrentStoredAmmo;
        }


        if (Input.GetKeyDown("r") && CurrentStoredAmmo > 0)
        {
            AmmoDifference = MaxLoadedAmmo - CurrentLoadedAmmo;
            audioManager.PlaySFX(audioManager.GunReload);
            if (CurrentStoredAmmo >= AmmoDifference)
            {
                // If we have enough ammo in storage to fill the magazine
                CurrentLoadedAmmo += AmmoDifference;
                CurrentStoredAmmo -= AmmoDifference;
            }
            else
            {
                // If we don't have enough ammo, load whatever is left
                CurrentLoadedAmmo += CurrentStoredAmmo;
                CurrentStoredAmmo = 0;  // All stored ammo used up
            }
            AmmoDifference = MaxLoadedAmmo - CurrentLoadedAmmo;
            AmmoTxt.text = "Ammo : " + CurrentLoadedAmmo + " / " + CurrentStoredAmmo;

        }
        
        AmmoTxt.text = "Ammo : " + CurrentLoadedAmmo + " / " + CurrentStoredAmmo;


    }
}
