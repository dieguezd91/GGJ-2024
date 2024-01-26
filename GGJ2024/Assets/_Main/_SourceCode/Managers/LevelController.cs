using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int minigameID;
    
    void Start()
    {
        GameManager.instance.lastGamePlayed = minigameID;    
    }
}
