using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public bool isLeftPaddle;
    public float speed;
    public Rigidbody rb;
    private float topBounds = 7.25f;
    private float botBounds = -7.25f;
    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveUpOrDown();
    }

    void MoveUpOrDown()
    {
        if (isLeftPaddle)
        {
            // left paddle - using the Input Manager
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            // right paddle - using the Input Manager 
            movement = Input.GetAxisRaw("Vertical2");
        }

        Vector3 force = Vector3.forward * movement * speed * Time.deltaTime;
        if (transform.position.z >= topBounds)
        {
            // stop at a collision
            rb.AddForce(force, ForceMode.VelocityChange);
        }else if (transform.position.z <= botBounds)
        {
            rb.AddForce(force, ForceMode.VelocityChange);
        }
        else
        {
            // move freely (im sorry newton)
            rb.velocity = new Vector3(rb.velocity.x, 0f, movement * speed);
        }
    }
    
}
