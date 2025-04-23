using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewPerksData/PerkData")]

public class PerksValues : ScriptableObject
{
    public int SpeedLevel;

    public int PerkPoints;
   
    // Just stores the values that saves across scenes.
}