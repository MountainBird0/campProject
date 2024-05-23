using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Test
{
    public int hello;
    public string hi;
    public float bye;
}

public class UIBase : MonoBehaviour
{
    [SerializeField] private Test test;
    public UnityAction<object[]> opened;
    public UnityAction<object[]> closed;

    private void Awake()
    {
        opened = OnOpened;
        closed = OnClosed;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public virtual void HideDirect() { }

    public virtual void OnOpened(object[] param) { }

    public virtual void OnClosed(object[] param) { }
}
