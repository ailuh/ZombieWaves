using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
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
    private UIProvider _uiProvider;
    
    private void Awake()
    {
        buttonsPanel.SetActive(true);
        start.onClick.AddListener(OnStart);
        restart.onClick.AddListener(OnReset);
        exit.onClick.AddListener(OnExit);
        mainText.text = "Try to win in zombie land!";
    }

    public void SetProvider(UIProvider uiProvider) => 
        _uiProvider = uiProvider;


    public void OnWaveStarted(int waveCount)
    {
        StartCoroutine(WaveStarted(waveCount));
    }
    
    private IEnumerator WaveStarted(int waveCount)
    {
        mainText.gameObject.SetActive(true);
        mainText.text = $"Wave {waveCount}";
        yield return new WaitForSeconds(5);
        mainText.gameObject.SetActive(false);
    }
        
    public void OnPlayerDied()
    {
        buttonsPanel.SetActive(true);
        restart.gameObject.SetActive(true);
        mainText.gameObject.SetActive(true);
        mainText.text = "You died!";
    }

    private void OnStart()
    {
        start.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        buttonsPanel.SetActive(false);
        _uiProvider.OnGameStarted();
    }

    private void OnReset() =>
        _uiProvider.OnReset();
    
    
    public void OnZombieDied(int remainingCount)
    {
        zombieCounter.text = $"Zombies remaining {remainingCount}";
    }
    
    public void OnWin()   
    {
        buttonsPanel.SetActive(true);
        mainText.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        restart.gameObject.SetActive(true);
        mainText.text = "Congratulation! You Win!";
    }
    
    private void OnExit() =>
        _uiProvider.Quit();
    
    
}
}

