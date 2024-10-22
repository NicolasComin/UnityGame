using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameWinPanel; 
    [SerializeField] private GameObject gameOverPanel; 
    [SerializeField] private GameObject lifeCanvas;
    [SerializeField] private GameObject level;
    private IGameStatus _gameStatus;

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
        gameWinPanel.SetActive(false);
    }

    private void HandleWinGame()
    {
        SetGameWinState();
    }
    
    private void HandleGameOver()
    {
        SetGameOverState();
    }

    //Aperta R para reiniciar o jogo
    private void Update()
    {
        if (gameOverPanel.activeSelf || gameWinPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();   
            }
        }
    }


    private void SetGameOverState()
    {
        lifeCanvas.SetActive(false); // Oculta a tela de vidas
        level.SetActive(false); // Pausa ou oculta o nível
        gameOverPanel.SetActive(true); // Exibe a tela de Game Over
        Time.timeScale = 0f; // Pausa o jogo

        Update();
    }
    
    private void SetGameWinState()
    {
        lifeCanvas.SetActive(false); // Oculta a tela de vidas
        level.SetActive(false); // Pausa ou oculta o nível
        gameWinPanel.SetActive(true); // Exibe a tela de Game Over
        Time.timeScale = 0f; // Pausa o jogo

        Update();
    }

    private void RestartGame(){
        Debug.Log("Reiniciando o jogo...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}