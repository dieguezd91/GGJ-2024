using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float remainingTime;
    public TextMeshProUGUI timer;
    public GameObject player1;
    public GameObject player2;
    public GameObject currentCharacter;
    private int _caughtBalls;
    private int _objective;
    [SerializeField] private int objectiveMultiplier;
    [SerializeField] private int pointsForVictory;
    [SerializeField] private GameObject controlsScreen;
    [SerializeField] private float controlsShowingTime;
    [SerializeField] private TextMeshProUGUI score;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        currentCharacter = player1;
        _objective = GameManager.instance.currentRound * objectiveMultiplier;
        StartCoroutine(ShowControls());
    }

    private void Update()
    {
        if (remainingTime > 0) remainingTime -= Time.deltaTime;
        
        if (remainingTime <= 0)
        {
            if (EndGame()) Win();
            else Lose();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = $"{minutes}:{seconds}";
        score.text = _caughtBalls.ToString();

        if (Input.GetKeyDown(KeyCode.Q)) SwitchCharacter();
    }

    public void CatchBall()
    {
        _caughtBalls++;
        AudioManager.AudioInstance.PlaySFX("catchBall");
    }

    bool EndGame()
    {
        return _caughtBalls >= _objective;
    }
    
    private void Win()
    {
        GameManager.instance.LoadNewLevel();
        GameManager.instance.AddPoints(pointsForVictory);
        Debug.Log("Win");
    }

    public void Lose() => GameManager.instance.GameOver();

    private void SwitchCharacter()
    {
        if(currentCharacter == player1)
        {
            player1.SetActive(false);
            player2.SetActive(true);
            currentCharacter = player2;
        }
        else if (currentCharacter == player2)
        {
            player2.SetActive(false);
            player1.SetActive(true);
            currentCharacter = player1;
        }
    } 

    IEnumerator ShowControls()
    {
        controlsScreen.SetActive(true);
        yield return new WaitForSeconds(controlsShowingTime);
        controlsScreen.SetActive(true);
    }
}    
