using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BensonManager : MonoBehaviour
{
    public int bensonBalls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Win();
    }

    public void Win()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.instance.LoadScene();
        }
    }
}
