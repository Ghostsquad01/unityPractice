using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject ballPrefab;
    private int leftScore = 0;
    private int rightScore = 0;
    // Start is called before the first frame update
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (transform.gameObject.name == "LeftGoal")
        {
            ballPrefab.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
            rightScore++;
            score.text = $"{rightScore}";
        }else if (transform.gameObject.name == "RightGoal")
        {
            ballPrefab.transform.localPosition = new Vector3(0.5f, 0f, 0f);
            leftScore++;
            score.text = $"{leftScore}";
        }

        if (leftScore == 11)
        {
            leftScore = 0;
            rightScore = 0;
            Debug.Log("Left Player wins! The score is now reset to " + leftScore + "-" + rightScore);
        }else if (rightScore == 11)
        {
            leftScore = 0;
            rightScore = 0;
            Debug.Log("Right Player wins! The score is now reset to " + leftScore + "-" + rightScore);
        }
        else
        {
            Instantiate(ballPrefab);  
        }
        
    }
    
}
