using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public float bulletSpeed;

    private GameObject player;
    private Rigidbody2D rb;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        // finds player position and negates its own position so it can choose the direction its going(Like finding position bias X&Y&Z)
        Vector3 direction = player.transform.position - transform.position;

        // takes the pos directional bias of X & Y  multiplied by controlled speed
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * bulletSpeed;

        // bullet rotation
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy on too long of existence
        timer += Time.deltaTime;

        if (timer > 05) 
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //verify that the collision was on player
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }   
    }

    
}
