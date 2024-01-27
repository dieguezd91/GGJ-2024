using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    //private float _lastGravityUpdate;
    //[SerializeField] private float velocityIncreaseValue;
    //[SerializeField] private BensonController bensonController;

    private void Start()
    {
        // bensonController = GetComponent<BensonController>();
        // _lastGravityUpdate = Time.time;
    }
    
    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        // if (Time.time >= _lastGravityUpdate + 1)
        // {
        //     _rb.gravityScale += .3f;
        //     bensonController.movementVelocity += velocityIncreaseValue;
        //     if(bensonController.ballSpawnCd >= 0.75f) 
        //         bensonController.ballSpawnCd -= 0.25f;
        //     _lastGravityUpdate = Time.time;
        // }
    }

    protected void Collided(bool withPlayer)
    {
        Destroy(gameObject);
    }
}
