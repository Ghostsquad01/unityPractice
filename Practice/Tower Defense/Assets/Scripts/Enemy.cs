using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public Transform healthbar;

    private List<Transform> path;
    private GameObject gm;
    private UI_manager ui;
    private int health;
    private int targetWaypointIndex;
    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        targetWaypointIndex = 1;
        health = 2;
        gm = GameObject.FindWithTag("UI_manager");
        ui = gm.gameObject.GetComponent<UI_manager>();
        path = ui.waypoints;
        //   Place our enemy at the starting waypoint
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (targetWaypointIndex == 6)
        {
            ui.loseHP();
            Destroy(gameObject);
            return;
        }

        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = path[targetWaypointIndex].position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;

        Vector3 newPosition = transform.position;
        newPosition += movementDir * Time.deltaTime;

        transform.position = newPosition;

        // todo #4 Check if destination reaches or passed and change target
        if (transform.position == path[targetWaypointIndex].position)
        {
            targetWaypointIndex++;
        }
    }

    //-----------------------------------------------------------------------------

    public void AddToPurse()
    {
        ui.addCoins();
    }

    public void Damage()
    {
        
        health--;
        if (health <= 0)
        {
            ui.newaudio.Play();
            Destroy(gameObject);
        }
        healthbar.localScale = 
            new Vector3(healthbar.localScale.x,healthbar.localScale.y, healthbar.localScale.z/2);
    }

    public int getHealth()
    {
        return health;
    }
}
