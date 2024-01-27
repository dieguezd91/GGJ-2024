using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BensonManager : MonoBehaviour
{
    public static BensonManager instance;
    public GameObject benson;
    public int caughtBalls;
    [SerializeField] int objective;
    public float remainingTime;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI gameOver;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Update()
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
        timer.text = string.Format("{0}:{1}", minutes, seconds);
    }   

    public void Win()
    {
        GameManager.instance.LoadNewLevel();
    }

    public void Lose()
    {
        GameManager.instance.GameOver();
    }
}
