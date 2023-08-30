using UnityEngine;

public class StandartCoin : Coin
{
    private int _value = 15;

    protected override void AddCoin(ICoinPicker coinPicker) => coinPicker.Add(_value);
}
