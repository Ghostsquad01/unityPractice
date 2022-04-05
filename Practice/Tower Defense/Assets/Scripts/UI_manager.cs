using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    public TextMeshProUGUI purse;
    public TextMeshProUGUI selected_tower;
    public GameObject towerSpawner;
    public Sprite fireball_tower;
    public Sprite wizard_tower;

    private int score;
    private int tower = 1;
    // Start is called before the first frame update
    void Start()
    {
        selected_tower.text = "Fireball Tower is selected";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
                            towerSpawner.transform.position = hit.collider.gameObject.transform.position;
                            Destroy(hit.collider.gameObject);
                            towerSpawner.GetComponent<SpriteRenderer>().sprite = fireball_tower;
                            Instantiate(towerSpawner);
                            score -= 1000;
                            purse.text = "Purse: " + score;
                        }
                    }else if (tower == 2)
                    {
                        if (score >= 2000)
                        {
                            towerSpawner.transform.position = hit.collider.gameObject.transform.position;
                            Destroy(hit.collider.gameObject);
                            towerSpawner.GetComponent<SpriteRenderer>().sprite = wizard_tower;
                            Instantiate(towerSpawner);
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
                        Destroy(hit.transform.gameObject);
                        addCoins();
                    }
                }
            }
        }
    }

    public void addCoins()
    {
        score += 1000;
        purse.text = "Purse: " + score;
    }
}
