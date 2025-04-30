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

    void Start()
    {
        PointsTxt.text = "Points - " + ShopValues.Points;
        HealthPriceTxt.text = "Price : " + ShopValues.HealthPrice;
        ArmourPriceTxt.text = "Price : " + ShopValues.ArmourPrice;
        AmmoPriceTxt.text = "Price : " + ShopValues.AmmoPrice;
    }
    private void Update()
    {
        HealthPriceTxt.text = "Price : " + ShopValues.HealthPrice;
        ArmourPriceTxt.text = "Price : " + ShopValues.ArmourPrice;
        AmmoPriceTxt.text = "Price : " + ShopValues.AmmoPrice;
    }
    public void CloseButton()
    {
        SceneManager.UnloadSceneAsync("ShopUI");
        SceneManager.LoadScene("PerksUI", LoadSceneMode.Additive);
    }
    public void ReplenishHealthButton()
    {
        if (ShopValues.Points >= ShopValues.HealthPrice)
        {
            ShopValues.Points -= ShopValues.HealthPrice;
            ShopValues.HealthPrice *= 1.1f;
            ShopValues.HealthPrice = Mathf.Round(ShopValues.HealthPrice);
            PlayerMovement.PlayerHealth = PlayerMovement.MaxPlayerHealth;
        }
    }
    public void ReplenishArmourButton()
    {
        if (ShopValues.Points >= ShopValues.ArmourPrice)
        {
            ShopValues.Points -= ShopValues.ArmourPrice;
            ShopValues.ArmourPrice *= 1.1f;
            ShopValues.ArmourPrice = Mathf.Round(ShopValues.ArmourPrice);
            PlayerMovement.PlayerArmour = PlayerMovement.MaxPlayerArmour;
        }
    }
    public void ReplenishAmmoButton()
    {
        if (ShopValues.Points >= ShopValues.AmmoPrice)
        {
            ShopValues.Points -= ShopValues.AmmoPrice;
            ShopValues.AmmoPrice *= 1.1f;
            ShopValues.AmmoPrice = Mathf.Round(ShopValues.AmmoPrice);
            Gun.CurrentLoadedAmmo = Gun.MaxLoadedAmmo;
            Gun.CurrentStoredAmmo = Gun.MaxStoredAmmo;
        }
    }
}