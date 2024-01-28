using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentGame;
    private bool _tutorial;
    public int currentRound;
    public int points;
    public List<SceneAsset> array1;
    public List<SceneAsset> array2;
    [SerializeField] private List<SceneAsset> games;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        _tutorial = true;
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
            if (_tutorial) _tutorial = false;
            SetNewRound();
        }
        else
        {
            currentGame++;
            if (_tutorial) SceneManagerScript.instance.LoadScene(currentGame);
            else SceneManager.LoadScene(array2[currentGame - 1].name);
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        Debug.Log($"+{pointsToAdd} pts");
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
