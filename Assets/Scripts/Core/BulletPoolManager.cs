using System.Collections.Generic;
using Player;
using ScriptableObjects;
using UnityEngine;
using Weapon;
namespace Core
{
    public class BulletPoolManager : MonoBehaviour
    {
        private BulletData _bulletData;
        private List<GameObject> _bulletPool = new ();
        private Transform _spawnPoint;
        private PlayerControls _playerControls;
        private Camera _cameraMain;
        public delegate void EventHandler(GameObject bullet);
        public event EventHandler OnBulletHide;
    
        public void OnInit(BulletData bulletData, Transform spawnPoint, PlayerControls playerControls, Camera cameraMain)
        {
            _cameraMain = cameraMain;
            _spawnPoint = spawnPoint;
            _bulletData = bulletData;
            _playerControls = playerControls;
            OnBulletHide += PushBullet;
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

        public void PullBullet()
        {
            if (_bulletPool.Count > 0)
            {
                var bull = _bulletPool[0];
                _bulletPool.RemoveAt(0);
                bull.SetActive(true);
                return;
            }

            CreateBullet();
        }

        private void PushBullet(GameObject bullet)
        {
            Debug.Log("delegate works");
            bullet.SetActive(false);
            bullet.transform.SetParent(transform);
            _bulletPool.Add(bullet);
        }
        
        private GameObject CreateBullet()
        {
            var bullet = Instantiate(_bulletData.BulletPrefab, _spawnPoint.position, Quaternion.identity);
            bullet.transform.SetParent(transform);
            bullet.GetComponent<Bullet>().SetParameters(_bulletData,_playerControls, _spawnPoint, _cameraMain, OnBulletHide);
            bullet.SetActive(false);
            return bullet;
        }
    }
}
