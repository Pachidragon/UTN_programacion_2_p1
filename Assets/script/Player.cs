using UnityEngine;
using TMPro; // para usar el texto en pantalla
using UnityEngine.SceneManagement;


public class jugador : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    // estados
    bool estaEnElSuelo = false;
    bool tieneElPedido = false;
    bool gano = false;
    bool perdio = false;    
    
    // tiempo
    float tiempoRestante = 30f;
    public TextMeshProUGUI textoEstado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimientos

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-10f * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(5.68016f, 5.650067f, 1);
        }

        if (Input.GetKey(KeyCode.D))
        { 
            transform.Translate(10f * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-5.68016f, 5.650067f, 1);
        }


        if (Input.GetKeyDown(KeyCode.W) && estaEnElSuelo)
            {
             rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6.5f);
            }

        // Animaciones

        anim.SetBool("corriendo",
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        anim.SetBool("saltando", 
            Input.GetKeyDown(KeyCode.W) || !estaEnElSuelo);  



        // Estados y mensajes

        if (tieneElPedido && !gano && !perdio)
        {
            tiempoRestante = tiempoRestante - Time.deltaTime;
            
        }

        if (tiempoRestante <= 0 && !gano && !perdio)

        { 
            perdio = true;
        }

        if (!tieneElPedido)
        {
            textoEstado.text = "-> Andá a buscar la comida al restaurante :D ";
        }
        else if (perdio)
        {
            textoEstado.text = "Se enfrío la comida :( ";
            SceneManager.LoadScene("derrota");
        }
        else if (gano)
        {
            textoEstado.text = "Muchas gracias, Buen provecho :D";
            SceneManager.LoadScene("victoria");
        }
        else
        {
            textoEstado.text = "<- Volve antes de que se enfrie :O \n Tiempo = " + tiempoRestante.ToString("F0");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnElSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnElSuelo = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Local"))
        {
            tieneElPedido = true;
                   }

        if (other.CompareTag("Casa") && tieneElPedido)
        {
            gano = true;         

        }
    }

    
}
