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
    // Start is called before the first frame update
    void Start()
    {
        collide= GetComponent<Collider>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float castDistance = collide.bounds.extents.y + 0.1f;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, castDistance);
        
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if (feetInContactWithGround && Input.GetKeyDown(KeyCode.Space))    
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }else if (body.velocity.y > 0f && Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce*1.30f, ForceMode.Force);
        }

        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        if (axis < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
    }
}
