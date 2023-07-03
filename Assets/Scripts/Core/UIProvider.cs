using Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIProvider
    {
        private EnemySpawnController _spawnController;
        private UIMainMenu _mainMenu;


        public void OnInit(EnemySpawnController spawnController, UIMainMenu mainMenu)
        {
            _spawnController = spawnController;
            _mainMenu = mainMenu;
            _mainMenu.SetProvider(this);
        }

        public void OnGameStarted() =>
            _spawnController.StartSpawning();
        

        public void OnWaveSpawn(int currentWave) =>
            _mainMenu.OnWaveStarted(currentWave + 1);
        

        public void OnZombieDied(int zombieCount) =>
            _mainMenu.OnZombieDied(zombieCount);
        
        
        public void Quit() => 
            Application.Quit();

        public void OnWin() => 
            _mainMenu.OnWin();

        public void OnPlayerDied() =>
            _mainMenu.OnPlayerDied();

        public void OnReset() =>
            SceneManager.LoadScene(0);
    }
}
