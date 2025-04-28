using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    
    
    private GameObject player;
    public float health;
    public float speed;


    Rigidbody2D rb;
    private bool hasLineofSight = false;

    



    //if hit by bullet take damage
    public void TakeDamage(float damage){
    health -= damage;
    if (health <= 0)
    {

        Destroy(gameObject);
    }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void FixedUpdate(){
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if(ray.collider != null)
        {
            hasLineofSight = ray.collider.CompareTag("Player");
            if(hasLineofSight){
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);

            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.blue);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {if(hasLineofSight)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    }

}
