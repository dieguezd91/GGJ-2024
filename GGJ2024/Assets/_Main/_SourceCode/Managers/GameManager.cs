using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] List<SceneAsset> availableGames = new List<SceneAsset>();
    public int currentGame;
    public int lastGamePlayed;
    private bool tutorial;
    int currentRound;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        tutorial = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) NextGame();
    }

    public void NextGame()
    {

        if (tutorial)              //En la ronda 1, los minijuegos se juegan en orden.
        {
            if (currentGame == 4)
            {
                tutorial = false;
                currentRound++;
                currentGame = 0;
                LoadRandomLevel();
            }
            else
            {
                currentGame++;
                SceneManagerScript.instance.LoadScene(currentGame);
            }
        }
        else
        {
            if (currentGame == 4)
            {
                currentRound++;
                currentGame = 0;
            }
            LoadRandomLevel();
        }
    }

    private void LoadRandomLevel()
    {
        Debug.Log("LoadRandomLevel");
        //// A partir de la ronda 2, los minijuegos se juegan de manera aleatoria
        //SceneAsset previousGame = availableGames[SceneManagerScript.instance.scene];
        //Debug.Log(previousGame.name);
        //Debug.Log(previousGame);
        //availableGames.Remove(previousGame);
        //int r = Random.Range(1, availableGames.Count);
        //Debug.Log(r);
        //SceneManagerScript.instance.LoadScene(r);
        //availableGames.Add(previousGame);
        //currentGame++;

        //availableGames.Sort()
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
