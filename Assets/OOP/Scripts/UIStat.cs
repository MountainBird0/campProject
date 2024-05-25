using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStat : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        CharacterManager.Instance.Player.setUI += SetStat;
    }

    public void SetStat(int hp, int mp, int sp, bool weapon)
    {
        textUI.text = $"HP:{hp}\nMP:{mp}\nSP:{sp}\nSTR:{weapon}\n";
    }
}