using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : Ball
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BluePlayer"))
            Collided(true);
        else
            Destroy(gameObject);
    }
}
