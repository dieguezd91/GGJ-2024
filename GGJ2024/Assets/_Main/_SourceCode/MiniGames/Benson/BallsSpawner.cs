using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

public class BallsSpawner : MonoBehaviour
{
    Rigidbody2D rb;
    Transform middleReferencePoint;
    private int movingRight;
    public float movementVelocity;
    [SerializeField] float range;
    float distance;

    [SerializeField] GameObject ballSpawnpointRef;
    float lastBallSpawned;
    public float ballSpawnCD;
    [SerializeField] private GameObject blueBallPrefab;
    [SerializeField] private GameObject orangeBallPrefab;
    private GameObject blueBall;
    private GameObject orangeBall;
    private GameObject lastBall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        middleReferencePoint = Instantiate(new GameObject(), new Vector2(transform.position.x - range/2, transform.position.y), transform.rotation).GetComponent<Transform>();
        movingRight = 1;
        lastBallSpawned = Time.time;
    }

    void Update()
    {
        Move();
        AttemptToSpawnBall();
    }

    void Move()
    {
        rb.velocity = new Vector2(movingRight * movementVelocity, 0);

        distance = transform.position.x - middleReferencePoint.position.x;
        if (distance <= 0) movingRight = 1;
        else if (distance >= range) movingRight = -1;
    }

    void AttemptToSpawnBall()
    {
        if (Time.time >= lastBallSpawned + ballSpawnCD)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        lastBallSpawned = Time.time;
        var r = Random.Range(0, 10);
        Debug.Log("r= " + r);
        if (r < 5)
        {
            GameObject newBlueBall = Instantiate(blueBallPrefab, ballSpawnpointRef.transform.position, ballSpawnpointRef.transform.rotation);
        }
        else if (r > 5)
        {
            GameObject newOrangeBall = Instantiate(orangeBallPrefab, ballSpawnpointRef.transform.position, ballSpawnpointRef.transform.rotation);
        }
    }
}
