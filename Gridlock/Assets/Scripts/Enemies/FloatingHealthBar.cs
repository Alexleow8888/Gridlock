using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FloatingHealthBar : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Health " + PlayerMovement.PlayerHealth + "| Armour " + PlayerMovement.PlayerArmour);
    }
}
