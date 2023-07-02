using Enemy;
using Player;
using ScriptableObjects;
using UI;
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
      [SerializeField]
      private UIMainMenu mainMenu;
      [SerializeField] 
      private CharacterParameters characterParameters;
      private void Awake()
      {
         var cameraMain = Camera.main;
         var playerTransform = playerAttack.transform;
         playerControls.OnInit(playerAttack);
         playerMovement.OnInit(playerControls, characterParameters.Speed, cameraMain);
         poolManager.OnInit(bulletData, spawnPoint, playerControls, cameraMain);
         playerAttack.OnInit(poolManager, characterParameters.AttackCooldown);
         spawnController.OnInit(wavesData, playerTransform, mainMenu);
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
