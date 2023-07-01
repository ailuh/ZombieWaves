using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
	
	public int CurrentHealth { get; set; }

	public virtual void Awake()
	{
	}

	public void TakeDamage (int damage)
	{
		damage = Mathf.Clamp(damage, 0, int.MaxValue);
		CurrentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");
		if (CurrentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die ()
	{
		Debug.Log(transform.name + " died.");
	}

}
