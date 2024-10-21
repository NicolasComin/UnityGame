using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    }

    private void HandleWinGame()
    {
        SceneManager.LoadScene(0);
    }
    
    private void HandleGameOver()
    {
        
    }
}