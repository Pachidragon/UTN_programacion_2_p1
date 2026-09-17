using UnityEngine;

public class Restaurant : MonoBehaviour, IInteractable
{
        public void Interact(player jugador)
    {
        jugador.GetFood();
        GameManager.Instance.StartTimer();
        
    }
}