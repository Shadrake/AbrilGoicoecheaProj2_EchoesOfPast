using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    // Movimiento del personaje
    public float speed, jumpHeight;
    float velX, velY;
    Rigidbody2D rb;

    // Detección del suelo
    public Transform groundCheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    // Animaciones
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Almacenamos el componente en la variable correspondiente.
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Averiguamos si está en contacto con el suelo.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        FlipCharacter();
    }

    // Lo que tenga que ver con físicas es mejor en el FixedUpdate. Por tema de frames evita que en cada ordenador se vea diferente.
    private void FixedUpdate()
    {
        Movement();
        Jump();   
    }

    /* MOVIMIENTO DE PERSONAJE */
    public void Movement()
    {
        // Hacemos que se mueva correctamente al pulsar las teclas de movimiento
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);
    }

     public void FlipCharacter()
    {
        // Rotamos el personaje cuando cambia de dirección.
        if((rb.velocity.x > 0)||velX ==1)
        {
            transform.localScale = new Vector3(1,1,1);//md
        }
        else
            if(Input.GetAxisRaw("Horizontal")==-1)
        {
            transform.localScale = new Vector3(-1,1,1);//mi
        }
    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
}
