using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject blueBallPrefab;
    [SerializeField] GameObject orangeBallPrefab;

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
            SpawnBlueBall();
            SpawnOrangeBall();
        }
    }

    void SpawnBlueBall()
    {
        lastBallSpawned = Time.time;
        GameObject newBall = Instantiate(blueBallPrefab, ballSpawnpointRef.transform.position, ballSpawnpointRef.transform.rotation);
    }
    
    void SpawnOrangeBall()
    {
        lastBallSpawned = Time.time;
        GameObject newBall = Instantiate(orangeBallPrefab, ballSpawnpointRef.transform.position, ballSpawnpointRef.transform.rotation);
    }
}
