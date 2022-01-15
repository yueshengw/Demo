using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{    
    public float moveSpeed;
    public float moveSpeed_copy;
    public float jump;
    float moveVelocity;

    public bool grounded;

    public bool dead;

    public Rigidbody2D rb2d;

    public float moveSpeed1;

    public float moveInput;
    
    public int jumpNumber;
    public Vector3 moveForce;

    public GameObject Player;

    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed_copy = moveSpeed;
    }
    void Update () 
    {
        moveVelocity = 0;

        if (Input.GetKey(KeyCode.A)) 
        {
            moveVelocity = - moveSpeed;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //transform.position += Vector3.down * 10.0f;
            rb2d.MovePosition(transform.position + (Vector3.down * 2.0f));
        }

        if (Input.GetKey(KeyCode.Space) && grounded) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }

        if (Input.GetKey(KeyCode.K) && !grounded && !Input.GetKey(KeyCode.Space)) 
        {
            rb2d.gravityScale = 1.0f;
            moveSpeed = moveSpeed_copy * 1.2f;
        }
        else
        {
            rb2d.gravityScale = 5.0f;
            moveSpeed = moveSpeed_copy;
        }

        if (Input.GetKey(KeyCode.Q)) 
        {
            transform.position = new Vector3(-19.9f, 44.8f, 0f);
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        moveForce = new Vector3(moveInput * moveSpeed1, rb2d.velocity.y, 0);
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (moveInput == 1) {
            rb2d.MovePosition(transform.position + (Vector3.right * 10.0f));
            }
            else if (moveInput == -1)
            //transform.position += Vector3.left * 10.0f;
            rb2d.MovePosition(transform.position + (Vector3.left * 10.0f));
        }

        rb2d.velocity = new Vector2 (moveVelocity, rb2d.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Death")
        {
            dead = true;
        }
        if (collider.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Death")
        {
            dead = true;
        }
        if (collider.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D()
    {
        grounded = false;
    }
}
