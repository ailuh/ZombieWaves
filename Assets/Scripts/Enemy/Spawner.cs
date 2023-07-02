using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawnerData enemySpawnerData;

    private Transform _playerTransform;

    public void OnInit(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }
    
    public IEnumerator SpawnZombies(int zobmiesNum, UnityAction onDied)
    {
        for (int i = 0; i < zobmiesNum; i++)
        {
            var enemy = Instantiate(enemySpawnerData.ZombiePrefab, transform);
            enemy.GetComponent<EnemyMoving>().OnInit(_playerTransform);
            enemy.GetComponent<EnemyStats>().SetOnDied(onDied);
            yield return new WaitForSeconds(enemySpawnerData.SpawnDelay);
        }
    }
}
