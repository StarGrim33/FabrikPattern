using UnityEngine;

public abstract class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ICoinPicker>(out ICoinPicker coinPicker))
        {
            AddCoin(coinPicker);
        }
    }

    protected abstract void AddCoin(ICoinPicker coinPicker);
}
