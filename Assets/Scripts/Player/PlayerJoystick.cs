using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerJoystick : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed, origms =4, dashtime, dashcd=1f;
    float hInput, vInput; 
    private Rigidbody2D rb;

  public bool canDashNow = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dashtime -= Time.deltaTime;

        if (dashtime <=0)
        {
            moveSpeed = origms;
            if (dashcd  >=0)
            {
            dashcd -= Time.deltaTime;
            }
            if (dashcd <= 0)
            {
                canDashNow = true;
            }
        }
    }

    private void FixedUpdate(){
    
    hInput = joystick.Horizontal * moveSpeed;
    vInput = joystick.Vertical * moveSpeed;

    //transform.Translate(hInput, vInput, 0); <Old
    Vector2 move = new Vector2(hInput, vInput);
    rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }

    public void DashButton()
    {   
        if(canDashNow && dashcd <= 0)
        {
            moveSpeed = 15f;
            dashtime = .2f;
            dashcd = 1f;
            canDashNow = false;
        }
    }


}
