using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 MousePos;
    private Camera MainCam;
    private Rigidbody2D rb;
    public float force;

    [Range(1, 10)] // lifetime

    [SerializeField] private float lifeTime = 3f;

    public float BulletDamage;


    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = MousePos - transform.position;
        Vector3 rotation = transform.position - MousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);


        Destroy(gameObject, lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyProjectile();
            //Destroy(other.gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P1R3 - P3L3"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P1D3 - P3U3"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P1L3 - P3R3"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P1U3 - P3D3"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P2R3 - P4L3"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P2D3 - P4U3"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P2L3 - P4R3"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("P2U3 - P4D3"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);

    }
}
