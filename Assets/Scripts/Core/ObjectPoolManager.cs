using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private BulletData _bulletData;
        private List<GameObject> _bulletPool = new ();
        private Transform _spawnPoint;
    
    
        public void OnInit(BulletData bulletData, Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;
            _bulletData = bulletData;
            _bulletPool = GenerateBullets(_bulletData.BulletsPoolNum);
        }
        
        private List<GameObject> GenerateBullets(int bulletNum)
        {
            for (int i = 0; i < bulletNum; i++)
            {
                var bullet = Instantiate(_bulletData.BulletPrefab, _spawnPoint.position, Quaternion.identity);
                bullet.transform.parent = transform;
                bullet.GetComponent<Bullet>().SetParameters(_bulletData.Speed, _bulletData.LifeTime, _bulletData.Damage, _spawnPoint);
                bullet.SetActive(false);
                _bulletPool.Add(bullet);
            }

            return _bulletPool;
        }

        public GameObject RequestBullet()
        {
            foreach (var bullet in _bulletPool)
            {
                if (bullet.activeInHierarchy) continue;
                bullet.SetActive(true);
                return bullet;
            }

            var newBullet = Instantiate(_bulletData.BulletPrefab, _spawnPoint.position,  Quaternion.identity);
            newBullet.transform.parent = transform;
            _bulletPool.Add(newBullet);

            return newBullet;   
        }
    }
}
