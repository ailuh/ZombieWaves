using Core;
using Stats;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] 
        private EnemyStats enemyStats;
        private float _damage;
        private float _attackDelay;
        private float _currentDelay;
        private float _radius;
        private CharacterStats _characterStats;
        private readonly Collider[] _hits = new Collider[5];
        private Ray _ray;
        private Vector3 _sphereShift;
        private LayerMask _layers;
        private bool _isInputDisabled;
    
        private void Awake()
        {
            _damage = enemyStats.EnemyParameters.Damage;
            _radius = enemyStats.EnemyParameters.AttackRadius;
            _attackDelay = enemyStats.EnemyParameters.AttackCooldown;
            _layers = enemyStats.EnemyParameters.Layers;
            _currentDelay = _attackDelay;
        }

        private void Update()
        {
            if (_isInputDisabled) return;;
            if (_currentDelay <= 0)
            {
                _sphereShift = transform.position + new Vector3(0,0,0.5f);
                var numColliders = Physics.OverlapSphereNonAlloc(_sphereShift, _radius, _hits, _layers);
                if (numColliders > 0)
                {
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

        public void OnInputDisable(bool isDisabled) => _isInputDisabled = isDisabled;
        }
    
}
