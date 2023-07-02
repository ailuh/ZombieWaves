using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour {
	
	[SerializeField] 
	private UIHealthView healthView;
	protected float CurrentHealth { get; set; }
	protected float MaximumHealth { get; set; }

	public virtual void Awake()
	{
	}

	public void TakeDamage (float damage)
	{
		damage = Mathf.Clamp(damage, 0, int.MaxValue);
		CurrentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");
		if (CurrentHealth <= 0)
		{
			Die();
		}
		var fillAmount = CurrentHealth / MaximumHealth;
		healthView.UpdateHealth(fillAmount);
	}

	public virtual void Die ()
	{
		Debug.Log(transform.name + " died.");
	}

}
