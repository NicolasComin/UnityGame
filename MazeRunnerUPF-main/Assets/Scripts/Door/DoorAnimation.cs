using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour
{
    public Vector3 openPosition;  // Posição porta aberta
    public Vector3 closedPosition;  // Posição porta fechada
    public float speed = 2f;  
    private bool isOpen = false;

    void Start()
    {
        transform.position = closedPosition;
    }

    public void OpenDoor()
    {
        // Verifica se a porta já está aberta
        if (!isOpen)
        {
            StopAllCoroutines();  // Para animacao em execucao
            StartCoroutine(MoveDoor(openPosition));  // Inicia a animação para abrir
            isOpen = true;
        }
    }

    public void CloseDoor()
    {
        
        if (isOpen)
        {
            StopAllCoroutines(); 
            StartCoroutine(MoveDoor(closedPosition));  
            isOpen = false;
        }
    }
    
    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;  
    }
}