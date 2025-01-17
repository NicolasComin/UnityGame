﻿using System;
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
        _currentLives = _vetLife.Length; // Número inicial de vidas
    }

    public void SetQtdLife(int qtdLife)
    {
        _currentLives = qtdLife;
        int count = _vetLife.Length - qtdLife;
        count = count > _vetLife.Length ? _vetLife.Length : count;
        
        for (int i = 0; i < count; i++)
        {
            _vetLife[i].SetImage(_emptyLife);
        }

        if (_currentLives <= 0)
        {
            _gameStatus.InvokeGameOverEvent(); // Invoca o evento de Game Over
        }
    }

    public void ResetLife()
    {
        _currentLives = _vetLife.Length;
        for (int i = 0; i < _vetLife.Length; i++)
        {
            _vetLife[i].SetImage(_fullLife);
        }
    }
}