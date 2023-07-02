using System.Collections;
using ScriptableObjects;
using Stats;
using UnityEngine;
using UnityEngine.Events;
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
    
        public IEnumerator SpawnZombies(int zombiesNum, UnityAction onDied)
        {
        
            for (int i = 0; i < zombiesNum; i++)
            {
           
                var spawnPosition = new Vector3(Random.Range(_minX, _maxX), transform.position.y, Random.Range(_minY, _maxY));
                var speedRandom = Random.Range(_speedMin, _speedMax);
                var enemy = Instantiate(enemySpawnerData.ZombiePrefab, transform);
                enemy.transform.position = spawnPosition;
                enemy.GetComponent<EnemyMoving>().OnInit(_playerTransform, speedRandom);
                enemy.GetComponent<EnemyStats>().SetOnDied(onDied);
                yield return new WaitForSeconds(enemySpawnerData.SpawnDelay);
            }
        }
    }
}
