using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DungeonInfo
{
    public Image image;
    public TMPro.TMP_Text diff;
    public TMPro.TMP_Text use;

    public void SetInfo(DungeonData data)
    {
        image.sprite = Resources.Load<Sprite>(data.imageName);
        diff.text = data.level.ToString();
        use.text = data.useEnergy.ToString();
    }
}

public class DungeonData
{
    public string imageName;
    public string level;
    public int useEnergy;
}

public class UIDungeon : UIBase
{
    [SerializeField] private DungeonInfo info;
    [SerializeField] private Currency currency;
    public override void OnOpened(object[] param)
    {
        UserInfo.myInfo.SetEnergyEvent(currency.SetText);
    } 
    public void ChangeDungeonInfo(DungeonData data)
    {
        info.SetInfo(data);
    }

    public override void HideDirect()
    {
        UIManager.instance.Hide<UIDungeon>();
    }

    public override void OnClosed(object[] param)
    {
        UserInfo.myInfo.RemoveEnergyEvent(currency.SetText);
    }

    public void OnEnterDungeon()
    {
        UserInfo.myInfo.Energy -= 3;
    }
}
