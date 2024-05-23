using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class UserInfo
{
    public static UserInfo myInfo { get => GameManager.Instance.userInfo; }

    public delegate void SetGold(int value);
    private event SetGold setGold;
    public delegate void SetCash(int value);
    private event SetCash setCash;
    public delegate void SetEnergy(int value, int max);
    private event SetEnergy setEnergy;

    public string name;
    public int level;

    private int gold = 1000;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            setGold?.Invoke(gold);
        }
    }

    private int cash = 30;
    public int Cash
    {
        get
        {
            return cash;
        }
        set
        {
            cash = value;
            setCash?.Invoke(cash);
        }
    }

    private int energy = 50;
    public int Energy
    {
        get
        {
            return energy;
        }
        set
        {
            energy = value;
            setEnergy?.Invoke(value, maxEnergy);
        }
    }
    private int maxEnergy = 50;

    public void SetGoldEvent(SetGold action)
    {
        setGold += action;
        setGold.Invoke(gold);
    }

    public void RemoveGoldEvent(SetGold action)
    {
        setGold -= action;
    }

    public void SetCashEvent(SetCash action)
    {
        setCash += action;
        setCash.Invoke(cash);
    }

    public void RemoveCashEvent(SetCash action)
    {
        setCash -= action;
    }

    public void SetEnergyEvent(SetEnergy action)
    {
        setEnergy += action;
        setEnergy.Invoke(energy, maxEnergy);
    }

    public void RemoveEnergyEvent(SetEnergy action)
    {
        setEnergy -= action;
    }

}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserInfo userInfo;
    public UserInfo userInfo1;
    public UserInfo userInfo2;
    private void Awake()
    {
        Instance = this;
        userInfo = new UserInfo();
        Init(StartGame);
        Init(ReadyGame);
    }

    public void StartGame()
    {
        Debug.Log("게임시작");
    }

    public void ReadyGame()
    {
        Debug.Log("준비");
    }

    public void Init(UnityAction callback)
    {
        userInfo = new UserInfo();
        userInfo.name = "스파르타";
        userInfo.level = 1;
        callback.Invoke();
        StartCoroutine(SendRequest(ReqEnd));
    }

    public void ReqEnd()
    {
        Debug.Log("request End");
    }

    public IEnumerator SendRequest(UnityAction callback)
    {
        UnityWebRequest req = new UnityWebRequest("https://");
        yield return req.SendWebRequest();
        Debug.Log("WaitEnd");
        callback.Invoke();
    }

    //waitEnd
    //request End
}
