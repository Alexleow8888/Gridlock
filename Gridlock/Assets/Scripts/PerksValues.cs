using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewPerksData/PerkData")]

public class PerksValues : ScriptableObject
{
    public int PerkPoints;

    public int IncreasedSpeedLevel;
    public int IncreasedDamageLevel;
    public int IncreasedHealthLevel;
    public int IncreasedAmmoLevel;
   
    // Just stores the values that saves across scenes.
}