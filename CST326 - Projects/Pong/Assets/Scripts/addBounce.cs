using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addBounce : MonoBehaviour
{
    private Rigidbody rBody;
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
        if (collision.gameObject.name == "LeftPaddle" || collision.gameObject.name == "RightPaddle")
        {
            
        }
        else
        {
            newBallMV check = collision.gameObject.GetComponent<newBallMV>();
            Vector3 normal = collision.GetContact(0).normal;
        
            Rigidbody rBody = collision.gameObject.GetComponent<Rigidbody>();
            rBody.AddForce((-normal * check.ballSpeed), ForceMode.VelocityChange);
        }
    }
}
