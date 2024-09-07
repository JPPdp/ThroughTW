using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting_1 : MonoBehaviour
{
    // Initiate Variables
    public GameObject Bullet_Type;
    public Transform bulletPos;
    public float Range;

    private float timer;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }
    
    // Update is called once per frame
    void Update()
    {

        //distance between Enemy to Player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < Range) 
        {
            timer += Time.deltaTime;
            //reset timer if already 2
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }

        
    }
    // Shooting function
    void shoot()
    {
        Instantiate(Bullet_Type, bulletPos.position, Quaternion.identity);
    }

}
