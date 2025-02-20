using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    
    private Animator animator;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (movement.x > 0.1f)
        {
            transform.localScale = Vector3.one;
        }
        else if (movement.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.SetBool("isMoving", movement.x != 0 || movement.y != 0);
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
        
        
    }
}
