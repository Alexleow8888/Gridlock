using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text SpeedLeveltxt;
    public Text SpeedPricetxt;


    public ShopValues ShopValues;
    void Start()
    {


    }
    void Update()
    {
        SpeedLeveltxt.text = "Level - " + ShopValues.SpeedLevel + "/5";
        SpeedPricetxt.text = "Price - " + ShopValues.SpeedPrice;
    }
    public void IncreaseSpeed()
    {
        if (ShopValues.SpeedLevel != 5)
        {
            PlayerMovement.speed += 2f;
            ShopValues.SpeedLevel += 1;
            ShopValues.SpeedPrice *= 1.5f;
            ShopValues.SpeedPrice = Mathf.Round(ShopValues.SpeedPrice);
            SpeedLeveltxt.text = "Level - " + ShopValues.SpeedLevel + "/5";
            SpeedPricetxt.text = "Price - " + ShopValues.SpeedPrice;
        }
        
    }
}