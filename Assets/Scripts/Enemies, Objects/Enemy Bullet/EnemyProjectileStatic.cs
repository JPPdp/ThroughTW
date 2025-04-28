using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileStatic : MonoBehaviour
{
    public PlayerCtrl playerctrl; //script and variable
    public int damage=1;


    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PlayerCtrl playerctrl = player.GetComponent<PlayerCtrl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerctrl = collision.GetComponent<PlayerCtrl>();
            if (playerctrl != null)
            {
                playerctrl.TakeDamage(damage);
                playerctrl.SetInvincible();
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
