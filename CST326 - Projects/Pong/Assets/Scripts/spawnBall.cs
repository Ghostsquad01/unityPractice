using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{
    public GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ballPrefab);
        ballPrefab.transform.localPosition = new Vector3(24, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
