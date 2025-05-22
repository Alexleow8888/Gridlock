using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "NewShopData/ShopData")]

public class ShopValues : ScriptableObject
{
    public float Points;

    public float HealthPrice;
    public float ArmourPrice;
    public float AmmoPrice;
}