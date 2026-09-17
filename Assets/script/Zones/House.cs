using UnityEngine;

public class House : MonoBehaviour, IInteractable
{
    public void Interact(player jugador)
    {
        if (jugador.HasFood)
        {
            jugador.WinGame();
        }
    }
}