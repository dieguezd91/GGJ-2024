using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    float lastGravityUpdate;
    [SerializeField] float velocityIncreaseValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastGravityUpdate = Time.time;
    }

    private void Update()
    {
        if (Time.time >= lastGravityUpdate + 1)
        {
            rb.gravityScale += .3f;
            LevelManager.instance.benson.GetComponent<BensonController>().movementVelocity += velocityIncreaseValue;
            if(LevelManager.instance.benson.GetComponent<BensonController>().ballSpawnCd >= 0.75f) 
                LevelManager.instance.benson.GetComponent<BensonController>().ballSpawnCd -= 0.25f;
            lastGravityUpdate = Time.time;
        }
    }

    protected void Collided(bool withPlayer)
    {
        Destroy(gameObject);
    }
}
