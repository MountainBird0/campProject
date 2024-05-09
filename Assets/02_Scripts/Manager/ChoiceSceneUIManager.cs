using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSceneUIManager : MonoBehaviour
{
    public CharacterSlot slot;

    public static ChoiceSceneUIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Destroy");
            Destroy(gameObject);
        }
    }

    public void ClickJoin()
    {
        GameManager.instance.label = slot.characterName;
        GameManager.instance.ChangeScene(1);
    }

}
