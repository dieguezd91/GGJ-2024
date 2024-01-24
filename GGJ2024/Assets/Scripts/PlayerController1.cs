using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float player1HorizontalInput;
    public float xLimit = 8.5f;
    public float speed = 10f;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector3.right * Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.A))
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
