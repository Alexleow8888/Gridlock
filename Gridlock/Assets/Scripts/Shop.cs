using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public Text PointsTxt;

    public Text HealthPriceTxt;
    public Text ArmourPriceTxt;
    public Text AmmoPriceTxt;

    public ShopValues ShopValues;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        PointsTxt.text = "Points - " + ShopValues.Points;
        HealthPriceTxt.text = "Price : " + ShopValues.HealthPrice;
        ArmourPriceTxt.text = "Price : " + ShopValues.ArmourPrice;
        AmmoPriceTxt.text = "Price : " + ShopValues.AmmoPrice;
        // Set the text to display the prices.
    }
    private void Update()
    {
        HealthPriceTxt.text = "Price : " + ShopValues.HealthPrice;
        ArmourPriceTxt.text = "Price : " + ShopValues.ArmourPrice;
        AmmoPriceTxt.text = "Price : " + ShopValues.AmmoPrice;
        // Updates the text every frame.
    }
    public void CloseButton()
    {
        audioManager.PlaySFX(audioManager.UI); // Plays the UI sound
        SceneManager.UnloadSceneAsync("ShopUI"); // Removes the ShopUI
        SceneManager.LoadScene("PerksUI", LoadSceneMode.Additive); // Loads the PerksUI scene over the top of the current scene.
    }
    public void ReplenishHealthButton()
    {
        if (ShopValues.Points >= ShopValues.HealthPrice)
        {
            audioManager.PlaySFX(audioManager.UI);
            ShopValues.Points -= ShopValues.HealthPrice;
            ShopValues.HealthPrice *= 1.1f; // Increases the price by 10% each time.
            ShopValues.HealthPrice = Mathf.Round(ShopValues.HealthPrice); // Rounds the price to a whole number.
            PlayerMovement.PlayerHealth = PlayerMovement.MaxPlayerHealth; // Restores the player's health.
            PointsTxt.text = "Points - " + ShopValues.Points;
        }
    }
    public void ReplenishArmourButton()
    {
        if (ShopValues.Points >= ShopValues.ArmourPrice)
        {
            audioManager.PlaySFX(audioManager.UI);
            ShopValues.Points -= ShopValues.ArmourPrice;
            ShopValues.ArmourPrice *= 1.1f; // Increases the price by 10% each time.
            ShopValues.ArmourPrice = Mathf.Round(ShopValues.ArmourPrice); // Rounds the price to a whole number.
            PlayerMovement.PlayerArmour = PlayerMovement.MaxPlayerArmour; // Restores the player's armour.
            PointsTxt.text = "Points - " + ShopValues.Points;
        }
    }
    public void ReplenishAmmoButton()
    {
        if (ShopValues.Points >= ShopValues.AmmoPrice)
        {
            audioManager.PlaySFX(audioManager.UI);
            ShopValues.Points -= ShopValues.AmmoPrice;
            ShopValues.AmmoPrice *= 1.1f; // Increases the price by 10% each time.
            ShopValues.AmmoPrice = Mathf.Round(ShopValues.AmmoPrice); // Rounds the price to a whole number.
            Gun.CurrentLoadedAmmo = Gun.MaxLoadedAmmo; // Restores the player's ammo.
            Gun.CurrentStoredAmmo = Gun.MaxStoredAmmo; // Restores the player's ammo.
            PointsTxt.text = "Points - " + ShopValues.Points;
        }
    }
}