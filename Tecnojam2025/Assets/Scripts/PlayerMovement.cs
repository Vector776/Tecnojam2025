using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D playerRb;
    public Transform groundCheck;
    
    public float speed;
    public float jumpForce;
    public bool grounded;

    public void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        UpdateMovement();
        UpdateJump();
        CheckGround();
    }

    private void UpdateMovement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        

        if (Mathf.Abs(inputHorizontal) > 0)
        {
            playerRb.linearVelocity = new Vector2(inputHorizontal * speed, playerRb.linearVelocity.y);
        }

       
    }

    private void UpdateJump()
    {
        float inputVertical = Input.GetAxis("Vertical");
        
        if (Mathf.Abs(inputVertical) > 0 && grounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, inputVertical * jumpForce);
        }
    }

    private void CheckGround()
    {
        grounded = false;
        foreach (var col in Physics2D.OverlapCircleAll(groundCheck.position, 0.2f))
        {
            if (col.gameObject.layer == 7)
            {
                grounded = true;
                break;
            }
        }
    }
}