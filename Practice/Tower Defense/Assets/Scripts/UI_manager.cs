using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    public TextMeshProUGUI purse;
    public TextMeshProUGUI selected_tower;
    public TextMeshProUGUI healthbar;
    public TextMeshProUGUI gameover;
    public GameObject fireball_tower;
    public GameObject wizard_tower;
    public AudioClip clip;
    public Button btn;
    private AudioSource audio;

    private int score;
    private int tower = 1;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        
        audio = GetComponent<AudioSource>();
        audio.clip = clip;
        selected_tower.text = "Fireball Tower is selected";
        score = 1000;
        health = 100;
        healthbar.text = "Your health Left: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (tower == 1)
            {
                selected_tower.text = "Wizard Tower is selected";
                tower = 2;
            }
            else if (tower == 2)
            {
                selected_tower.text = "Fireball Tower is selected";
                tower = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "def_spot")
                {
                    if (tower == 1)
                    {
                        if (score >= 1000)
                        {
                            fireball_tower.transform.position = hit.collider.gameObject.transform.position;
                            Destroy(hit.collider.gameObject);
                            Instantiate(fireball_tower);
                            score -= 1000;
                            purse.text = "Purse: " + score;
                        }
                    }else if (tower == 2)
                    {
                        if (score >= 2000)
                        {
                            wizard_tower.transform.position = hit.collider.gameObject.transform.position;
                            Destroy(hit.collider.gameObject);
                            Instantiate(wizard_tower);
                            score -= 2000;
                            purse.text = "Purse: " + score;
                        }
                    }
                }
                if (hit.transform.tag == "Enemy_1")
                {
                    hit.transform.GetComponent<Enemy>().Damage();
                    if (hit.transform.GetComponent<Enemy>().getHealth() == 0)
                    {
                        audio.Play();
                        Destroy(hit.transform.gameObject);
                        addCoins();
                    }
                }
            }
        }
    }

    public void loseHP()
    {
        health -= 20;
        if (health == 0)
        {
            Debug.Log("You suck at defending! You lost!");
            gameover.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
        }
        healthbar.text = "Your health Left: " + health;
    }

    public void addCoins()
    {
        score += 1000;
        purse.text = "Purse: " + score;
    }
}
