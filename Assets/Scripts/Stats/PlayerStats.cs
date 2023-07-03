using ScriptableObjects;
using UI;
using UnityEngine;

namespace Stats
{
	public class PlayerStats : CharacterStats
	{
		[SerializeField] 
		private CharacterParameters characterParameters;
		private UIProvider _uiProvider;
		private EnemyStats _enemyStats;

		public void SetProvider(UIProvider uiProvider) => 
			_uiProvider = uiProvider;
		
		public override void Awake()
		{
			base.Awake();
			MaximumHealth = CurrentHealth = characterParameters.HpAmount;
		}

		protected override void Die()
		{
			base.Die();
			_uiProvider.OnPlayerDied();
		}
	}
}
