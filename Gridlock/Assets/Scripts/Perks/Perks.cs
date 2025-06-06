using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Perks : MonoBehaviour
{
    public Text SpeedLevelTxt;
    public Text DamageLevelTxt;
    public Text HealthLevelTxt;
    public Text AmmoLevelTxt;

    public Text PerkPointsTxt;

    public PerksValues PerksValues;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        SpeedLevelTxt.text = "Level : " + PerksValues.IncreasedSpeedLevel + "/5";
        DamageLevelTxt.text = "Level : " + PerksValues.IncreasedDamageLevel + "/5";
        HealthLevelTxt.text = "Level : " + PerksValues.IncreasedHealthLevel + "/5";
        AmmoLevelTxt.text = "Level : " + PerksValues.IncreasedAmmoLevel + "/5";
        PerkPointsTxt.text = "Perk Points : " + PerksValues.PerkPoints;
    }
    void Update()
    {
        // Constantly updating the price and level texts to the most recent version.
    }
    public void IncreaseSpeed()
    {
        if (PerksValues.IncreasedSpeedLevel != 5 && PerksValues.PerkPoints != 0) // Limits how manny of the upgrade can be purchased.
        {
            audioManager.PlaySFX(audioManager.UI);
            PerksValues.PerkPoints -= 1;
            PlayerMovement.speed += 2f; // Increases the speed
            PerksValues.IncreasedSpeedLevel += 1; // Increases the level
            SpeedLevelTxt.text = "Level : " + PerksValues.IncreasedSpeedLevel + "/5";
            PerkPointsTxt.text = "Perk Points : " + PerksValues.PerkPoints;
        }

    }
    public void IncreaseDamageButton()
    {
        if (PerksValues.IncreasedDamageLevel != 5 && PerksValues.PerkPoints != 0)
        {
            audioManager.PlaySFX(audioManager.UI);
            PerksValues.PerkPoints -= 1;
            EnemyMovement.Damage += 1; // Increases the damage
            PerksValues.IncreasedDamageLevel += 1; // Increases the level
            DamageLevelTxt.text = "Level : " + PerksValues.IncreasedDamageLevel + "/5";
            PerkPointsTxt.text = "Perk Points : " + PerksValues.PerkPoints;
        }
    }
    public void IncreaseTotalHealthButton()
    {
        if (PerksValues.IncreasedHealthLevel != 5 && PerksValues.PerkPoints != 0)
        {
            audioManager.PlaySFX(audioManager.UI);
            PerksValues.PerkPoints -= 1;
            PlayerMovement.MaxPlayerHealth += 10; // Increases the total health
            PerksValues.IncreasedHealthLevel += 1; // Increases the level
            HealthLevelTxt.text = "Level : " + PerksValues.IncreasedHealthLevel + "/5";
            PerkPointsTxt.text = "Perk Points : " + PerksValues.PerkPoints;
        }
    }
    public void IncreaseTotalAmmoButton()
    {
        if (PerksValues.IncreasedAmmoLevel != 5 && PerksValues.PerkPoints != 0)
        {
            audioManager.PlaySFX(audioManager.UI);
            PerksValues.PerkPoints -= 1;
            Gun.MaxStoredAmmo += 6; // Increases the total ammo
            PerksValues.IncreasedAmmoLevel += 1; // Increases the level
            AmmoLevelTxt.text = "Level : " + PerksValues.IncreasedAmmoLevel + "/5";
            PerkPointsTxt.text = "Perk Points : " + PerksValues.PerkPoints;
        }
    }
    public void CloseButton()
    {
        audioManager.PlaySFX(audioManager.UI);
        SceneManager.UnloadSceneAsync("PerksUI");
        SceneManager.UnloadSceneAsync("Ads");
        Time.timeScale = 1;
    }
}