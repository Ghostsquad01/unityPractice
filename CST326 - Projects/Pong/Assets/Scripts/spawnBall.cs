using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{
    public GameObject ballPrefab;

    private Rigidbody rBody;

    private float direction_x;

    private float direction_z;
    // Start is called before the first frame update
    void Start()
    {
        direction_x = Random.value < 0.5f ? -1.0f : 1.0f;
        direction_z = Random.value < 0.5f ? -1.0f : 1.0f;
        rBody = ballPrefab.GetComponent<Rigidbody>();
        
        Instantiate(ballPrefab);
        ballPrefab.transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ballPrefab.GetComponent<Rigidbody>().AddForce(new Vector3(direction_x*10f, 0f, direction_z*10), ForceMode.VelocityChange);
    }

}
