using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Vector2 moveInput;
    public Vector2 posicion;
    private Rigidbody2D playerRb;
    

    public void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.MovePosition(new Vector2(0, 0));
    }

    public void Update()
    {

        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(inputHorizontal, inputVertical).normalized;

    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * Time.fixedDeltaTime);
        posicion = playerRb.position;
    }

}