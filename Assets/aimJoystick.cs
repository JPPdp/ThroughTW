using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimJoystick : MonoBehaviour
{
    public float fireSpeed;
    public FixedJoystick joystick;
    public Rigidbody2D rb;

    float hInput, vInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = joystick.Horizontal * fireSpeed;

        vInput = joystick.Vertical * fireSpeed;

        Vector3 AimInput = new Vector3(0, hInput ,vInput);

        Vector3 lookAtPoint = transform.position + AimInput;
    }
}
