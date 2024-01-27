using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentGame;
    public int lastGamePlayed;
    private bool tutorial;
    int currentRound;
    public List<int> array1;
    public List<int> array2;
    [SerializeField] List<int> games;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        tutorial = true;
        array1 = games;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) LoadNewLevel();
        if (Input.GetKeyDown(KeyCode.J)) SetNewRound();
    }

    private void Randomize()
    {
        int b = array1.Count;
        for (int n = 0; n < b; n++)
        {
            int a = Random.Range(0, array1.Count);
            array2.Insert(n, array1[a]);
            array1.RemoveAt(a);
        }
    }

    void SetNewRound()
    {
        currentRound++;
        currentGame = 0;
        Randomize();
        LoadNewLevel();
    }

    public void LoadNewLevel()
    {
        if (tutorial)              //En la ronda 1, los minijuegos se juegan en orden.
        {
            if (currentGame == 4)
            {
                SetNewRound();
            }
            else
            {
                currentGame++;
                SceneManagerScript.instance.LoadScene(currentGame);
            }
        }
    }

    public void GameOver()
    {
        SceneManagerScript.instance.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
