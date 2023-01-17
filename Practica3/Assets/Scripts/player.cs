using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocity = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    [Range(1, 1000)] public float jumpforce;
    private bool Grounded;
    private Animator animator;
    //public float Range 10;
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
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Debug.DrawRay(transform.position, Vector3.down * 0.62f, Color.blue);
      //  RaycastHit hit;
        if (Physics2D.Raycast(Vector3.down, Vector3.down, 0.62f))
        //{
       //     if (hit.collider.Comparetag("Tilemap"))
     //       {
     //           Debug.Log("Hit");
     //       }
      //  }
        {
            Grounded = true;
        }
        else Grounded = false;
        
     //   if (Input.GetKeyDown(KeyCode.Space) && Grounded)
    //   {
   //         Jump();
  //     }
        //  if (Input.GetKeyDown(KeyCode.A))
        //  {
        //     animator.Play("walk");
        //  }
    }
    void ProcessMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float movhor = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movhor * velocity, rb.velocity.y);
        if (movhor > 0)
        {
            animator.Play("walk");
            rend.flipX = false;
        }
        else if (movhor < 0)
        {
            animator.Play("idle");
            rend.flipX = true;
        }
    }
    void FixedUpdate()
    {
        ProcessMovement();

        if (Input.GetButton("Jump") && Grounded)
        {
      //      Jump();
                 rb.AddForce(Vector2.up * jumpforce);
            //    isJumping = true;
        }
    }
   //  void Jump()
  //  {
   //     Rigidbody2D rb = GetComponent<Rigidbody2D>();
   //     rb.AddForce(Vector2.up * jumpforce);
  // }
  //  bool Grounded() {

  //     if (Physics2D.RayCast(other.gameObject.compareTag("Tilemap"))) { 
  //      return true;
 //   }
 //       else {
 //        return false;
  //  }
  //  }

    //private void OnCollisionStay2D(Collision2D other)
   // {
      //  if (other.gameObject.CompareTag("Tilemap"))
   //     {
     //       isJumping = false;
     //       rb.velocity = new Vector2(rb.velocity.x, 0);
   //     }
   // }
 }