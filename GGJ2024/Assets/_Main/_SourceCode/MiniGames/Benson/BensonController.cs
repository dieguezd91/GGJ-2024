using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

public class BensonController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _middleReferencePoint;
    private int _movingRight;
    public float movementVelocity;
    [SerializeField] private float range;
    private float _distance;

    [SerializeField] private GameObject ballSpawnPointRef;
    private float _lastBallSpawned;
    public float ballSpawnCd;
    [SerializeField] private GameObject blueBallPrefab;
    [SerializeField] private GameObject orangeBallPrefab;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _middleReferencePoint = Instantiate(new GameObject(), new Vector2(transform.position.x - range/2, transform.position.y), transform.rotation).GetComponent<Transform>();
        _movingRight = 1;
        _lastBallSpawned = Time.time;
    }

    private void Update()
    {
        Move();
        AttemptToSpawnBall();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_movingRight * movementVelocity, 0);

        _distance = transform.position.x - _middleReferencePoint.position.x;
        if (_distance <= 0) _movingRight = 1;
        else if (_distance >= range) _movingRight = -1;
    }

    private void AttemptToSpawnBall()
    {
        if (Time.time >= _lastBallSpawned + ballSpawnCd)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        _lastBallSpawned = Time.time;
        var r = Random.Range(0, 10);
        Debug.Log("r= " + r);
        if (r < 5)
        {
            GameObject newBlueBall = Instantiate(blueBallPrefab, ballSpawnPointRef.transform.position, ballSpawnPointRef.transform.rotation);
        }
        else if (r > 5)
        {
            GameObject newOrangeBall = Instantiate(orangeBallPrefab, ballSpawnPointRef.transform.position, ballSpawnPointRef.transform.rotation);
        }
    }
}
