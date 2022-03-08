using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    private bool hitLeftBounds = true;
    private bool hitRightBounds;
    private float speed = 2;
    private UI_Manager ui;
    private GameObject gm;

    void Start()
    {
        gm = GameObject.FindWithTag("UI_Manager");
        ui = gm.GetComponent<UI_Manager>();
    }

    void Update()
    {
        if (ui.enemiesLeft() == 12)
        {
            speed = 4;
        }else if (ui.enemiesLeft() == 8)
        {
            speed = 6;
        }else if (ui.enemiesLeft() == 4)
        {
            speed = 10;
        }
        if (transform.position.x >= 20.95)
        {
            hitRightBounds = true;
            hitLeftBounds = false;
            transform.position += new Vector3(0f, -1.5f, 0f);
        }
        else if(transform.position.x <= -20.95)
        {
            hitLeftBounds = true;
            hitRightBounds = false;
            transform.position += new Vector3(0f, -1.5f, 0f);
        }
        if (hitLeftBounds)
        {
            transform.position = new Vector3( transform.position.x+1.5f*Time.deltaTime*speed, transform.position.y, 0f);
        }else if (hitRightBounds) // move the enemies to the left
        {
            transform.position = new Vector3( transform.position.x+-1.5f*Time.deltaTime*speed, transform.position.y, 0f);
        }
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("collided with " + collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ui.enemyDestroyed(gameObject.tag);
        }

        if (collision.gameObject.tag == "Barricade")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("Player was not able to defend against the Space Invaders!");
        }
    }
}
