using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI worldTimer;
    public TextMeshProUGUI coinScore;
    public TextMeshProUGUI score;

    public AudioClip brickDeath;
    public AudioClip coinPickUp;
    // private TimeSpan timer = new TimeSpan(0, 0, 100);

    private float startTime = 100f;
    private float coinAMT = 0f;

    private float marioScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // mouse0 is for a left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200))
            {
                AudioSource audio = GetComponent<AudioSource>();
                if (hit.collider.gameObject.name == "Brick(Clone)")
                {
                    audio.clip = brickDeath;
                    Destroy(hit.collider.gameObject);
                    audio.Play();
                }
                if (hit.collider.gameObject.name == "Question(Clone)")
                {
                    audio.clip = coinPickUp;
                    audio.Play();
                    coinAMT++;
                    if (coinAMT < 10)
                    {
                        coinScore.text = "x0" + coinAMT;
                    }
                    else
                    {
                        coinScore.text = "x" + coinAMT;
                    }

                    marioScore += 100;
                    score.text = "Mario\n000" + marioScore;
                }
            }
        }
        worldTimer.text = "Time\n   " + Math.Floor(startTime);
        startTime -= Time.deltaTime;
    }
}
