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
        transform.Rotate(Vector3.forward, randomRot * rotSpeed * Time.deltaTime);
    }

    public void GetRandomDirection()
    { 
        randomDir.x = Random.Range(0, 2);
        randomDir.y = Random.Range(0, 2);
        randomDir.z = 0f;
    }

    public void GetRandomRotation()
    {
        randomRot = Random.Range(-1, 2) * 2-1;
    }
}
