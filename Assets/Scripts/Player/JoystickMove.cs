using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed, origms = 4, dashtime, dashcd = 1f;
    float hInput, vInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;

        //transform.Translate(hInput, vInput, 0); <Old
        Vector2 move = new Vector2(hInput, vInput);
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }

}