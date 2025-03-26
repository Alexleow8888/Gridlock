using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D player;

    private float Horizontal;
    private float Vertical;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        // Detects for the inputs A/D or Left/Right arrow keys.
        Vertical = Input.GetAxisRaw("Vertical");
        // Detects for the inputs W/S or Up/Down arrow keys.

        if (Input.GetKeyDown("e"))   
        {
            speed = speed + 1f;
        }
        if (Input.GetKeyDown("q"))
        {
            speed = speed - 1f;
        }
    }
    private void FixedUpdate()
    {
        player.velocity = new Vector2(Horizontal, Vertical).normalized * speed;
    }
}
