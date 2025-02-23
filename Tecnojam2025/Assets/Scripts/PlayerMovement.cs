using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D playerRb;
    
    [SerializeField] private Transform groundCheck;
    
    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool grounded;
    [SerializeField] private bool jumping;
    private float jumpTimer;

    public void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        UpdateMovement();
        CheckJumpBuffer();
        UpdateJump();
        CheckGround();
    }

    private void CheckJumpBuffer()
    {
        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer < 0)
            {
                jumpTimer = 0;
            }
        }

        if (jumpTimer <= 0 && grounded)
        {
            jumping = false;
        }
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
        
        if (!jumping && Mathf.Abs(inputVertical) > 0 && grounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
            jumping = true;
            jumpTimer = 0.3f;
        }
    }

    private void CheckGround()
    {
        
        
        grounded = false;
        foreach (var col in Physics2D.OverlapCircleAll(groundCheck.position, 0.02f))
        {
            if (col.gameObject.layer == 7)
            {
                grounded = true;
                break;
            }
        }
    }

   
}