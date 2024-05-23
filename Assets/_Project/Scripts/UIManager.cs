using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private List<UIBase> uiList;

    private void Awake()
    {
        instance = this;
    }

    public void Show<T>(params object[] param) where T : UIBase
    {
        var ui = uiList.Find(obj => obj.name == typeof(T).ToString());
        if (ui != null)
        {
            ui.SetActive(true);
            ui.opened.Invoke(param);
        }

    }

    public void Hide<T>(params object[] param) where T : UIBase
    {
        var ui = uiList.Find(obj => obj.name == typeof(T).ToString());
        if (ui != null)
        {
            ui.SetActive(false);
            ui.closed.Invoke(param);
        }
    }
}
