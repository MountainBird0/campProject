using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string label = "";

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Destroy");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
