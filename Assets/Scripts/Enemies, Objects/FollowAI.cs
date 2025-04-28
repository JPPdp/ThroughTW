using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public float speed, minimumDistance, health, timeBetweenShots;
    private float nextShotTime;
    public Transform target;
    public GameObject projectile;
    private GameObject player;
    bool Shoot;
    Rigidbody2D rb;
    [SerializeField] private GameObject[] dropItems;
    [SerializeField] private float dropChance = 0.5f;

    //if hit by bullet take damage
    public void TakeDamage(float damage)
    {
    health -= damage;
    if (health <= 0)
    {

        if (Random.value <= dropChance)
        {
            DropItem();
            Destroy(gameObject);

        }

        Destroy(gameObject);}
    }
    private void DropItem()
    {
        if (dropItems.Length == 0) return;

        // Pick a random item from the dropItems array
        int randomIndex = Random.Range(0, dropItems.Length);
        GameObject itemToDrop = dropItems[randomIndex];

        // Instantiate the item at the enemy's position
        Vector3 dropPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        Instantiate(itemToDrop, dropPosition, Quaternion.identity);
    }
    // Update is called once per frame
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    


    void Update()
    {

        if  (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            if (Time.time> nextShotTime)
            {
                //put attack here
                Instantiate(projectile, transform.position, Quaternion.identity);
                nextShotTime = Time.time + timeBetweenShots;
                Shoot = true;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }
        }


        
    }
}
