using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] private CoinType _coinType;
    [SerializeField] private List<Coin> _coinPrefabs;

    public Coin Get()
    {
        Coin result = _coinType switch
        {
            CoinType.FalseCoin => _coinPrefabs.FirstOrDefault(x => x is FalseCoin),
            CoinType.StandartCoin => _coinPrefabs.FirstOrDefault(x => x is StandartCoin),
            CoinType.RandomCoin => _coinPrefabs.FirstOrDefault(x => x is RandomCoin),
            _ => _coinPrefabs.FirstOrDefault(x => x is StandartCoin),
        };

        return result;
    }
}
