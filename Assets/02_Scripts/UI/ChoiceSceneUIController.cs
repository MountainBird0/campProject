using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChoiceSceneUIController : MonoBehaviour
{

    [Header("Canvas")]
    public GameObject selectCanvas;
    public GameObject joinCanvas;

    [Header("Join")]
    public Image selectedImage;
    public TMP_InputField nameField;
    public Button joinButton;

         
    private void Start()
    {
        ShowSelectCanvas();

        joinButton.onClick.AddListener(ClickBTNJoin);
        nameField.onValueChanged.AddListener(delegate { CheckTextLength(); });
    }


    public void ShowSelectCanvas()
    {
        selectCanvas.SetActive(true);
        joinCanvas.SetActive(false);
        nameField.text = "";
    }

    public void ShowJoinCanvas(CharacterSlot slot)
    {
        selectCanvas.SetActive(false);
        joinCanvas.SetActive(true);
        selectedImage.sprite = slot.image.sprite;
        
        ChoiceSceneUIManager.instance.slot = slot;
    }

    public void ClickBTNJoin()
    {
        ChoiceSceneUIManager.instance.ClickJoin(nameField.text);
    }

    private void CheckTextLength()
    {
        if(2 <= nameField.text.Length && nameField.text.Length <= 10)
        {
            joinButton.interactable = true;
        }
        else
        {
            joinButton.interactable = false;
        }
    }
}
