using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Stats
{
	public class EnemyStats : CharacterStats
	{
		[SerializeField] 
		private EnemyParameters enemyParameters;
		private UnityAction _onDied;
		public EnemyParameters EnemyParameters => enemyParameters;
		public override void Awake()
		{
			base.Awake();
			MaximumHealth = CurrentHealth = enemyParameters.HpAmount;
		}

		protected override void Die()
		{
			_onDied.Invoke();
			base.Die();
			Destroy(gameObject);
		}

		public void SetOnDied(UnityAction onDied)
		{
			_onDied = onDied;
		}
	
	}
}
