using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_fire : MonoBehaviour
{
    public GameObject bullet;

    public Transform shottingOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(0, 10000);
        if (x > 9990)
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            // Debug.Log("Bang!");
            
            Destroy(shot, 3f);
        }
    }
}
