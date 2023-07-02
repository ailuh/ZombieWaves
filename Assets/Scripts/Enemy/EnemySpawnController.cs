using System.Collections.Generic;
using ScriptableObjects;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {
        private UIMainMenu _mainMenu;
        private readonly List<Spawner> _spawners = new();
        private WavesData _wavesData;
        private int _currentWave;
        private int _currentWaveKills;
        private UnityAction _diedZombiesNum;
        private int _currentWaveCount;

        public void OnInit(WavesData wavesData, Transform playerTransform, UIMainMenu mainMenu)
        {
            _diedZombiesNum += AddDiedZombie;
            _wavesData = wavesData;
            _mainMenu = mainMenu;
            foreach (Transform spawner in transform)
            {
                spawner.TryGetComponent<Spawner>(out var spawn);
                if (spawn == null) continue;
                spawn.OnInit(playerTransform);
                _spawners.Add(spawn);
            }
            _mainMenu.SetSpawnController(this);
        }

        public void StartSpawning()
        {
            SpawnWave();
        }
    
        private void SpawnWave()
        {
            StartCoroutine(_mainMenu.OnWaveStarted(_currentWave + 1));
            var waveCount = _wavesData.WavesCounts[_currentWave].ZombiesCount / _spawners.Count;
            _currentWaveCount = 0;
            foreach (var spawner in _spawners)
            {
                _currentWaveCount += waveCount;
                StartCoroutine(spawner.SpawnZombies(waveCount, _diedZombiesNum));
            }
            _mainMenu.OnZombieDied(_currentWaveCount);
        }

        private void AddDiedZombie()
        {
            _currentWaveKills++;
            var remainCount = _currentWaveCount - _currentWaveKills;
            _mainMenu.OnZombieDied(remainCount);
            if (_currentWaveKills == _currentWaveCount)
            {
                if (_currentWave == _wavesData.WavesCounts.Count - 1)
                {
                    _mainMenu.OnWin();
                    return;
                }
                _currentWaveKills = 0;
                _currentWave++;
                SpawnWave();
            }
        }
    }
}
