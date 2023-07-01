using System;
using Core;
using UnityEngine;

namespace Enemy
{
    public class DealDamage : MonoBehaviour
    {
        [SerializeField] 
        private EnemyStats _enemyStats;
        private int _damage;
        private float _attackDelay;
        private float _currentDelay;
        private float _radius;
        private CharacterStats _characterStats;
        private readonly Collider[] _hits = new Collider[5];
        private Ray _ray;
        private Vector3 _sphereShift;
        private LayerMask _layers;
    
        private void Awake()
        {
            _damage = _enemyStats.EnemyParameters.Damage;
            _radius = _enemyStats.EnemyParameters.AttackRadius;
            _attackDelay = _enemyStats.EnemyParameters.AttackCooldown;
            _layers = _enemyStats.EnemyParameters.IgnoredLayers;
            _currentDelay = _attackDelay;
        }

        private void Update()
        {
            if (_currentDelay <= 0)
            {
                _sphereShift = transform.position + Vector3.forward;
                var numColliders = Physics.OverlapSphereNonAlloc(_sphereShift, _radius, _hits, _layers);
                if (numColliders > 0)
                {
                    Debug.Log(numColliders);
                    for (int i = 0; i < numColliders; i++)
                    {
                        if (_hits[i].gameObject.layer.Equals(Layers.Player))
                        {
                            _hits[i].gameObject.GetComponent<PlayerStats>().TakeDamage(_damage);
                        }
                    }
                }

                _currentDelay = _attackDelay;
            }
            _currentDelay -= Time.deltaTime;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(_sphereShift, _radius);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, Vector3.forward);
        }
    }
    
}
