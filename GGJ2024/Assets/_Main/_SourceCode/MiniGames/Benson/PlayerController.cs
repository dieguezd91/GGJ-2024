using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float xLimit = 8.5f;
    public float speed = 10f;

    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

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
