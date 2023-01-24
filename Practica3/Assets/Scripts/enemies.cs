using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
      // rb.velocity = new Vector2(1* velocity, rb.velocity.y);
       transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), velocity * Time.deltaTime) ;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyFlip"))
        {
            rend.flipX = true;
            velocity *= -1;
        }
    }
}
