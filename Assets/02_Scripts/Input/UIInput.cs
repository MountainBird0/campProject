using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInput : MonoBehaviour
{
    protected GraphicRaycaster raycaster;
    protected PointerEventData clickData = new PointerEventData(EventSystem.current);
    protected List<RaycastResult> clickResults = new();

    private void OnEnable()
    {
        InputManager.instance.OnPress += Press;
        InputManager.instance.OnRelease += Release;
    }

    private void OnDisable()
    {
        InputManager.instance.OnPress -= Press;
        InputManager.instance.OnRelease -= Release;
    }  

    protected virtual void Press(Vector2 screenPosition, float time)
    {
        clickResults.Clear();
        clickData.position = screenPosition;
        raycaster.Raycast(clickData, clickResults);       
    }

    protected virtual void Release(Vector2 screenPosition, float time)
    {

    }
}
