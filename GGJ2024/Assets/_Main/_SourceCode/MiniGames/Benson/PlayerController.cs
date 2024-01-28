using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput = 0;
    public float xLimit = 8.5f;
    public float speed = 10f;
    private Rigidbody2D _rb;

    private float timerStep = 0.5f;

    private void Awake()
    {
        horizontalInput = 0;
    }

    private void Update()
    {
        Move();
        timerStep -= Time.deltaTime;
        if (horizontalInput!=0f && timerStep <= 0.0f)
        {
            AudioManager.AudioInstance.PlaySFX("walk");
            timerStep = 0.3f;
        }
    }

    private void Move()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
        if (transform.position.x < -xLimit)
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        else if (transform.position.x > xLimit)
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
    }
}
