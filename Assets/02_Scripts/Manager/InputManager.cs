using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void PressEvent(Vector2 position, float time); // 위치, 시작시간
    public event PressEvent OnPress;
    public delegate void ReleaseEvent(Vector2 position, float time);   // 위치, 시작시간
    public event ReleaseEvent OnRelease;

    private InputControl controller;

    public static InputManager instance;
    private void Awake()
    {
        controller = new();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Destroy");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        controller.Enable();
    }

    private void Start()
    {
        controller.Touch.Press.started += context => Press(context);
        controller.Touch.Press.canceled += context => Release(context);
    }

    private void Press(InputAction.CallbackContext context)
    {
        if (OnPress != null)
        {
            OnPress(controller.Touch.PressPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
    }

    private void Release (InputAction.CallbackContext context)
    {
        if(OnRelease != null)
        {
            OnRelease(controller.Touch.PressPosition.ReadValue<Vector2>(), (float)context.time);
        }
    }
}
