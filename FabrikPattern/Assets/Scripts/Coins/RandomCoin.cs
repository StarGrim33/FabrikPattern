using UnityEngine;

public class RandomCoin : Coin
{
    [SerializeField, Range(1, 50)] private int _minValue;
    [SerializeField, Range(50, 100)] private int _maxValue;

    protected override void AddCoin(ICoinPicker coinPicker) => coinPicker.Add(Random.Range(_minValue, _maxValue));
}
