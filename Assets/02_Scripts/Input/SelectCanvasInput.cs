using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCanvasInput : UIInput
{
    public ChoiceSceneUIController uIController;

    private void Awake()
    {
        raycaster = GetComponent<GraphicRaycaster>();
    }

    protected override void Press(Vector2 screenPosition, float time)
    {
        base.Press(screenPosition, time);

        if(clickResults.Count != 0)
        {
            var ob = clickResults[0].gameObject;
            if(ob.CompareTag("SelectSlot"))
            {
                var slot = ob.GetComponent<CharacterSlot>();
                uIController.ShowJoinCanvas(slot);
            }
        }
    }
}


