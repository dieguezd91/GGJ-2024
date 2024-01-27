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

private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        currentCharacter = player1;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        
        if (remainingTime <= 0)
        {
            Win();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = $"{minutes}:{seconds}";
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCharacter();   
        }
    }

    private void Win()
    {
        GameManager.instance.NextGame();
        Debug.Log("Win");
        //Time.timeScale = 0;
    }

    public void Lose()
    {
        GameManager.instance.GameOver();
    }

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
}    
