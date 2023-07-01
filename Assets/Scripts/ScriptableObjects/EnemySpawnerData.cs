using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "New Spawner", order = 3)]
    public class EnemySpawnerData : ScriptableObject
    {
        [SerializeField] 
        private GameObject zombiePrefab;
        [SerializeField] 
        private float spawnDelay;
        public GameObject ZombiePrefab => zombiePrefab;
        public float SpawnDelay => spawnDelay;
    }
}
