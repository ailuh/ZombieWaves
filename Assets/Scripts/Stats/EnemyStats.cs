using UnityEngine;

public class EnemyStats : CharacterStats
{
	[SerializeField] 
	private EnemyParameters enemyParameters;

	public EnemyParameters EnemyParameters => enemyParameters;
	public override void Awake()
	{
		base.Awake();
		CurrentHealth = enemyParameters.HpAmount;
	}
	public override void Die()
	{
		base.Die();
		Destroy(gameObject);
	}
}
