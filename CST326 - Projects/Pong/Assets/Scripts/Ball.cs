using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rBody;
    
    private float vx;
    private float vz;
    private float bounceAngle;
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
        Vector3 intersect = transform.position - collision.transform.position;
        float relativeIntersection = intersect.x / (collision.transform.position.x / 2);
        Debug.Log(relativeIntersection + " intersect");
        bounceAngle = relativeIntersection * (45f * Mathf.Deg2Rad);

        if (collision.transform.name == "RightPaddle")
        {
            vx = -Mathf.Cos(bounceAngle);
            Debug.Log("right");
        }else if (collision.transform.name == "LeftPaddle")
        {
            
            Debug.Log("left ");
            vx = Mathf.Cos(bounceAngle);
        }else if (collision.transform.name == "BottomWall")
        {
            vz = Mathf.Sin(bounceAngle);
            if (Single.IsNaN(vz))
            {
                vz = 1;
            }
            Debug.Log("bottom " + vz);
        }else if (collision.transform.name == "TopWall")
        {
            vz = -Mathf.Sin(bounceAngle);
            if (Single.IsNaN(vz))
            {
                Debug.Log("top " + vz + " " + bounceAngle);
                vz = -1;
            }
            
        }
        rBody.AddForce(new Vector3(vx*speed, 0f, vz*speed), ForceMode.VelocityChange);
    }
    
    float RandomBounceAngle() 
    {
        float minRad = Random.Range(-10.25f, 10.25f) * Mathf.PI / 180;
        float maxRad = Random.Range(-25.25f, 25.25f) * Mathf.PI / 180;

        return Random.Range(minRad, maxRad);
    }
}
