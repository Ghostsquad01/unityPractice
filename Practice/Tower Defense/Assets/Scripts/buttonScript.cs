using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public void NewGameButton()
    {
        SceneManager.LoadScene("Tower Defense Pt. 1 Demo");
    }
}
