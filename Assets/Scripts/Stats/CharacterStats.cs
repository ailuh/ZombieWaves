using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stats
{
	public class CharacterStats : MonoBehaviour
	{

		[FormerlySerializedAs("healthView")] [SerializeField] private UIHealthManager alwaysToPlayer;
		protected float CurrentHealth { get; set; }
		protected float MaximumHealth { get; set; }

		public virtual void Awake()
		{
		}

		public void TakeDamage(float damage)
		{
			damage = Mathf.Clamp(damage, 0, int.MaxValue);
			CurrentHealth -= damage;
			if (CurrentHealth <= 0)
			{
				Die();
			}

			var fillAmount = CurrentHealth / MaximumHealth;
			alwaysToPlayer.UpdateHealth(fillAmount);
		}

		protected virtual void Die()
		{
		}
	}
}

