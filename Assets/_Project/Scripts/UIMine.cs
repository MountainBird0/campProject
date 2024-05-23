using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMine : UIBase
{
    [SerializeField] private Currency currency;
    public override void OnOpened(object[] param)
    {
        UserInfo.myInfo.SetGoldEvent(currency.SetText);
    }

    public override void HideDirect()
    {
        UIManager.instance.Hide<UIMine>();
    }

    public override void OnClosed(object[] param)
    {
        UserInfo.myInfo.RemoveGoldEvent(currency.SetText);
    }

    public void OnGathering()
    {
        UserInfo.myInfo.Gold += 100;
    }
}
