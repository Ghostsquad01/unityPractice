using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;


public class moveBall : MonoBehaviour
{
    // right side z: up-pos/down-neg
    // left side z: up-pos/down-neg
    // right side x: left-neg
    // left side x: right-pos
    public float ballSpeed = 10.0f;

    private float bounceAngle;
    private float vx, vz;
    private float maxAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.localPosition.x > -0.006729417f)
        {
            bounceAngle = RandomBounceAngle();
            vx = ballSpeed * -Mathf.Cos(bounceAngle);
            vz = ballSpeed * Mathf.Sin(bounceAngle);
        }else if (transform.localPosition.x < -0.006729417f)
        {
            bounceAngle = RandomBounceAngle();
            vx = ballSpeed * Mathf.Cos(bounceAngle);
            vz = ballSpeed * Mathf.Sin(bounceAngle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(vx * Time.deltaTime, 0f, vz * Time.deltaTime);
    }

    // somewhere in my collision there is a bug
    // ball will slow down massively, if it hits a paddle at a certain z-degrees
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LeftPaddle")
        {
            nextBounceAngle(collision);
            ballSpeed += 2.0f;
            vx = ballSpeed * Mathf.Cos(bounceAngle);
            Debug.Log("Ball speed is now " + ballSpeed);
        }else if (collision.gameObject.name == "RightPaddle")
        {
            nextBounceAngle(collision);
            ballSpeed += 2.0f;
            vx = ballSpeed * -Mathf.Cos(bounceAngle);
            Debug.Log("Ball speed is now " + ballSpeed);
        }else if (collision.gameObject.name == "TopWall")
        {
            nextBounceAngle(collision);
            vz = ballSpeed * -Mathf.Sin(bounceAngle);
        }else if (collision.gameObject.name == "BottomWall")
        {
            nextBounceAngle(collision);
            vz = ballSpeed * Mathf.Sin(bounceAngle);
        }
    }

    // to get our first random entry direction
    float RandomBounceAngle() 
    {
        float minRad = Random.Range(-10.25f, 10.25f) * Mathf.PI / 180;
        float maxRad = Random.Range(-25.25f, 25.25f) * Mathf.PI / 180;

        return Random.Range(minRad, maxRad);
    }

    // helper function for readability
    // call this function whenever something collides
    // it will change the bounce angle depending on where it hit on the collision
    void nextBounceAngle(Collision collision)
    {
        // i believe this is where my slowdown-bug happens
        float relativeIntersectZ = collision.transform.position.z - transform.position.z;
        float normalizedRelativeIntersection = relativeIntersectZ / (collision.transform.position.z/2);
        bounceAngle = normalizedRelativeIntersection * (maxAngle * Mathf.Deg2Rad);
    }
}

