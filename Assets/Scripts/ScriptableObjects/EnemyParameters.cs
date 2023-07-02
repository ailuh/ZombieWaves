using Core;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "New Enemy Parameters", order = 5)]
public class EnemyParameters : CharacterParameters
{
   [SerializeField] 
   private float attackRadius;
   [SerializeField] 
   private float attackCooldown;
   [SerializeField]
   private int damage;
   [SerializeField]
   private LayerMask ignoredLayers;

   public float AttackRadius => attackRadius;
   public float AttackCooldown => attackCooldown;
   public float Damage => damage;
   public LayerMask IgnoredLayers => ignoredLayers;
   
}
