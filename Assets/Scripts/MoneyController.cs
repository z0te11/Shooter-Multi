using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static Action<int> OnMoneyChanged;
    public static MoneyController instance;
    private int _money;

    public int Money 
    { 
        get { return _money; } 
        set { _money = value;
        OnMoneyChanged?.Invoke(_money); } 
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        Money = 0;
    }

    public void AddMoney(int value)
    {
        if (value > 0) Money += value;
    }

    public void RemoveMoney(int value)
    {
        if (value > 0) Money -= value;
    }
}
