using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float velocity = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    [Range(1, 500)] public float jumpforce;
    bool isJumping = false;
    private Animator animator;
    public AudioClip jumpclip;
    public AudioClip deathclip;
    public AudioClip background;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AudioManager.instance.PlayAudioOnLoop(background, 1); //Inovcamos el Sonido Ambiente en el player para que el sonido siga al jugador.
    }

    // Update is called once per frame
    void Update()
    {
        rend = GetComponent<SpriteRenderer>();
        ProcessMovement();

        if (Input.GetButton("Jump") && !isJumping) // Si pulsamos el botón de salto y !isJumping permite el salto pone el isJumping en TRUE, y reproduce el PlayAudio.
        {
            rb.AddForce(Vector2.up * jumpforce);
            isJumping = true;
            AudioManager.instance.PlayAudio(jumpclip, 1);

        }
    }
    void ProcessMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); 
        float movhor = Input.GetAxisRaw("Horizontal"); //Si pulsamos los botones designados al Axis Horizontal, se inicia el movimiento del personaje.
        rb.velocity = new Vector2(movhor * velocity, rb.velocity.y);
        animator.SetBool("walking", movhor != 0.0f); //Si se mueve el personaje, que el setBool se active "walking".

        if (movhor > 0)
        {
            rend.flipX = false; 
        }
        else if (movhor < 0)
        {
            rend.flipX = true; //si el movhor es mayor que 0 el personaje gira.
        }
    }
    void FixedUpdate()
    {
        if (isJumping == true)
        {
            animator.Play("jump"); //Si isJumping esta en TRUE se inicia la animacion "Jump".
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tilemap")) //Si El jugador tiene contacto con el Tilemap isJumping se pone en FALSE.
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemies"))
        {
            AudioManager.instance.PlayAudio(deathclip, 1); //Si el player choca con enemigos invoca death() con un timer de 3 seg, y reproduce el audio de muerte.
            Invoke("death", 3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Deathzone"))
        {
            AudioManager.instance.PlayAudio(deathclip, 1); //Si el player se cae invoca death() con un timer de 2 seg, y reproduce el audio de muerte.
            Invoke("death", 2);
        }
    }
    public void death() //Al invocarse death(), limpia la lista de sonidos, Invoca el ResetTimer en 0,1seg, y carga la escena reiniciando el nivel.
    {
        GameManager.instance.ResetPunt(0);
        AudioManager.instance.ClearAudioList();
        Invoke("ResetTimer", 0.1f);
        SceneManager.LoadScene("Level1");
    }
}