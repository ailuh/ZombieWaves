using System.Collections.Generic;
using Core;
using ScriptableObjects;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {
        private UIProvider _uiProvider;
        private readonly List<Spawner> _spawners = new();
        private WavesData _wavesData;
        private int _currentWave;
        private int _currentWaveKills;
        public delegate void OnDiedHandler();
        public event OnDiedHandler OnZombieDied;
        private int _currentWaveCount;

        public void OnInit(WavesData wavesData, Transform playerTransform, UIProvider uiProvider)
        {
            OnZombieDied += AddDiedZombie;
            _wavesData = wavesData;
            _uiProvider = uiProvider;
            foreach (Transform spawner in transform)
            {
                var isSpawner = spawner.TryGetComponent<Spawner>(out var spawn);
                if (!isSpawner) continue;
                spawn.OnInit(playerTransform);
                _spawners.Add(spawn);
            }
        }

        public void StartSpawning()
        {
            SpawnWave();
        }
    
        private void SpawnWave()
        {
            _uiProvider.OnWaveSpawn(_currentWave);
            var waveCount = _wavesData.WavesCounts[_currentWave].ZombiesCount / _spawners.Count;
            _currentWaveCount = 0;
            foreach (var spawner in _spawners)
            {
                _currentWaveCount += waveCount;
                StartCoroutine(spawner.SpawnZombies(waveCount, OnZombieDied));
            }
            _uiProvider.OnZombieDied(_currentWaveCount);
        }

        private void AddDiedZombie()
        {
            _currentWaveKills++;
            var remainCount = _currentWaveCount - _currentWaveKills;
            _uiProvider.OnZombieDied(remainCount);
            if (_currentWaveKills == _currentWaveCount)
            {
                if (_currentWave == _wavesData.WavesCounts.Count - 1)
                {
                    _uiProvider.OnWin();
                    return;
                }
                _currentWaveKills = 0;
                _currentWave++;
                SpawnWave();
            }
        }

        public void DisableEnemyInput(bool isDisabled)
        {
            foreach (var spawner in _spawners)
            {
                spawner.OnDisableEnemyInput(isDisabled);
            }
        }
    }
}
