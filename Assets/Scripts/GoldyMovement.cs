using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldyMovement : MonoBehaviour
{

    private new Camera camera;
    private Vector2 velocity;

    private new Rigidbody2D rigidbody;
    public float MoveSpeed = 1f;
    public float JumpForce = 60f;
    public bool isJumping = false;
    public float moveHorizontal;
    public float moveVertical;
    public bool running => Mathf.Abs(moveHorizontal) > 0f;


    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal"); //left = a = -1, right = 'd' = 1, 0 = standing
        moveVertical = Input.GetAxisRaw("Vertical"); //

    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) // greater than epsilon
        {
            rigidbody.AddForce(new Vector2(moveHorizontal * MoveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (moveVertical > 0.1f && !isJumping) // greater than epsilon
        {
            rigidbody.AddForce(new Vector2(0f, moveVertical * JumpForce), ForceMode2D.Impulse);
        }

        
        //velocity.x = Mathf.MoveTowards(velocity.x, inputAxis* movement_speed, movement_speed * Time.deltaTime);
        velocity.x = Mathf.MoveTowards(velocity.x, moveHorizontal * MoveSpeed, MoveSpeed);
        //take care of rotate mario:
        if (velocity.x > 0)
        {
            transform.eulerAngles = Vector3.zero; // dont want any rotation
        }
        else if (velocity.x < 0f) //moving to the left
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true; ;
        }
    }


}
