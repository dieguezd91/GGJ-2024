using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTarget : MonoBehaviour
{
    public GameObject _target;
    public float _speed;

    Vector2 _current;
    float initZ;
    private void Awake()
    {
        initZ = transform.position.z;
    }
    void Update()
    {
        _current = new Vector3(transform.position.x, transform.position.y, initZ);
        var step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(_current, _target.transform.position, step);
        transform.position = new Vector3(transform.position.x, transform.position.y, initZ);
    }
}
