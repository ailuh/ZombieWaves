using Core;
using Player;
using ScriptableObjects;
using Stats;
using UnityEngine;

namespace Weapon
{
   public class Bullet : MonoBehaviour
   {
      private float _speed;
      private float _lifeTime;
      private float _damage;
      private PlayerControls _playerControls;
      private Vector3 _direction;
      private Transform _startPosition;
      private Camera _cameraMain;

      public void SetParameters(BulletData bulletData, PlayerControls playerControls,
         Transform startPosition, Camera cameraMain)
      {
         _cameraMain = cameraMain;
         _speed = bulletData.Speed;
         _lifeTime = bulletData.LifeTime;
         _damage = bulletData.Damage;
         _playerControls = playerControls;
         _startPosition = startPosition;
      }
   
      private void OnEnable()
      {
         if (_startPosition != null)
         {
            var startPosition = transform.position = _startPosition.position;
            _lifeTime = 5;
            var ray = _cameraMain.ScreenPointToRay(_playerControls.LookDirection);
            if (Physics.Raycast(ray, out var hit, 100))
            {
               var lookPos = hit.point;
               var lookDir = lookPos - startPosition;
               lookDir.y = 0;
               transform.LookAt(startPosition + lookDir, Vector3.up);
            }
         }
      }
   
      private void Update()
      {
      
         transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
         _lifeTime -= Time.deltaTime;
         if (_lifeTime <= 0)
         {
            Hide();
         }
      }

      private void Hide()
      {
         gameObject.SetActive(false);
      }

      private void OnTriggerEnter(Collider other)
      {
         if (other.gameObject.layer.Equals(Layers.Enemy))
         {
            other.GetComponent<CharacterStats>().TakeDamage(_damage);
            Hide();
         }
      
      }
   
   }
}
