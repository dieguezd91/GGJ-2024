using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Floor")
            Collided(false);
        else if (col.gameObject.tag == "Player")
            Collided(true);
    }

    void Collided(bool withPlayer)
    {
        if (withPlayer) GameObject.FindWithTag("GameController").GetComponent<BensonManager>().caughtBalls++;
        Destroy(gameObject);
    }
}
