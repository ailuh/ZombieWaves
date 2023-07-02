using System.Collections.Generic;
using Player;
using ScriptableObjects;
using UnityEngine;
using Weapon;

namespace Core
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private BulletData _bulletData;
        private List<GameObject> _bulletPool = new ();
        private Transform _spawnPoint;
        private PlayerControls _playerControls;
        private Camera _cameraMain;
    
        public void OnInit(BulletData bulletData, Transform spawnPoint, PlayerControls playerControls, Camera cameraMain)
        {
            _cameraMain = cameraMain;
            _spawnPoint = spawnPoint;
            _bulletData = bulletData;
            _playerControls = playerControls;
            _bulletPool = GenerateBullets(_bulletData.BulletsPoolNum);
        }
        
        private List<GameObject> GenerateBullets(int bulletNum)
        {
            for (int i = 0; i < bulletNum; i++)
            {
                var bullet = CreateBullet();
                _bulletPool.Add(bullet);
            }

            return _bulletPool;
        }

        public void RequestBullet()
        {
            foreach (var bullet in _bulletPool)
            {
                if (bullet.activeInHierarchy) continue;
                bullet.SetActive(true);
                return;
            }

            var newBullet = CreateBullet();
            _bulletPool.Add(newBullet);
        }

        private GameObject CreateBullet()
        {
            var bullet = Instantiate(_bulletData.BulletPrefab, _spawnPoint.position, Quaternion.identity);
            bullet.transform.parent = transform;
            bullet.GetComponent<Bullet>().SetParameters(_bulletData,_playerControls, _spawnPoint, _cameraMain);
            bullet.SetActive(false);
            return bullet;
        }
    }
}
