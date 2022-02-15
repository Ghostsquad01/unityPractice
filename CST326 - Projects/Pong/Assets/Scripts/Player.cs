using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public bool isLeftPaddle;
    public float speed;
    public Rigidbody rb;
    public AudioClip sound;
    private float topBounds = 7.25f;
    private float botBounds = -7.25f;
    private float movement;
    private Rigidbody rBody;
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
            // rb.AddForce(force, ForceMode.VelocityChange);
            // move freely (im sorry newton)
            rb.velocity = new Vector3(0f, 0f, movement * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Ball check = collision.gameObject.GetComponent<Ball>();

            check.ballSpeed += 2.0f;
            Debug.Log("Ball speed is now " + check.ballSpeed);
            
            rBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 normal = collision.GetContact(0).normal;
            rBody.AddForce((-normal * check.ballSpeed), ForceMode.VelocityChange);

            AudioSource contact = GetComponent<AudioSource>();
            contact.clip = sound;
            contact.Play();
        }
    }
}
