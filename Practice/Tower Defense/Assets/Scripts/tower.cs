using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tower : MonoBehaviour
{
    [Header("Attack")]
    public float attackRange;
    public float timeBetweenAttacks;
    public GameObject projectile;
    private bool alreadyAttacked;
    private bool enemyInAttackRange;
    private LayerMask whatIsEnemy;

    [Header("References")]
    public Transform enemy;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.Find("enemy_1(Clone)").transform;
        enemyInAttackRange = Physics.CheckSphere(transform.position, 3000f, whatIsEnemy);
        // Instantiate(projectile).GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
        transform.LookAt(enemy);

        Debug.Log(enemyInAttackRange);
        if(enemyInAttackRange)
            Debug.Log("enemy has entered attack range");
    }

    private void shootProjectile()
    {
        transform.LookAt(enemy);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }

    private void resetAttack()
    {
        alreadyAttacked = false;
    }
}
