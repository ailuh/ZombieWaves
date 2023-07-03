using Enemy;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIProvider
    {
        private EnemySpawnController _spawnController;
        private UIMainMenu _mainMenu;
        private PlayerControls _playerControls;


        public void OnInit(EnemySpawnController spawnController, UIMainMenu mainMenu, PlayerControls playerControls)
        {
            _spawnController = spawnController;
            _mainMenu = mainMenu;
            _playerControls = playerControls;
            _mainMenu.SetProvider(this);
            DisableInputs(true);
        }

        public void OnGameStarted()
        {
            DisableInputs(false);
            _spawnController.StartSpawning();
        }
        

        public void OnWaveSpawn(int currentWave) =>
            _mainMenu.OnWaveStarted(currentWave + 1);
        

        public void OnZombieDied(int zombieCount) =>
            _mainMenu.OnZombieDied(zombieCount);
        
        
        public void Quit() => 
            Application.Quit();

        public void OnWin()
        {
            DisableInputs(true);
            _mainMenu.OnWin();;
        }

        public void OnPlayerDied()
        {
            DisableInputs(true);
            _mainMenu.OnPlayerDied();
        }

        public void OnReset() =>
            SceneManager.LoadScene(0);

        private void DisableInputs(bool isDisabled)
        {
            _playerControls.OnInputDisable(isDisabled);
            _spawnController.DisableEnemyInput(isDisabled);
        }
    }
}
