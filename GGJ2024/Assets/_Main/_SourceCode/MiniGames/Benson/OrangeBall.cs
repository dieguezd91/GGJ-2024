using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBall : Ball
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "OrangePlayer")
        {
            BensonManager.instance.Lose();
            Collided(false);
        }
        else if (col.gameObject.CompareTag("OrangePlayer"))
            Collided(true);
    }
}
