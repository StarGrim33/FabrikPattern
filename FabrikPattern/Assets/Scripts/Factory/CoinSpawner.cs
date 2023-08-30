using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour, IDisposable
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private List<Transform> _spawnPointsList;
    [SerializeField] private Transform _containerForPrefabs;
    [SerializeField] private CoinFactory _coinFactory;

    private readonly HashSet<int> _usedSpawnPoints = new();
    private Coroutine _coroutine;
    private bool _isSpawning = false;

    private void Start()
    {
        StartWork();
    }

    public void Dispose()
    {
        StopWork();
    }

    public void StartWork()
    {
        _isSpawning = true;
        _coroutine = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_coroutine != null)
            _isSpawning = false;
    }

    private IEnumerator Spawn()
    {
        var newWaitForSeconds = new WaitForSeconds(_spawnDelay);

        while (_isSpawning)
        {
            int randomIndex = UnityEngine.Random.Range(0, _spawnPointsList.Count);

            if (_usedSpawnPoints.Contains(randomIndex) == false)
            {
                Coin coin = _coinFactory.Get();
                Transform spawnPoint = _spawnPointsList[randomIndex];
                Instantiate(coin, spawnPoint.position, spawnPoint.rotation, _containerForPrefabs);
                _usedSpawnPoints.Add(randomIndex);

                if (_usedSpawnPoints.Count == _spawnPointsList.Count)
                    _usedSpawnPoints.Clear();

                yield return newWaitForSeconds;
            }
        }
    }
}
