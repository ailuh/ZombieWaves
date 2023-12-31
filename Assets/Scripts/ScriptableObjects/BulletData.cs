using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "New Bullet", order = 1)]
    public class BulletData : ScriptableObject
    {
        [SerializeField] 
        private float damage;
        [SerializeField] 
        private GameObject bulletPrefab;
        [SerializeField] 
        private float speed;
        [SerializeField] 
        private float lifeTime;
        [SerializeField] 
        private int bulletsPoolNum;
        

        public float Damage => damage;
        public GameObject BulletPrefab => bulletPrefab;
        public float Speed => speed;
        public float LifeTime => lifeTime;
        public int BulletsPoolNum => bulletsPoolNum;
    }
}
