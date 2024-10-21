using System;
using UI;
using UnityEngine;

public class UILifeManager : MonoBehaviour, IUILifeManager
{
    [SerializeField] private UILIfe[] _vetLife;
    [SerializeField] private Sprite _fullLife;
    [SerializeField] private Sprite _emptyLife;

    private void Awake()
    {
        ServiceLocator.RegisterService<IUILifeManager>(this);
    }

    public void SetQtdLife(int qtdLife)
    {
        int count = _vetLife.Length - qtdLife;
        count = count > _vetLife.Length ? _vetLife.Length : count;
        
        for (int i = 0; i < count; i++)
        {
            _vetLife[i].SetImage(_emptyLife);
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