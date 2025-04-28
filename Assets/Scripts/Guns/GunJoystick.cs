using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GunJoystick : MonoBehaviour
{
	public Joystick joystick;
	public GameObject Gun;
    public GameObject autobullet;
	public GameObject bullet;
    public Transform bulletTransform;
	Vector2 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;


	public float HorizontalInput,VerticalInput;
	float setAimSpeed = 2;
	public bool FacingRight = true;

    public bool canFire;
	
	bool buttonHeld = false;

    private float timer;
	public float timeBetweenFiring;

	void Update()
	{
		
		HorizontalInput = joystick.Horizontal;
    	VerticalInput = joystick.Vertical;		

		/*if(VerticalInput>.5f||VerticalInput>-.5f||HorizontalInput>.5f||HorizontalInput>-.5f){
			shootNow();
		}else{
			shootStop();
		}*/
		//Gets the input from the jostick
		GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);

		GameobjectRotation3 = GameobjectRotation.x;

		if (FacingRight)
		{
			if (GameobjectRotation.x > 0)
			{
				// Rotates the object if the player is facing right
				float GameobjectRotation2 = GameobjectRotation.y * 90; // Use only the Y component for rotation
				Gun.transform.rotation = Quaternion.Euler(0f, 0f, GameobjectRotation2);
			}
		}
		else
		{
			if (GameobjectRotation.x < 0)
			{
				// Rotates the object if the player is facing left
				float GameobjectRotation2 = GameobjectRotation.y * -90; // Use only the Y component for rotation
				Gun.transform.rotation = Quaternion.Euler(0f, 0f, 180f + GameobjectRotation2); // 180 degrees for facing left
			}
		}
		if (GameobjectRotation3 < 0 && FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
		else if (GameobjectRotation3 > 0 && !FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}

		if(buttonHeld)
		{
			shooting();
		}
        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

		shooting2();
	}


    public void shooting2()
    {
		if (HorizontalInput != 0 || VerticalInput != 0)
		{
			//fix this, this is going to ur mouse lol
			if(canFire)
			{
			canFire = false;
			Instantiate(bullet, bulletTransform.position, Gun.transform.rotation);
			}
		}
	}
	public void shooting()
    {

			if(canFire)
			{
			canFire = false;
			Instantiate(autobullet, bulletTransform.position, Gun.transform.rotation);
			}
	}

	//Auto Aim
	public void shootNow(){
        buttonHeld = true;
    }
    public void shootStop(){
        buttonHeld = false;
    }
	//Auto Aim

	private void Flip()
	{
		// Flips the player.
		FacingRight = !FacingRight;

		transform.Rotate(0, 180, 0);
	}
}