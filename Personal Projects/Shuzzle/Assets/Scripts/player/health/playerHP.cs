using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    [Header("Health")] 
    public int health;
    public float damagedTimer;

    [Header("References")] 
    public playerCamera cam;
    public Image healthbar;
    public Button restartBTN;
    public TextMeshProUGUI deathMessage;
    private RectTransform hpBar;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        hpBar = healthbar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void takeDamage()
    {
        health -= 20;
        if (health == 0)
        {
            healthbar.GetComponent<RectTransform>().gameObject.SetActive(false);
            deathMessage.gameObject.SetActive(true);
            restartBTN.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            healthbar.GetComponent<RectTransform>().localScale =
                new Vector3(hpBar.localScale.x * 0.75f, hpBar.localScale.y, hpBar.localScale.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Player has been hit: " + health);
            takeDamage();
            Destroy(collision.gameObject);
        }
    }
}
