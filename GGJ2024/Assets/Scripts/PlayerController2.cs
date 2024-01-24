using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float player2HorizontalInput;

    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((Vector3.left * Time.deltaTime * speed));
        }
    }
}
