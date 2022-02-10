using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class newBallMV : MonoBehaviour
{

    public float ballSpeed = 10;

    private Rigidbody rBody;
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
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        rBody = GetComponent<Rigidbody>();

        rBody.AddForce(new Vector3(x*ballSpeed, 0f, z*ballSpeed), ForceMode.Impulse);

    }
}
