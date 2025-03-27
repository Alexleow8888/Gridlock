using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public void SpeedButton()
    {
        IncreaseSpeed();
    }
    public void IncreaseSpeed()
    {
        PlayerMovement.speed = PlayerMovement.speed + 10f;
    }
}