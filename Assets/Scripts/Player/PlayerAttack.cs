using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private ObjectPoolManager _objectPool;
        private bool _isHoldButton;
        private float _attackCoolDown;
        private float _currentCoolDown;
        public void OnInit(ObjectPoolManager objectPool, float attackCoolDown)
        {
            _attackCoolDown = _currentCoolDown = attackCoolDown;
            _objectPool = objectPool;
        }

        private void Update()
        {
            if (_isHoldButton)
            {
                if (_currentCoolDown <= 0)
                {
                    _objectPool.RequestBullet();
                    _currentCoolDown = _attackCoolDown;
                }
            }
            _currentCoolDown -= Time.deltaTime;
        }

        public void OnAttack(InputAction.CallbackContext value)
        {
            _isHoldButton = true;
        }
        
        public void OnAttackCancelled(InputAction.CallbackContext value)
        {
            _isHoldButton = false;
        }
    }
}