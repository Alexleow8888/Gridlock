using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perks : MonoBehaviour
{
    public Text SpeedLeveltxt;

    public Text PerkPointstxt;

    public PerksValues PerksValues;

    void Start()
    {
        SpeedLeveltxt.text = "Level - " + PerksValues.SpeedLevel + "/5";
        PerkPointstxt.text = "Perk Points - " + PerksValues.PerkPoints;
    }
    void Update()
    {

        // Constantly updating the price and level texts to the most recent version.
    }
    public void IncreaseSpeed()
    {
        if (PerksValues.SpeedLevel != 5 && PerksValues.PerkPoints != 0) // Limits how manny of the upgrade can be purchased.
        {
            PerksValues.PerkPoints -= 1;
            PlayerMovement.speed += 2f; // Increases the speed
            PerksValues.SpeedLevel += 1; // Increases the level
            SpeedLeveltxt.text = "Level - " + PerksValues.SpeedLevel + "/5";
            PerkPointstxt.text = "Perk Points - " + PerksValues.PerkPoints;
        }

    }
}