using UnityEngine;
using TMPro; // para usar el texto en pantalla
using UnityEngine.SceneManagement;


public class player : Character
{
    private Rigidbody2D rb;
    
    // estados
    private bool isInGround = false;
    private bool hasFood = false;
    private bool win = false;
    private bool lose= false;    
    
    // tiempo
    private float remainingTime = 30f;

    // UI
    [SerializeField] private TextMeshProUGUI stateText;
    public bool HasFood
    {
        get { return hasFood; }
    }

    public void GetFood()
    {
        hasFood = true;
    }

    public void WinGame()
    {
        win = true;
    }


    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        HandleMovement();
        HandleAnimation();
        HandleGameState();

    }

    private void HandleMovement() // movimiento del jugador
    {

        if (Input.GetKey(KeyCode.A)) // izquierda
        {
            transform.Translate(-10f * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(5.68016f, 5.650067f, 1);
        }

        if (Input.GetKey(KeyCode.D)) // derecha
        {
            transform.Translate(10f * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-5.68016f, 5.650067f, 1);
        }


        if (Input.GetKeyDown(KeyCode.W) && isInGround) // salto
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6.5f);
        }
    }

    private void HandleAnimation() // animaciones

    {
        anim.SetBool("Run", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)); // correr
        anim.SetBool("Jump", Input.GetKeyDown(KeyCode.W) || !isInGround); // saltar

    }

    private void HandleGameState() // Estado del juego

    {

        if (hasFood && !win && !lose)
        {
            remainingTime -= Time.deltaTime; // Tiempo restante

        }

        if (remainingTime <= 0 && !win && !lose)

        {
            lose = true;
        }

        if (!hasFood)
        {
            stateText.text = "-> Andá a buscar la comida al restaurante :D ";
        }
        else if (lose)
        {
            stateText.text = "Se enfrío la comida :( ";
            SceneManager.LoadScene("lose");
        }
        else if (win)
        {
            stateText.text = "Muchas gracias, Buen provecho :D";
            SceneManager.LoadScene("win");
        }
        else
        {
            stateText.text = "<- Volve antes de que se enfrie :O \n Tiempo = " + remainingTime.ToString("F0");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isInGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isInGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.Interact(this);
        }
    }


}

