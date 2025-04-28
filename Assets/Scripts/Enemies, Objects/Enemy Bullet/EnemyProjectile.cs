using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Vector3 Player;
    public PlayerCtrl playerctrl; //script and variable
    public float speed, bullettime;
    public int damage=1;
    private float timer;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PlayerCtrl playerctrl = player.GetComponent<PlayerCtrl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            PlayerCtrl playerctrl = collision.GetComponent<PlayerCtrl>();
            if (playerctrl != null)
            {
            playerctrl.TakeDamage(damage);
            playerctrl.SetInvincible();
            Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player, speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > bullettime)
        {
            Destroy(gameObject);
        }
    }


}
    

