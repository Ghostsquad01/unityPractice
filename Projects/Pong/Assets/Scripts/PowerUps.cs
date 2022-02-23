using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public bool isNegPowerUp;

    private Vector3 posPowerUpSpawn = new Vector3(0f, 0f, -6.0f);
    private Vector3 negPowerUpSpawn = new Vector3(0f, 0f, 6.0f);

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = (isNegPowerUp) ? -3 : 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(posPowerUpSpawn, negPowerUpSpawn, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            var currentPos = other.gameObject.transform.position.x;
            // coming from player 1
            if (currentPos < 0)
            {
                if (isNegPowerUp)
                {
                    other.gameObject.GetComponent<Rigidbody>().velocity = other.gameObject.GetComponent<Rigidbody>().velocity / 1.25f;
                }
                else
                {
                    other.gameObject.GetComponent<Rigidbody>().velocity = other.gameObject.GetComponent<Rigidbody>().velocity * 1.75f;
                }
                
            }else if (currentPos > 0) // coming from player 2
            {
                if (isNegPowerUp)
                {
                    other.gameObject.GetComponent<Rigidbody>().velocity = other.gameObject.GetComponent<Rigidbody>().velocity / 1.25f;
                }
                else
                {
                    other.gameObject.GetComponent<Rigidbody>().velocity = other.gameObject.GetComponent<Rigidbody>().velocity * 1.75f;
                }
            }
        }
        // Debug.Log(gameObject.name + " has been entered by " + other.gameObject.name + " from " + other.gameObject.transform.position.x);
    }
}
