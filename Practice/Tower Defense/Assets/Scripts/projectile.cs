using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    private GameObject enemy;
    private Enemy kill_me;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("enemy_1(Clone)");
        kill_me = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
        try
        {
            enemy = GameObject.Find("enemy_1(Clone)");
            kill_me = enemy.GetComponent<Enemy>();
            transform.LookAt(enemy.transform);
            transform.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Force);
        }
        catch
        {
            // do nothing, just dont want the progrma to break if an error is caught
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_1")
        {
            kill_me.Damage();
            if (kill_me.getHealth() <= 0)
            {
                enemy = GameObject.Find("enemy_1(Clone)");
                kill_me = enemy.GetComponent<Enemy>();
                kill_me.AddToPurse();
            }
            Destroy(gameObject);
        }
    }
}
