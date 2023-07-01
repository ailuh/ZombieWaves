using Player;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
   public class EntryPoint : MonoBehaviour
   {
      [SerializeField] 
      private PlayerControls playerControls;
      [SerializeField] 
      private PlayerMovement playerMovement;
      [SerializeField] 
      private PlayerAttack playerAttack;
      [SerializeField] 
      private BulletData bulletData;
      [SerializeField] 
      private ObjectPoolManager poolManager;
      [SerializeField] 
      private Transform spawnPoint;
      [SerializeField] 
      private EnemySpawnController spawnController;
      [SerializeField] 
      private WavesData wavesData;

      private void Awake()
      {
         var playerTransform = playerAttack.transform;
         playerControls.OnInit(playerAttack);
         playerMovement.OnInit(playerControls);
         poolManager.OnInit(bulletData, spawnPoint);
         playerAttack.OnInit(poolManager);
         spawnController.OnInit(wavesData, playerTransform);
      }

      private void OnEnable()
      {
         playerControls.Enable();
      }

      private void OnDisable()
      {
         playerControls.Disable();
      }
   }
}
