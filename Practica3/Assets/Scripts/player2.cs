using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour
{
    public float velocity = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    [Range(1, 500)] public float jumpforce;
    bool isJumping = false;
    private Animator animator;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        }
    }
    void ProcessMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float movhor = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movhor * velocity, rb.velocity.y);

        if (movhor > 0)
        {
            rend.flipX = false;
        }
        else if (movhor < 0)
        {
            animator.Play("walk");
            rend.flipX = true;
        }
    }
    void FixedUpdate()
    {

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}