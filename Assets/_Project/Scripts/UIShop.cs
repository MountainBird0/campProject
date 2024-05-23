using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIShop : UIBase
{
    [SerializeField] private Currency currency;
    [SerializeField] private List<Toggle> toggles;
    [SerializeField] private List<GameObject> lists;
    private int toggleIdx { get => toggles.FindIndex(obj => obj.isOn); }

    public override void OnOpened(object[] param)
    {
        SetGoldCurrency();
        toggles[(int)param[0]].isOn = true;
        currency.SetUI(eCurrencyType.gold);
    }

    public override void HideDirect()
    {
        UIManager.instance.Hide<UIShop>();
    }

    public override void OnClosed(object[] param)
    {
        if (toggleIdx == 0)
        {
            RemoveGoldCurrency();
        }
        else if (toggleIdx == 1)
        {
            RemoveCashCurrency();
        }
    }

    public void SetGoldCurrency()
    {
        UserInfo.myInfo.SetGoldEvent(currency.SetText);
    }

    public void SetCashCurrency()
    {
        UserInfo.myInfo.SetCashEvent(currency.SetText);
    }

    public void RemoveGoldCurrency()
    {
        UserInfo.myInfo.RemoveGoldEvent(currency.SetText);
    }

    public void RemoveCashCurrency()
    {
        UserInfo.myInfo.RemoveCashEvent(currency.SetText);
    }

    public void OnToggleChanged()
    {
        if (toggleIdx == 0)
        {
            RemoveCashCurrency();
            SetGoldCurrency();
            currency.SetUI(eCurrencyType.gold);
        }
        else if (toggleIdx == 1)
        {
            RemoveGoldCurrency();
            SetCashCurrency();
            currency.SetUI(eCurrencyType.cash);
        }
        lists.ForEach(obj => obj.SetActive(false));
        lists[toggleIdx].SetActive(true);
    }
}
