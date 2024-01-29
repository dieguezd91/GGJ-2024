using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
    private UnityEvent onMouseClick = new UnityEvent();
    public UnityEvent OnMouseClick => onMouseClick;

    public void OnMouseDown()
    {
        onMouseClick?.Invoke();
    }
}
