using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] 
    private GameObject buttonsPanel;
    [SerializeField] 
    private Button start;
    [SerializeField] 
    private Button restart;
    [SerializeField] 
    private Button exit;
    [SerializeField] 
    private TMP_Text mainText;
    [SerializeField] 
    private TMP_Text zombieCounter;

    private EnemySpawnController _spawnController;
    private void Awake()
    {
        buttonsPanel.SetActive(true);
        start.onClick.AddListener(OnStart);
        restart.onClick.AddListener(OnReset);
        exit.onClick.AddListener(OnExit);
        Time.timeScale = 0;
        mainText.text = "Try to win in zombie lands!";
    }

    public void SetSpawnController(EnemySpawnController spawnController) => 
        _spawnController = spawnController;

    public IEnumerator OnWaveStarted(int waveCount)
    {
        mainText.gameObject.SetActive(true);
        mainText.text = $"Wave {waveCount}";
        Time.timeScale = 1;
        yield return new WaitForSeconds(5);
        mainText.gameObject.SetActive(false);
    }
        
    public void OnPlayerDied()
    {
        Time.timeScale = 0;
        buttonsPanel.SetActive(true);
        restart.gameObject.SetActive(true);
        mainText.gameObject.SetActive(true);
        mainText.text = "You win!";
    }

    private void OnStart()
    {
        start.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        buttonsPanel.SetActive(false);
        Time.timeScale = 1;
        _spawnController.StartSpawning();
    }
    
    private void OnReset()
    {
    }
    
    public void OnZombieDied(int remaningCount)
    {
        zombieCounter.text = $"Zombies remaning {remaningCount}";
    }
    
    public void OnWin()   
    {
        buttonsPanel.SetActive(true);
        mainText.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        restart.gameObject.SetActive(true);
        Time.timeScale = 0;
        mainText.text = "Congratulation! You Win!";
    }
    
    private void OnExit()   
    {
        Application.Quit();
    }
}
