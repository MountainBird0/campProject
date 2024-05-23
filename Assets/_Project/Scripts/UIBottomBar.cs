using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBottomBar : MonoBehaviour
{
    public void OnClickShop()
    {
        UIManager.instance.Show<UIShop>();
    }

    public void OnClickDungeon()
    {
        UIManager.instance.Show<UIDungeon>();
    }

    public void OnClickMine()
    {
        UIManager.instance.Show<UIMine>();
    }
}
