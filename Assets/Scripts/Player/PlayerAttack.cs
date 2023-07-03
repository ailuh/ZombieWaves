using Core;
using UnityEngine;  

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private BulletPoolManager _bulletPool;
        private bool _isHoldButton;
        private float _attackCoolDown;
        private float _currentCoolDown;

        public void OnInit(BulletPoolManager bulletPool, float attackCoolDown)
        {
            _attackCoolDown = _currentCoolDown = attackCoolDown;
            _bulletPool = bulletPool;
        }

        private void Update()
        {
            if (_isHoldButton)
            {
                if (_currentCoolDown <= 0)
                {
                    _bulletPool.PullBullet();
                    _currentCoolDown = _attackCoolDown;
                }
            }
            _currentCoolDown -= Time.deltaTime;
        }
        
        public void OnAttack()
        {
            _isHoldButton = true;
        }
        
        public void OnAttackCancelled()
        {
            _isHoldButton = false;
        }
    }
}