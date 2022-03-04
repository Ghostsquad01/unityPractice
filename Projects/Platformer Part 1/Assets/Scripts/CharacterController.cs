using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CharacterController : MonoBehaviour
{
    public float runForce;
    public float jumpForce;
    public float maxRunSpeed;

    public bool feetInContactWithGround;
    private Rigidbody body;
    private Collider collide;
    private GameObject gm;
    private UIManager UIman;
    private LevelParser parse;
    private Vector3 startPos = new Vector3(11f, 3f, 0f);

    private float check;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        UIman = gm.gameObject.GetComponent<UIManager>();
        collide= GetComponent<Collider>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        check = UIman.getTimer();
        if (check <= 0f)
        {
            Debug.Log("You lost, sorry!");
            parse.ReloadLevel();
            UIman.resetUI();
            transform.position = startPos;
        }
        float castDistance = collide.bounds.extents.y + 0.1f;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, castDistance);
        
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if (feetInContactWithGround && Input.GetKeyDown(KeyCode.Space))    
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coin(Clone)")
        {
            Destroy(other.gameObject);
            UIman.addCoin();
        }
        if (other.gameObject.name == "void(Clone)" || other.gameObject.name == "Water(Clone)")
        {
            Debug.Log("You died!");
            gm = GameObject.FindWithTag("Levelparser");
            parse = gm.gameObject.GetComponent<LevelParser>();
            parse.ReloadLevel();
            UIman.resetUI();
            transform.position = startPos;
            
        }

        
        if (other.gameObject.name == "topOfFlag(Clone)" || other.gameObject.name == "flagpole(Clone)")
        {
            Debug.Log("You win!");
            parse.nextLevel();
            UIman.resetUI();
            UIman.worldLevel.text = "WORLD\n  1-2";
            transform.position = startPos;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (this.transform.position.y - collision.collider.transform.position.y < 0)
        {
            if (collision.gameObject.name == "Brick(Clone)")
            {
                Destroy(collision.gameObject);
                UIman.addScore();
            }
        }

        
    }
}
