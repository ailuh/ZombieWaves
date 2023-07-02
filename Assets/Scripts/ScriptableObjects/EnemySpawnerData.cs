using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "New Spawner", order = 3)]
    public class EnemySpawnerData : ScriptableObject
    {
        [SerializeField] 
        private GameObject zombiePrefab;
        [SerializeField] 
        private float spawnDelay;
        [SerializeField] 
        private float spawnRandomRange;
        [SerializeField] 
        private float speed;
        [SerializeField] 
        private float speedRandomRange;
        public GameObject ZombiePrefab => zombiePrefab;
        public float SpawnDelay => spawnDelay;
        public float Speed => speed;
        public float SpawnRandomRange => spawnRandomRange;
        public float SpeedRandomRange  => speedRandomRange;
    }
}
