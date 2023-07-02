using ScriptableObjects;
using UI;
using UnityEngine;

namespace Stats
{
	public class PlayerStats : CharacterStats
	{
		[SerializeField] 
		private CharacterParameters characterParameters;
		[SerializeField] 
		private UIMainMenu mainMenu;
		private EnemyStats _enemyStats;

		public override void Awake()
		{
			base.Awake();
			MaximumHealth = CurrentHealth = characterParameters.HpAmount;
		}

		protected override void Die()
		{
			base.Die();
			mainMenu.OnPlayerDied();
		}
	}
}
