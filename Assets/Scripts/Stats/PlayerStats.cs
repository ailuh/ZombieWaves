using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
	[SerializeField] 
	private CharacterParameters characterParameters;
	private EnemyStats _enemyStats;

	public override void Awake()
	{
		base.Awake();
		CurrentHealth = characterParameters.HpAmount;
	}

	public override void Die()
	{
		base.Die();
		//PlayerManager.instance.KillPlayer();
	}
}
