using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private List<Spawner> _spawners = new();
    private WavesData _wavesData;
    private int _currentWave = 0;

    public void OnInit(WavesData wavesData, Transform playerTransform)
    {
        _wavesData = wavesData;
        foreach (Transform spawner in transform)
        {
            spawner.TryGetComponent<Spawner>(out var spawn);
            if (spawn != null)
            {
                spawn.OnInit(playerTransform);
                _spawners.Add(spawn);
            }
        }
        SpawnWave();
    }

    private void SpawnWave()
    {
        var oneWaveCount = _wavesData.WavesCounts[_currentWave].ZombiesCount / _spawners.Count;
        foreach (var spawner in _spawners)
        {
            StartCoroutine(spawner.SpawnZombies(oneWaveCount));
        }

    }
}
