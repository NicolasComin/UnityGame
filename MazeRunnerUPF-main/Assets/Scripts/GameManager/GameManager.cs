using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    private IGameStatus _gameStatus;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject heartsCanvas;
    private void Awake()
    {
        ServiceLocator.Reset();

        _gameStatus = new GameStatus();
        ServiceLocator.RegisterService(_gameStatus);
        ServiceLocator.RegisterService<ICheckPointSystem>(new CheckPointSystem());
    }
    
    void Start()
    {
        _gameStatus.OnWinGame += HandleWinGame;
        _gameStatus.OnGameOver += HandleGameOver;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void Update()
    {
        if (gameOverPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Reiniciando game");
                RestartGame();
            }
        }
    }

    private void HandleWinGame()
    {
        SetWinScreen();
    }

    private void SetWinScreen()
    {
        heartsCanvas.SetActive(false);
        level.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        
        Update();
    }

    private void HandleGameOver()
    {
        SetGameOver();
    }

    private void SetGameOver()
    {
        heartsCanvas.SetActive(false);
        level.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        
        Update();
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
    
}