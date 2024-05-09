using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCanvasInput : UIInput
{
    private ChoiceSceneUIController uIController;

    private void Awake()
    {
        raycaster = GetComponent<GraphicRaycaster>();
    }

    private void Start()
    {
        uIController = ChoiceSceneUIManager.instance.uiController;
    }

    protected override void Press(Vector2 screenPosition, float time)
    {
        base.Press(screenPosition, time);

        if(clickResults.Count != 0)
        {
            var ob = clickResults[0].gameObject;
            if(ob.CompareTag("SelectSlot"))
            {
                var info = ob.GetComponent<CharacterSlot>();
                string label = info.characterName;
                Debug.Log($"{GetType()} - 누른거 종류 {label}");
            }
        }

    }

}


