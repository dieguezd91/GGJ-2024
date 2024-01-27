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
    public int currentRound;
    public List<SceneAsset> array1;
    public List<SceneAsset> array2;
    [SerializeField] List<SceneAsset> games;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        tutorial = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) LoadNewLevel();
    }

    private void Randomize()
    {
        foreach (SceneAsset i in games) array1.Add(i);

        array2.Clear();
        int b = games.Count;
        for (int n = 0; n < b; n++)
        {
            int a = Random.Range(0, array1.Count);
            array2.Add(array1[a]);
            array1.RemoveAt(a);
        }
    }

    void SetNewRound()
    {
        currentGame = 0;
        if (currentRound == 3)
        {
            currentRound = 0;
            Randomize();
            LoadMainMenu();
        }
        else
        {
            currentRound++;
            Randomize();
            LoadNewLevel();
        }
    }

    public void LoadNewLevel()
    {
        if (currentGame == 4)         //En la ronda 1, los minijuegos se juegan en orden.
        {
            if (tutorial) tutorial = false;
            SetNewRound();
        }
        else
        {
            currentGame++;
            if (tutorial) SceneManagerScript.instance.LoadScene(currentGame);
            else SceneManager.LoadScene(array2[currentGame - 1].name);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        currentGame = 0;
        currentRound = 0;
        LoadMainMenu();
    }

    void LoadMainMenu() => SceneManagerScript.instance.LoadScene(0);

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
