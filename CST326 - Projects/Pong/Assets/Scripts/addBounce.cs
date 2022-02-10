using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addBounce : MonoBehaviour
{
    public float bounceStrength;

    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("kwekwkwwkewkwk");
        Vector3 normal = collision.GetContact(0).normal;
        rBody.AddForce((-normal * this.bounceStrength));
    }
}
