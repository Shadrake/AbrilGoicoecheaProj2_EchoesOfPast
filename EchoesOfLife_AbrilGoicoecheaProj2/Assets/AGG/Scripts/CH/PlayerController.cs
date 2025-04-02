using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Movimiento del personaje
    public float speed, jumpForce = 200f;
    float velX, velY;
    Rigidbody2D _rbPlayer;

    // Detección del suelo
    public Transform groundCheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    // Disparo
    [Header("Bullet Settings")]
    public GameObject projectilePrefab; 
    private float lastTimeShoot; 
    public float timeDelayShoot = 0.25f; 
    public GameObject weaponPositionInstantiate;

    // Animaciones
    [Header("Component Settings")]
    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        // Almacenamos el componente en la variable correspondiente.
        _rbPlayer = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Averiguamos si está en contacto con el suelo.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        FlipCharacter();

        if(Input.GetButton("Fire1") && (Time.time > lastTimeShoot * timeDelayShoot))
        {
            Shoot();
            lastTimeShoot = Time.time;
        }
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
        velY = _rbPlayer.velocity.y;

        _rbPlayer.velocity = new Vector2(velX * speed, velY);
    }

     public void FlipCharacter()
    {
        // Rotamos el personaje cuando cambia de dirección.
        if((_rbPlayer.velocity.x > 0)||velX ==1)
        {
            transform.localScale = new Vector3(1,1,1);//md
        }

        else if(Input.GetAxisRaw("Horizontal")==-1)
        {
            transform.localScale = new Vector3(-1,1,1);//mi
        }
    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            _rbPlayer.AddForce(Vector2.up * jumpForce);
        }
    }

    public void Shoot()
    {
        Vector3 direction;

        if(transform.localScale.x == 1.0f)
        {
            direction = Vector3.right; //dcha
        }
        else
        {
            direction = Vector3.left; //izq
        }

        GameObject projectile = Instantiate(projectilePrefab,
        weaponPositionInstantiate.transform.position + direction * 0.01f, Quaternion.identity);

        projectile.GetComponent<PlayerProjectile>().SetDirection(direction);
    }
}
