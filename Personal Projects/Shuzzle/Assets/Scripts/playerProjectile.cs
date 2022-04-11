using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.GetComponent<enemyAI>().TakeDamage(20);
            Debug.Log("Hit " + collision.gameObject.name + "enemy HP: " + collision.gameObject.GetComponent<enemyAI>().health);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        Destroy(gameObject);
    }
}
