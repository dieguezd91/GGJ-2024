using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentGame;
    private bool _tutorial;
    public int currentRound;
    public int points;
    public List<Scene> array1;
    public List<Scene> array2;
    [SerializeField] private List<Scene> games;
    public DifficultyValuesScriptableObject[] minigamesDifficultyValues;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject HUDBenson;

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
        
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy && SceneManagerScript.instance.scene != 0)
            Pause();
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy)
            Resume();
    }

    //private void Randomize()
    //{
    //    foreach (Scene i in games) array1.Add(i);

    //    array2.Clear();
    //    int b = 4; ///HARCORDIE PORQUE EL VALOR DE ESTA VARIABLE ERA UNA LISTA DE ESCENAS.COUNT
    //    for (int n = 0; n < b; n++)
    //    {
    //        int a = Random.Range(0, array1.Count);
    //        array2.Add(array1[a]);
    //       // array1.RemoveAt(a);
    //    }
    //}
    private void Reshuffle()
    {
        for (int t = 0; t < games.Count; t++)
        {
            var tmp = games[t];
            int r = Random.Range(t, games.Count);
            games[t] = games[r];
            games[r] = tmp;
        }
    }
    void SetNewRound()
    {
        currentGame = 0;
        if (currentRound == 3)
        {
            currentRound = 0;
            Reshuffle();
            LoadMainMenu();
        }
        else
        {
            currentRound++;
            Reshuffle();
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
        HUDBenson.SetActive(false);
        gameOverScreen.SetActive(true);
        currentGame = 0;
        currentRound = 0;
    }

    public void LoadMainMenu() => SceneManagerScript.instance.LoadScene(0);

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
