using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITopBar : MonoBehaviour
{
    [SerializeField] private Currency currencyGold;
    [SerializeField] private Currency currencyCash;
    [SerializeField] private Currency currencyEnergy;

    private void Start()
    {
        UserInfo.myInfo.SetGoldEvent(currencyGold.SetText);
        UserInfo.myInfo.SetCashEvent(currencyCash.SetText);
        UserInfo.myInfo.SetEnergyEvent(currencyEnergy.SetText);
    }

    private void OnDestroy()
    {
        UserInfo.myInfo.RemoveGoldEvent(currencyGold.SetText);
        UserInfo.myInfo.RemoveCashEvent(currencyCash.SetText);
        UserInfo.myInfo.RemoveEnergyEvent(currencyEnergy.SetText);
    }
}
