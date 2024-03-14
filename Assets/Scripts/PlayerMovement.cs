using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;

    [SerializeField] private float playerSpeed = 1000f;
    //private Vector2 movement = new Vector2(1, 1);

    [SerializeField] private GameObject player;
    [SerializeField] private float jumpSpeed = 10f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        //float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");

        //movement = new Vector2(playerSpeed.x * inputX, 0f);        
    }

    private void FixedUpdate()
    {
        //rb.velocity = movement;
        ProcessJump();
        ProcessRun();
    }

    private void ProcessRun()
    {
        float hInput = Input.GetAxis("Horizontal");
        rb.velocity = new(hInput * playerSpeed * Time.deltaTime, rb.velocity.y);
    }

    private void ProcessJump()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector2(0.0f, jumpSpeed);
        }
    }

}
