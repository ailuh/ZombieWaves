using Core;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private float _speed;
   private float _lifeTime;
   private int _damage;
   private Transform _startPos;
   private Vector3 _direction;

   public void SetParameters (float speed, float lifetime, int damage, Transform startTransform)
   {
      _speed = speed;
      _lifeTime = lifetime;
      _damage = damage;
      _startPos = startTransform;
   }
   
   private void OnEnable()
   {
      if (_startPos != null)
      {
         _lifeTime = 5;
         transform.position = _startPos.position;
         _direction = _startPos.forward;
      }
   }

   private void Update()
   {
      
      transform.Translate(_direction * (Time.deltaTime * _speed));
      _lifeTime -= Time.deltaTime;
      if (_lifeTime <= 0)
      {
         Hide();
      }
   }

   private void Hide()
   {
      gameObject.SetActive(false);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.layer.Equals(Layers.Enemy))
      {
         other.GetComponent<CharacterStats>().TakeDamage(_damage);
         Hide();
      }
      
   }
   
}
