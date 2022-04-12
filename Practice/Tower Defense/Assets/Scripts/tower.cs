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
    public GameObject towerAttackPoint;
    private bool alreadyAttacked;
    private bool enemyInAttackRange;
    private bool enemyDead;
    private LayerMask whatIsEnemy;

    [Header("References")]
    public Transform enemy;
    // Start is called before the first frame update

    public void shoot()
    {
        
        try
        {
            enemyDead = false;
            enemy = GameObject.Find("enemy_1(Clone)").transform;
            projectile.transform.position = towerAttackPoint.transform.position;
            Instantiate(projectile);
        }
        catch
        {
            Debug.Log("No Enemy Being Targetted");
            enemyDead = true;
            CancelInvoke(nameof(shoot));
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(shoot), 0, timeBetweenAttacks);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDead)
        {
            InvokeRepeating(nameof(shoot), 0, timeBetweenAttacks);
        }
    }
}
