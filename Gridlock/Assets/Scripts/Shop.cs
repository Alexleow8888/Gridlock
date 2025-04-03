using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public Text PointsTxt;

    public ShopValues ShopValues;

    void Start()
    {
        PointsTxt.text = "Points - " + ShopValues.Points;
    }
    public void CloseButton()
    {
        SceneManager.UnloadSceneAsync("ShopUI");
        SceneManager.LoadScene("PerksUI", LoadSceneMode.Additive);
    }
}