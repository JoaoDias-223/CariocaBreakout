using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameController game;
    public float movementSpeed = 5f;
    public Vector2 movement;
    
    public Rigidbody2D rb2D;
    public Animator animator;

    private Vector3 initialPosition;

    private const string ANIM_HORIZONTAL_PARAM = "Horizontal";
    private const string ANIM_VERTICAL_PARAM = "Vertical";
    private const string ANIM_SPEED_PARAM = "Speed";

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!game.IsRunning()) return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat(ANIM_HORIZONTAL_PARAM, movement.x);
        animator.SetFloat(ANIM_VERTICAL_PARAM, movement.y);
        animator.SetFloat(ANIM_SPEED_PARAM, movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (!game.IsRunning()) return;

        float limit = 1.0f;
        
        if (movement.x != 0 && movement.y != 0)
        {
            limit = .7f;
        }
        rb2D.MovePosition(rb2D.position + Time.fixedDeltaTime * movementSpeed * limit * movement);
    }

    public void ResetOnLose()
    {
        transform.position = initialPosition;
        rb2D.velocity = Vector2.zero;
    }
}
