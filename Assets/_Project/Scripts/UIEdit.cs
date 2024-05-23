using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEdit : UIBase
{
    public void OnClickGoldPlus()
    {
        UserInfo.myInfo.Gold += 100;
    }
    public void OnClickGoldMinus()
    {
        UserInfo.myInfo.Gold -= 100;
    }
    public void OnClickCashPlus()
    {
        UserInfo.myInfo.Cash += 10;
    }
    public void OnClickCashMinus()
    {
        UserInfo.myInfo.Cash -= 10;
    }
    public void OnClickEnergyPlus()
    {
        UserInfo.myInfo.Energy += 1;
    }
    public void OnClickEnergyMinus()
    {
        UserInfo.myInfo.Energy -= 1;
    }
}
