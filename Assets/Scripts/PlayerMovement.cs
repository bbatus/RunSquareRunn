using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float runSpeed;
    [SerializeField] private float thrustForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    public bool grounded;
    bool gameOver = false;
    bool isDash = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (isDash == false)
        {
            JumpPlayer();
        }
        if (isDash == true)
        {
            ThrustMove();
        }
    }

    private void FixedUpdate()
    {
        InstantMove();
    }

    private void JumpPlayer()
    {
        if(gameOver == false) { 
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }
        }
    }

    private void InstantMove()
    {
        if(gameOver == false) { 
        rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            isDash = true;
            ThrustMove();
        }
    }

    private void ThrustMove()
    {
        if (gameOver == false)
        {
            StartThrust();
        }
    }

    private void StartThrust()
    {
        if (Input.GetMouseButton(0))
        {

            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { 
        grounded = true;
        }
    }

}
 
