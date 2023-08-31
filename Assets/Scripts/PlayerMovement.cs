using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Camera camera; 
    private new Rigidbody2D rigidbody;
    private Vector2 velocity;
    private float inputAxis;


    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight / (maxJumpTime / 2f));
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    public bool isGrounded { get; private set; }    
    public bool isJumping { get; private set; }





    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); 
        camera = Camera.main;
    }

    private void Update()
    {

        HorizontalMovement();
    }


    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftedge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightedge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        position.x = Mathf.Clamp(position.x, leftedge.x + 0.5f, rightedge.x - 0.5f);

        rigidbody.MovePosition(position);
    }






}



