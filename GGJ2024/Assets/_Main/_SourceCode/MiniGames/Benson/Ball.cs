using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    [SerializeField] int points;

    private void Start()
    {
        fallSpeed *= GameManager.instance.currentRound;
    }
    
    private void Update() => transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

    protected void Collided(bool withPlayer)
    {
        if(withPlayer) LevelManager.instance.AddPoints(points);
        Destroy(gameObject);
    }
}
