using UnityEngine;
	using UnityEngine.Events;

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
	
	public override void Die()
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
