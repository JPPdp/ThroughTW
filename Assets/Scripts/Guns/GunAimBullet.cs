using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAimBullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    public GameObject Aim;
    private Rigidbody2D rb;
    public float force, bullettime, damage, pierce = 1f;

    private float timer;
    


    // Start is called before the first frame update

         
    private void OnTriggerEnter2D(Collider2D collision){
        Enemy enemy = collision.GetComponent<Enemy>();
        FollowAI enemy1 = collision.GetComponent<FollowAI>();
        PatrolAI enemy2 = collision.GetComponent<PatrolAI>();
        PatrolTest enemy3 = collision.GetComponent<PatrolTest>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            pierce--;
            Debug.Log("Im hitting an enemy");
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage);
            }
            if (enemy1 != null)
            {
                enemy1.TakeDamage(damage);
            }
            if (enemy2 != null)
            {
                enemy2.TakeDamage(damage);
            }
            if (enemy3 != null)
            {
                enemy3.TakeDamage(damage);
            }
        }

        Bush bush = collision.GetComponent<Bush>();

        if (bush != null)
        {
            pierce--;
            bush.TakeDamage(1);
        }
        if(collision.gameObject.tag == "Wall") //needs to collide with a tag 
        {
            
            Destroy(gameObject);
        }
        
           

    }

    void Start()
    {
    GameObject closestEnemy = FindClosestEnemyWithTag("Enemy");

        if (closestEnemy != null)
        {
            Vector3 enemyPosition = closestEnemy.transform.position;
            Debug.Log("Current Enemy Position: " + enemyPosition);
            rb = GetComponent<Rigidbody2D>();
            Vector3 direction = enemyPosition - transform.position;
            Vector3 rotation = transform.position - enemyPosition;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot +90);
        }
        else
        {
            
        }

    }
    GameObject FindClosestEnemyWithTag(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bullettime){
            Destroy(gameObject);
        }
        if (pierce <= 0)
        {
            Destroy(gameObject);
        }  
    }
}
