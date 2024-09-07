using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class playerMove : MonoBehaviour
{
    //Access local unity property
    private Rigidbody2D rb;
    public Animator anim;

    //Player movement
    float hInput, vInput; public float movementSpeed; public FixedJoystick joystick;

    public bool isDashing = false;
    public float dashPower = 24f;

    //character facing direction
    public bool isFacingRight = true;
    //public float jump;


    //DEBUGGING
    public Text hNumberText, vNumberText;

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

        hNumberText.text = hInput.ToString();
        vNumberText.text = vInput.ToString();

        transform.Translate(hInput, vInput, 0);

        //transform.localScale = transform.localScale - new Vector3(.01f,.01f,0f);
        //================================================
        if (isDashing)
        {
            if (!isFacingRight)
            {
                transform.Translate(-(dashPower), 0, 0);
                anim.SetBool("isDash", true);
            }
            else if (isFacingRight)
            {
                transform.Translate(dashPower, 0, 0);
                anim.SetBool("isDash", true);
            }



        }
        //if (isDashing){transform.Translate((dashPower * movementSpeed), 0, 0);}
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

        //if (isDashing == true){Dash();}


    }



    // flipping 
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Dash(bool canDash)
    {
        isDashing = canDash;
    }

}
