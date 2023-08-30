using System;
using UnityEngine;

public class Player : MonoBehaviour, ICoinPicker
{
    private PlayerBank _bank;

    private void Start()
    {
        _bank = new();
    }

    public void Add(int value) => _bank.Add(value);
}
