using System;
using UI;
using UnityEngine;

public class UILifeManager : MonoBehaviour, IUILifeManager
{
    [SerializeField] private UILIfe[] _vetLife;
    [SerializeField] private Sprite _fullLife;
    [SerializeField] private Sprite _emptyLife;
    
    private IGameStatus _gameStatus;
    private int _currentLives;

    private void Awake()
    {
        ServiceLocator.RegisterService<IUILifeManager>(this);
    }

    private void Start()
    {
        _gameStatus = ServiceLocator.GetService<IGameStatus>();
        _currentLives = _vetLife.Length;
    }

    public void SetQtdLife(int qtdLife)
    {
        int count = _vetLife.Length - qtdLife;
        count = count > _vetLife.Length ? _vetLife.Length : count;
        
        for (int i = 0; i < count; i++)
        {
            _vetLife[i].SetImage(_emptyLife);
        }

        if (_currentLives <= 0)
        {
            _gameStatus.InvokeGameOverEvent();
        }
    }

    public void ResetLife()
    {
        for (int i = 0; i < _vetLife.Length; i++)
        {
            _vetLife[i].SetImage(_fullLife);
        }
    }
}