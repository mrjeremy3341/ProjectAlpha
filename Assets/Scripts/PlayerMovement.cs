using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;

    private float moveX;
    private float moveY;
    private const float speed = 200f;

    private bool isMovingX;
    private bool isMovingY;
    private bool wasMovingY;

    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() // Handle input for movement
    {
        // Get user input on both axis
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        // Set bools for which axis are moving
        isMovingX = Mathf.Abs(moveX) > 0.5f;
        isMovingY = Mathf.Abs(moveY) > 0.5f;
    }

    private void FixedUpdate() // Move the player in the world
    {
        // Check if the player is allowed to move
        if (canMove)
        {
            //Check if moving on both axis
            if (isMovingX && isMovingY)
            {
                anim.SetBool("PlayerMoving", true);
                if (wasMovingY)// Move on x axis
                {
                    body.velocity = new Vector2(moveX * speed * Time.deltaTime, 0f);
                    anim.SetFloat("MoveX", moveX);
                    anim.SetFloat("MoveY", 0f);
                    anim.SetFloat("LastMoveX", moveX);
                    anim.SetFloat("LastMoveY", 0f);
                }
                else // Move on y axis
                {
                    body.velocity = new Vector2(0f, moveY * speed * Time.deltaTime);
                    anim.SetFloat("MoveX", 0f);
                    anim.SetFloat("MoveY", moveY);
                    anim.SetFloat("LastMoveY", moveY);
                    anim.SetFloat("LastMoveX", 0f);
                }
            }
            else if (isMovingX) // Move on x axis
            {
                anim.SetBool("PlayerMoving", true);
                body.velocity = new Vector2(moveX * speed * Time.deltaTime, 0f);
                anim.SetFloat("MoveX", moveX);
                anim.SetFloat("MoveY", 0f);
                anim.SetFloat("LastMoveX", moveX);
                anim.SetFloat("LastMoveY", 0f);
                wasMovingY = false;
            }
            else if (isMovingY) // Move on y axis
            {
                anim.SetBool("PlayerMoving", true);
                body.velocity = new Vector2(0f, moveY * speed * Time.deltaTime);
                anim.SetFloat("MoveX", 0f);
                anim.SetFloat("MoveY", moveY);
                anim.SetFloat("LastMoveY", moveY);
                anim.SetFloat("LastMoveX", 0f);
                wasMovingY = true;
            }
            else // No Movement
            {
                anim.SetBool("PlayerMoving", false);
                body.velocity = Vector2.zero;
            }
        }
        else // No movmenet
        {
            anim.SetBool("PlayerMoving", false);
            body.velocity = Vector2.zero;
        }
    }
}
