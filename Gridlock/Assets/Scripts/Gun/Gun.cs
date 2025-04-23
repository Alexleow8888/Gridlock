using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Camera MainCam;
    private Vector3 mousePos;

    public GameObject Bullet;
    public Transform BulletTransform;
    public bool CanFire;
    private float Timer;
    public float TimeBetweenFiring;

    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!CanFire)
        {
            Timer += Time.deltaTime;
            if(Timer > TimeBetweenFiring)
            {
                CanFire = true;
                Timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && CanFire)
        {
            CanFire = false;
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity);

        }
    }
}
