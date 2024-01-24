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
    int currentRound;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) NextGame();
    }

    public void NextGame()
    {
                //En la ronda 1, los minijuegos se juegan en orden.
        if(currentRound == 1)
            switch (currentGame)
            {
                case 0:
                    SceneManagerScript.instance.LoadScene(1);
                    break;
                case 1:
                    SceneManagerScript.instance.LoadScene(2);
                    break;
                case 2:
                    SceneManagerScript.instance.LoadScene(3);
                    break;
                case 3:
                    SceneManagerScript.instance.LoadScene(4);
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }

                // A partir de la ronda 2, los minijuegos se juegan de manera aleatoria
        int r = Random.Range(1, availableGames.Count);
        while(r == currentGame) Random.Range(1, availableGames.Count);
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
