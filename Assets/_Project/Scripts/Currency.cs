using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eCurrencyType
{
    gold,
    cash,
    energy,
}

public class Currency : MonoBehaviour
{
    [SerializeField] private eCurrencyType currencyType;
    [SerializeField] private List<Sprite> iconSprites;
    [SerializeField] private Image icon;
    [SerializeField] private TMPro.TMP_Text text;

    private void Start()
    {
        SetUI(currencyType);
    }

    public void SetUI(eCurrencyType type)
    {
        this.currencyType = type;
        icon.sprite = iconSprites[(int)currencyType];
    }

    public void SetText(string str)
    {
        text.text = str;
    }

    public void SetText(int value)
    {
        text.text = string.Format("{0:#,##0}", value);
    }

    public void SetText(int value, int max)
    {
        text.text = string.Format("{0} / {1}", value, max);
    }
}