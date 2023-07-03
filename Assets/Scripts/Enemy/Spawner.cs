using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using Stats;
using UnityEngine;
using static Enemy.EnemySpawnController;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] 
        private EnemySpawnerData enemySpawnerData;
        private Transform _playerTransform;
        private float _minX;
        private float _maxX;
        private float _minY;
        private float _maxY;
        private float _speedMax;
        private float _speedMin;
        private readonly List<EnemyControls> _enemyControls = new();
        private readonly List<EnemyAttack> _enemyAttacks = new();


        public void OnInit(Transform playerTransform)
        {
            _playerTransform = playerTransform;
            var randomValue = enemySpawnerData.SpawnRandomRange;
            var position = transform.position;
            _minX = position.x - randomValue;
            _maxX = position.x + randomValue;
            _minY = position.z - randomValue;
            _maxY = position.z + randomValue;
            _speedMax = enemySpawnerData.Speed + enemySpawnerData.SpeedRandomRange;
            _speedMin = enemySpawnerData.Speed + enemySpawnerData.SpeedRandomRange;
       
        }
    
        public IEnumerator SpawnZombies(int zombiesNum, OnDiedHandler onDied)
        {
            _enemyControls.Clear();
            _enemyAttacks.Clear();
            for (var i = 0; i < zombiesNum; i++)
            {
                var spawnPosition = new Vector3(Random.Range(_minX, _maxX), transform.position.y, Random.Range(_minY, _maxY));
                var speedRandom = Random.Range(_speedMin, _speedMax);
                var enemy = Instantiate(enemySpawnerData.ZombiePrefab, transform);
                enemy.transform.position = spawnPosition;
                var enemyControls = enemy.GetComponent<EnemyControls>();
                enemyControls.OnInit(_playerTransform, speedRandom);
                _enemyControls.Add(enemyControls);
                enemy.GetComponent<EnemyStats>().SetOnDied(onDied);
                var enemyAttack = enemy.GetComponent<EnemyAttack>();
                _enemyAttacks.Add(enemyAttack);
                yield return new WaitForSeconds(enemySpawnerData.SpawnDelay);
            }
        }

        public void OnDisableEnemyInput(bool isDisabled)
        {
            if (_enemyControls.Count == 0) return;
            for (var i = 0; i < _enemyControls.Count; i++)
            {
                if (_enemyControls[i] != null)
                {
                    _enemyAttacks[i].OnInputDisable(isDisabled);
                    _enemyControls[i].OnDisableInput(isDisabled);
                }
                else
                {
                    _enemyAttacks.RemoveAt(i);
                    _enemyControls.RemoveAt(i);
                }
            }
          
        }
    }
}
