using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    float lastGravityUpdate;
    [SerializeField] float velocityIncreaseValue;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastGravityUpdate = Time.time;
    }

    private void Update()
    {
        if (Time.time >= lastGravityUpdate + 1)
        {
            rb.gravityScale += .3f;
            BensonManager.instance.benson.GetComponent<BallsSpawner>().movementVelocity += velocityIncreaseValue;
            if(BensonManager.instance.benson.GetComponent<BallsSpawner>().ballSpawnCD >= 0.75f) 
                BensonManager.instance.benson.GetComponent<BallsSpawner>().ballSpawnCD -= 0.25f;
            lastGravityUpdate = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            BensonManager.instance.Lose();
            Collided(false);
        }
        else if (col.gameObject.tag == "Player")
            Collided(true);
    }

    void Collided(bool withPlayer)
    {
        if(withPlayer) GameObject.FindWithTag("GameController").GetComponent<BensonManager>().caughtBalls++;
        Destroy(gameObject);
    }
}
