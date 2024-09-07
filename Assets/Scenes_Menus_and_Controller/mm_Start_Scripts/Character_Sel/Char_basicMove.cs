using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Char_basicMove : MonoBehaviour
{
    //Access local unity property
    private Rigidbody2D rb;
    public Animator anim;

    //Player movement
    float hInput, vInput; public float movementSpeed; public FixedJoystick joystick;

    //character facing direction
    public bool isFacingRight = true;
    //public float jump;

    void Start()
    {
        //initiate rigid body in instance of start
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //BASIC MOVEMENT SCRIPT
        hInput = joystick.Horizontal * movementSpeed;
        vInput = joystick.Vertical * movementSpeed;
        //update the input
        transform.Translate(hInput, vInput, 0);
        //================================================

        // CHARACTER FLIPPING VERIFIER
        if (!isFacingRight && hInput > 0f)
        {
            Flip();
        }
        else if (isFacingRight && hInput < 0f)
        {
            Flip();
        }
        //================================================

        //verifier if char is moving
        if (hInput >= 0.01f || hInput <= -0.01f)
        {
            anim.SetBool("isRunning", true);
        }
        else { anim.SetBool("isRunning", false); }
    }



    // flipping 
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}


