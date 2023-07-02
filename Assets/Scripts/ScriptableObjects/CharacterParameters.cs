using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "New Character Parameters", order = 4)]
    public class CharacterParameters : ScriptableObject
    {
        [SerializeField] 
        private int hpAmount;
        [SerializeField] 
        private float attackCooldown;
        [SerializeField] 
        private float speed;
        public int HpAmount => hpAmount;
        public float AttackCooldown => attackCooldown;
        public float Speed => speed;
    }
}
