using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class newBallMV : MonoBehaviour
{

    public float ballSpeed = 10.0f;

    private Rigidbody rBody;

    private float x, z;
    // Start is called before the first frame update
    void Start()
    {
        AddStartingForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddStartingForce()
    {
        if (transform.position.x == 0.5f)
        {
            x = 1.0f;
        }else if (transform.position.x == -0.5f)
        {
            x = -1.0f;
        }else if (transform.position.x == 0f)
        {
            x = Random.value < 0.5f ? -1.0f : 1.0f;
        }
        
        z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        rBody = GetComponent<Rigidbody>();

        // rBody.AddForce(new Vector3(x*ballSpeed, 0f, z*ballSpeed), ForceMode.VelocityChange);
        rBody.velocity = new Vector3(x * ballSpeed, 0f, z * ballSpeed);
    }
    
}
