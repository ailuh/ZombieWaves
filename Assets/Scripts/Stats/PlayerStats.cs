using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public override void Die()
	{
		base.Die();
		mainMenu.OnPlayerDied();
	}
}
