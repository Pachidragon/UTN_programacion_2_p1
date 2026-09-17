using UnityEngine;

public class sigueAlJugador : MonoBehaviour

{
    public Transform jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // sigue la camara al jugador
        transform.position = new Vector3(jugador.position.x, 0,-10);
    }


}
