using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private ButtonPuzzle _puzzleScript;  // Referência ao Puzzle
    [SerializeField] private int buttonIndex;  // Índice único para cada botão
    private bool _playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }

    private void Update()
    {
        // Jogador dentro do gatilho e pressionando "E"
        if (_playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (_puzzleScript != null)
            {
                _puzzleScript.PressButton(buttonIndex);
            }
        }
    }
}