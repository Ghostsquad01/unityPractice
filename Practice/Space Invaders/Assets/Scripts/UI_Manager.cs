using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using System.IO;

public class UI_Manager : MonoBehaviour
{
    public TextMeshPro score;
    public TextMeshPro highScore;
    public TextMeshPro enemyLegend;
    public float score2;
    
    private float enemyAMT = 16;
    private float playerscore = 0;

    private String hiscoreStart;

    private float check;
    // Start is called before the first frame update
    void Start()
    {
        String hiscoreStart;
        hiscoreStart = File.ReadAllText("./Assets/Scores/hiscores.txt");
        highScore.text = "Hi-Score\n " + hiscoreStart;
        enemyLegend.text = "";
        score.text = "Score\n 0000";
        check = float.Parse(hiscoreStart, CultureInfo.InvariantCulture.NumberFormat);
        if (check < 10)
        {
            highScore.text = "Hi-Score\n 0000";
        }else if (check < 100)
        {
            highScore.text = "Hi-Score\n 00" + hiscoreStart;
        }else if (check < 1000)
        {
            highScore.text = "Hi-Score\n 0" + hiscoreStart;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyAMT == 0 || playerscore > check)
        {
            String hiscore = playerscore.ToString();
            File.WriteAllText("./Assets/Scores/hiscores.txt",hiscore);
            if (playerscore < 10)
            {
                highScore.text = "Hi-Score\n 0000";
            }else if (playerscore < 100)
            {
                highScore.text = "Hi-Score\n 00" + hiscore;
            }else if (playerscore < 1000)
            {
                highScore.text = "Hi-Score\n 0" + hiscore;
            }
        }
    }

    public void enemyDestroyed(String tag)
    {
        enemyAMT--;
        if (tag == "Enemy_1")
        {
            playerscore += 10;
        }else if (tag == "Enemy_2")
        {
            playerscore += 20;
        }else if (tag == "Enemy_3")
        {
            playerscore += 30;
        }else if (tag == "Enemy_4")
        {
            playerscore += 40;
        }

        if (playerscore < 10)
        {
            score.text = "Score\n 0000";
        }
        if (playerscore < 100)
        {
            score.text = "Score\n 00" + playerscore;
        }else if (playerscore < 1000)
        {
            score.text = "Score\n 0" + playerscore;
        }
    }

    public float  enemiesLeft()
    {
        return enemyAMT;
    }

    public void updateHiScore()
    {
        String hiscore = playerscore.ToString();
        File.WriteAllText("./Assets/Scores/hiscores.txt",hiscore);
    }
}
