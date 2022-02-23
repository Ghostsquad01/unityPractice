using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.U2D.IK;

public class LevelParser : MonoBehaviour
{
    // b = brick
    // x = rock
    // ? = questionBlock
    // s = stone
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                
                if (letter == 'x') // rock block
                {
                    var testObject = Instantiate(rockPrefab);
                    testObject.transform.position = new Vector3(column, row, 0f);
                    testObject.transform.SetParent(environmentRoot);
                }

                if (letter == 'b') // brick block
                {
                    var testObject = Instantiate(brickPrefab);
                    testObject.transform.position = new Vector3(column, row, 0f);
                    testObject.transform.SetParent(environmentRoot);
                }

                if (letter == '?') // question block
                {
                    var testObject = Instantiate(questionBoxPrefab);
                    testObject.transform.position = new Vector3(column, row, 0f);
                    testObject.transform.SetParent(environmentRoot);
                }

                if (letter == 's') // stone block
                {
                    var testObject = Instantiate(stonePrefab);
                    testObject.transform.position = new Vector3(column, row, 0f);
                    testObject.transform.SetParent(environmentRoot);
                }
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    public void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
