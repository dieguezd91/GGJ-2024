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



    IEnumerator ShowControls()
    {
        controlsScreen.SetActive(true);
        yield return new WaitForSeconds(controlsShowingTime);
        controlsScreen.SetActive(true);
    }
}    
