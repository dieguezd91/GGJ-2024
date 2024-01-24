using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float xLimit = 8.5f;
    public float speed = 10f;

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
        
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
    }
}
