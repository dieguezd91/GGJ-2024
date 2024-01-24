using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BensonManager : MonoBehaviour
{
    public int caughtBalls;
    [SerializeField] int objective;

    void Update()
    {
        Win();
    }

    public void Win()
    {
        if (caughtBalls >= objective)
        {
            SceneManager.instance.LoadScene();
        }
    }
}
