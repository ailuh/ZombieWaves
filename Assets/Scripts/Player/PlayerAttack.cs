using System;
using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private ObjectPoolManager _objectPool;

        public void OnInit(ObjectPoolManager objectPool)
        {
            _objectPool = objectPool;
        }
        
        public void OnAttack(InputAction.CallbackContext value)
        {
            _objectPool.RequestBullet();
        }
    }
}