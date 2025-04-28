using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    public PlayerCtrl playerctrl; //script and variable
    public int damage = 1; //damage dealt
    public bool colliding=false;
    private float invincibilityTimer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    playerctrl = player.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        invincibilityTimer -= Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)//runs if it collides with something
    {
        if(collision.gameObject.CompareTag("Player"))//needs to collide with a tag player
        {

            if(!colliding)
            {
                if (playerctrl != null)
                    {
                        playerctrl.TakeDamage(damage);
                        colliding=true;
                        invincibilityTimer = 1.5f;
                        playerctrl.SetInvincible();
                    }
            }
            else
            {
                if( invincibilityTimer <= 0)
                {
                colliding=false;
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            playerctrl = collision.GetComponent<PlayerCtrl>();
        }
    }
}
