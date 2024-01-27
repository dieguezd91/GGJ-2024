using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    private Transform pos;
    private Rigidbody2D rb;
    private Vector3 randomDir;
    private int randomRot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        GetRandomDirection();
        GetRandomRotation();
        rb.AddForce(randomDir * speed,ForceMode2D.Impulse);
    }

    private void Update()
    {
        
    }

    public void GetRandomDirection()
    { 
        randomDir.x = Random.Range(0f, 1f);
        randomDir.y = Random.Range(0f, 1f);
        randomDir.z = 0f;
    }

    public void GetRandomRotation()
    {
        randomRot = Random.Range(-1, 2);
    }
}
