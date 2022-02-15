using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{

    public float ballSpeed = 10.0f;

    public TextMeshProUGUI player_1_Score;
    public TextMeshProUGUI player_2_Score;
    public TextMeshProUGUI winnerMSG;
    public AudioClip goalClip;

    private int leftCount = 0;
    private int rightCount = 0;
    private float x, z;
    
    private Rigidbody rBody;
    private AudioSource goal;
    private bool negPowHit;
    private bool posPowHit;
    private Vector3 previousVelocity;
    // Start is called before the first frame update
    void Start()
    {
        goal = GetComponent<AudioSource>();
        goal.clip = goalClip;
        AddStartingForce();
    }

    // Update is called once per frame
    void Update()
    {
        if (leftCount > rightCount)
        {
            player_1_Score.color = Color.green;
        }else if (rightCount == leftCount)
        {
            player_1_Score.color = Color.white;
        }
        else
        {
            player_1_Score.color = Color.red;
        }

        if (rightCount > leftCount)
        {
            player_2_Score.color = Color.green;
        }else if (rightCount == leftCount)
        {
            player_2_Score.color = Color.white;
        }
        else
        {
            player_2_Score.color = Color.red;
        }
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

    private void OnTriggerEnter(Collider other)
    {
        // need to reset the velocity of the ball after it hits a paddle
        
        if (other.gameObject.name == "NegativePowerUp")
        {
            negPowHit = true;
            previousVelocity = rBody.velocity;
        }else if(other.gameObject.name == "PositivePowerUp")
        {
            posPowHit = true;
            previousVelocity = rBody.velocity;
        }
        
        ballSpeed = 10.0f;
        z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        if (other.gameObject.name == "LeftGoal")
        {
            transform.localPosition = new Vector3(-0.5f, 0f, 0f);
            rightCount++;
            player_2_Score.text = $"{rightCount}";
            goal.Play();
            rBody.velocity = new Vector3(-1.0f * ballSpeed, 0f, z * ballSpeed);
        }else if (other.gameObject.name == "RightGoal")
        {
            transform.localPosition = new Vector3(0.5f, 0f, 0f);
            leftCount++;
            player_1_Score.text = $"{leftCount}";
            goal.Play();
            rBody.velocity = new Vector3(1.0f * ballSpeed, 0f, z * ballSpeed);
        }

        if (leftCount == 11)
        {
            winnerMSG.text = "Player 1 has won the game!";
            winnerMSG.color = Color.green;
            Destroy(gameObject);
        }else if (rightCount == 11)
        {
            winnerMSG.text = "Player 2 has won the game!";
            winnerMSG.color = Color.green;
            Destroy(gameObject);
        }
    }
}
