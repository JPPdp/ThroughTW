using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiketrap : MonoBehaviour
{
    private Animator anim;

    public bool On;
    public float spikeGoOn, spikereset;
    public int damage = 1;  

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && On)
            {
                Debug.Log("Triggered!");
                DealDamage();
            }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left");
        }
    }
    
    void Update()
    {
        spikeGoOn -= Time.deltaTime;

        if(spikeGoOn < 0)
        {
            On = !On;
            spikeGoOn = spikereset;
        }
        anim.SetBool("Standing", On);
    }
        private void DealDamage()
    {
        // Assuming the player has a Player Health script
        PlayerCtrl playerHealth = FindObjectOfType<PlayerCtrl>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
