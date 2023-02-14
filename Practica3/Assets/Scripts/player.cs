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
        AudioManager.instance.PlayAudioOnLoop(background, 1);
    }

    // Update is called once per frame
    void Update()
    {
        rend = GetComponent<SpriteRenderer>();
        ProcessMovement();

        if (Input.GetButton("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpforce);
            isJumping = true;
            AudioManager.instance.PlayAudio(jumpclip, 1);

        }
    }
    void ProcessMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float movhor = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movhor * velocity, rb.velocity.y);
        animator.SetBool("walking", movhor != 0.0f);

        if (movhor > 0)
        {
            rend.flipX = false;
        }
        else if (movhor < 0)
        {
            rend.flipX = true;
        }
    }
    void FixedUpdate()
    {
        if (isJumping == true)
        {
            animator.Play("jump");
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tilemap"))
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemies"))
        {
            AudioManager.instance.PlayAudio(deathclip, 1);
            Invoke("death", 3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Deathzone"))
        {
            AudioManager.instance.PlayAudio(deathclip, 1);
            Invoke("death", 2);
        }
    }
    public void death()
    {
        AudioManager.instance.ClearAudioList();
        Invoke("ResetTimer", 0.1f);
        SceneManager.LoadScene("Level1");
    }
}