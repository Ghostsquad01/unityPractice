using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotator : MonoBehaviour
{
    public float yawDegreesPerSecond = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform thisTransform = GetComponent<Transform>();
        thisTransform.
            Rotate(new Vector3(yawDegreesPerSecond * Time.deltaTime, 
                yawDegreesPerSecond * Time.deltaTime, yawDegreesPerSecond * Time.deltaTime));
    }
}
