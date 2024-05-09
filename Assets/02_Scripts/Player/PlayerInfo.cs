using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public TextMeshPro name;

    private void Start()
    {
        SetName();
    }

    public void SetName()
    {
        name.text = GameManager.instance.name;
    }
}
