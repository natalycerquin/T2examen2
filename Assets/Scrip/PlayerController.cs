using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    SpriteRenderer renderer;
    int estado = 0;
    int salto = 2;
    float speed = 0.0f;

    public GameObject Disparo1;
    public GameObject Disparo2;
    public GameObject Disparo3;

    public Transform InicioDisparo;
    public float jumpSpeed = 1600.0f;

    float segundos = 0;
    public float contadorSegundos = 0;
    private int contador1 = 0;
    private int contador2 = 0;
    private int contado3 = 0;
    private bool state = false;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Transform transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        estado = 0;
        animator.SetInteger("Estado", estado);
        speed = 0.0f;
        state = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            state = true;
            renderer.flipX = false;
            speed = 7.0f;
            estado = 1;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetInteger("Estado", estado);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            state = true;
            renderer.flipX = true;
            speed = 7.0f;
            estado = 1;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.SetInteger("Estado", estado);
        }
        if (salto <= 1)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpSpeed);
                estado = 2;
                animator.SetInteger("Estado", estado);
                salto++;
                jumpSpeed = 800.0f;
            }

        }
        if (Input.GetKey(KeyCode.X))
        {
            estado = 3;
            animator.SetInteger("Estado",estado);
            contadorSegundos += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {

            animator.SetInteger("Estado", 0);

            contadorSegundos += Time.deltaTime;
            if (contadorSegundos <= 0.5)
            {
                Instantiate(Disparo1, InicioDisparo.position, Quaternion.Euler(0f, 0f, 0));
                contadorSegundos = 0;
            }

            if (contadorSegundos >= 0.5 && contadorSegundos <= 1.5)
            {
                Instantiate(Disparo2, InicioDisparo.position, Quaternion.Euler(0f, 0f, 0));
                contadorSegundos = 0;
            }

            if (contadorSegundos > 1.7)
            {
                Instantiate(Disparo3, InicioDisparo.position, Quaternion.Euler(0f, 0f, 0));
                contadorSegundos = 0;
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Preguntamos si nuestro personaje choca con el suelo
        if (collision.gameObject.tag == "Suelo")
        {
            // indicamos salto = 0
            salto = 0;
            // indicamos fuerza de salto 
            jumpSpeed = 1600.0f;
            // cambiamos de animacion a 0 (Idle)
            estado = 0;
        }
    }
}
