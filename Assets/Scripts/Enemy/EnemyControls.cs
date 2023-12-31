using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyControls : MonoBehaviour
    {
        [SerializeField] 
        private NavMeshAgent meshAgent;
        private Transform _playerTransform;
        private float _speed;
        private bool _isDisabled;

        
        public void OnInit(Transform playerTransform, float speed)
        {
            meshAgent.SetDestination(playerTransform.position);
            _playerTransform = playerTransform;
            _speed  = meshAgent.speed = speed;
        }

        private void Update()
        {
            if (_isDisabled) return;
            var distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
            if (distanceToPlayer > 1.5 )
            {
                meshAgent.speed = _speed;
                meshAgent.SetDestination(_playerTransform.position);
            }
            else
            {
                meshAgent.speed = 0;
            }
        }

        public void OnDisableInput(bool isDisabled)
        {
            _isDisabled = isDisabled;
            meshAgent.enabled = !isDisabled;
        }
    }
}
