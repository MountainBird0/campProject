using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    public event Action<int, int, int, bool> setUI;

    private int hp;
    private int mp;
    private int sp;
    private GameObject weapon;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        SetUI();
    }

    public void SetUI()
    {
        setUI?.Invoke(hp, mp, sp, weapon != null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello");
        SetUI();
    }
}