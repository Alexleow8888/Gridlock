using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed = 8f;
    // The Enemy's speed

    private GameObject player;
    // Reference for the player

    private int CanSeePlayer = 0;
    // Stores whether the Ray is colliding with the player


    public float EnemyHealth = 30f;
    public float MaxEnemyHealth = 30f;

    [SerializeField] FloatingHealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Finds the object that has the Player tag assigning it to the player variable
        healthBar = GetComponentInChildren<FloatingHealthBar>();

        healthBar.UpdateHealthBar(EnemyHealth, MaxEnemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Debug.Log("Can see the player");
            // If the enemy can see the player then move in that direction
        }
        if (CanSeePlayer == 0)
        {
            Debug.Log("No player detected");
        }

        if(EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);
        // Casts a ray towards the player

        if (ray.collider != null)
            // Detects if the ray hits anything
        {
            if (ray.collider.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, direction * ray.distance, Color.green);
                CanSeePlayer = 1;
                // If the ray hits the player then sets the CanSeePlayer variable to a true state, draws a green line for debugging
            }
            else
            {
                Debug.DrawRay(transform.position, direction * ray.distance, Color.red);
                CanSeePlayer = 0;
                // If the ray doesn't hit the player then sets the CanSeePlayer variable to a false state, draws a red line for debugging
            }
        }
        else
        {
            CanSeePlayer = 0;
            // If the ray doesn't hit anything then sets the CanSeePlayer to a false state.
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            EnemyHealth -= 5f;
            healthBar.UpdateHealthBar(EnemyHealth, MaxEnemyHealth);
        }
    }
}