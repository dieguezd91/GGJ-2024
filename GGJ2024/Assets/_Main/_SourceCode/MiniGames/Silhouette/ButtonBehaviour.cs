using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    private RectTransform pos;
    private Button button;
    private Vector3 randomDir;
    private int randomRot;

    private void Awake()
    {
        pos = GetComponent<RectTransform>();
        button = GetComponent<Button>();
        GetRandomDirection();
        GetRandomRotation();
    }

    private void Update()
    {
        pos.localPosition += randomDir * speed * Time.deltaTime;
    }

    public void GetRandomDirection()
    { 
        randomDir.x = Random.Range(0f, 1f);
        randomDir.y = Random.Range(0f, 1f);
        randomDir.z = 0f;
    }

    public void GetRandomRotation()
    {
        randomRot = Random.Range(-1, 2);
    }
}
