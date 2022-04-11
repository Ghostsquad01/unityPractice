using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    [Header("Health")] 
    public int health;
    public float damagedTimer;

    [Header("References")] 
    public playerCamera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void takeDamage()
    {
        health -= 20;
        if (health == 0)
        {
            Debug.Log("Player has died");
        }
        else
        {
            Debug.Log("HP: " + health);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Player has been hit: " + health);
            takeDamage();
            Destroy(collision.gameObject);
        }
    }
}
