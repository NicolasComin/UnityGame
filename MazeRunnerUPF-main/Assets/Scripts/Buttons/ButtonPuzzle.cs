using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;

public class ButtonPuzzle : MonoBehaviour
{
    private int[] _correctSequence = { 1, 2, 3, 4 };
    private List<int> _playerSequence = new List<int>();
    [SerializeField] private Light[] greenLights;  // Luzes verdes
    [SerializeField] private Light[] redLights;    // Luzes vermelhas
    [SerializeField] private GameObject door;
    private int _currentIndex = 0;

    private void Start()
    {
        // Desliga todas as luzes verdes e vermelhas no início
        foreach (var l in greenLights)
        {
            l.enabled = false;
        }
        foreach (var l in redLights)
        {
            l.enabled = false;
        }
    }

    public void PressButton(int buttonIndex)
    {
        _playerSequence.Add(buttonIndex);
        
        if (buttonIndex == _correctSequence[_currentIndex]) 
        {
            Debug.Log("Sequência correta até agora. Botão " + buttonIndex);
            StartCoroutine(FlashGreenLightCoroutine(_currentIndex)); 
            _currentIndex++;
            
            if (_currentIndex == _correctSequence.Length)
            {
                Debug.Log("Sequência completa. Abrindo porta...");
                OpenDoor();
            }
        }
        else
        {
            Debug.LogWarning("Botão errado! Reiniciando o puzzle...");
            StartCoroutine(FlashRedLightsCoroutine()); 
        }
    }

    private void OpenDoor()
    {
        door.GetComponent<DoorAnimation>().OpenDoor();
        Debug.Log("Porta aberta!");
    }
    
    private IEnumerator FlashGreenLightCoroutine(int index)
    {
        greenLights[index].enabled = true;
        yield return new WaitForSeconds(0.3f); // Espera por 0.5 segundos
        greenLights[index].enabled = false;
    }

    // Corotina para piscar todas as luzes vermelhas ao mesmo tempo
    private IEnumerator FlashRedLightsCoroutine()
    {
        foreach (var light in redLights)
        {
            light.enabled = true;
        }
        yield return new WaitForSeconds(0.3f); // Espera por 0.5 segundos
        
        foreach (var light in redLights)
        {
            light.enabled = false;
        }
        ResetPuzzle();
    }

    private void ResetPuzzle()
    {
        // Reseta a sequência do jogador e o índice atual
        _playerSequence.Clear();
        _currentIndex = 0;
        
        foreach (var light in greenLights)
        {
            light.enabled = false;
        }
        foreach (var light in redLights)
        {
            light.enabled = false;
        }
        
        Debug.Log("Puzzle resetado. Índice atual: " + _currentIndex);
    }
}
