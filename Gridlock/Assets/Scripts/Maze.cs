using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze : MonoBehaviour
{
    public static int Phase;
    public int CurrentPhase;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPhase = Phase;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("Ads").isLoaded)
        {
            CurrentPhase = Phase;
        }
        if (CurrentPhase == 1)
        {
            CurrentPhase = 0;
            if (gameObject.tag == "P1U3 - P3D3")
            {
                transform.position = new Vector3(0, 15, 0);
            }
            if (gameObject.tag == "P1R3 - P3L3")
            {
                transform.position = new Vector3(15, 0, 0);
            }
            if (gameObject.tag == "P1D3 - P3U3")
            {
                transform.position = new Vector3(0, -15, 0);
            }
            if (gameObject.tag == "P1L3 - P3R3")
            {
                transform.position = new Vector3(-15, 0, 0);
            }
        }
        if (CurrentPhase == 2)
        {
            CurrentPhase = 0;
            if (gameObject.tag == "P2U3 - P4D3")
            {
                transform.position = new Vector3(0, 15, 0);
            }
            if (gameObject.tag == "P2R3 - P4L3")
            {
                transform.position = new Vector3(15, 0, 0);
            }
            if (gameObject.tag == "P2D3 - P4U3")
            {
                transform.position = new Vector3(0, -15, 0);
            }
            if (gameObject.tag == "P2L3 - P4R3")
            {
                transform.position = new Vector3(-15, 0, 0);
            }
        }
        if(CurrentPhase == 3)
        {
            CurrentPhase = 0;
            if (gameObject.tag == "P1U3 - P3D3")
            {
                transform.position = new Vector3(0, 0, 0);
            }
            if (gameObject.tag == "P1R3 - P3L3")
            {
                transform.position = new Vector3(0, 0, 0);
            }
            if (gameObject.tag == "P1D3 - P3U3")
            {
                transform.position = new Vector3(0, 0, 0);
            }
            if (gameObject.tag == "P1L3 - P3R3")
            {
                transform.position = new Vector3(0, 0, 0);
            }
        }
        if (CurrentPhase == 4)
        {
            CurrentPhase = 0;
            if (gameObject.tag == "P2U3 - P4D3")
            {
                transform.position = new Vector3(0, 0, 0);
            }
            if (gameObject.tag == "P2R3 - P4L3")
            {
                transform.position = new Vector3(0, 0, 0);
            }
            if (gameObject.tag == "P2D3 - P4U3")
            {
                transform.position = new Vector3(0, 0, 0);
            }
            if (gameObject.tag == "P2L3 - P4R3")
            {
                transform.position = new Vector3(0, 0 ,0);
            }
        }
    }
}
