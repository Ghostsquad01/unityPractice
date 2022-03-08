using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private float hit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (hit == 2)
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }else if (col.gameObject.name == "Bullet(Clone)" || col.gameObject.name == "Enemy_Bullet(Clone)")
        {
            transform.localScale =
                new Vector3(transform.localScale.x / 2, transform.localScale.y, transform.localScale.z);
            Destroy(col.gameObject);
            hit++;
        }
    }
}
