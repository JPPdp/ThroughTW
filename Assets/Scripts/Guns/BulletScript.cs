using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private Transform gun; // Reference to the gun's transform
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
            //I already tried ||
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
         rb = GetComponent<Rigidbody2D>();

        // Find the gun GameObject by tag and get its transform
        GameObject gunObject = GameObject.FindGameObjectWithTag("Gun");
        if (gunObject != null)
        {
            gun = gunObject.transform;

            // Get the Z rotation of the gun
            float zRotation = gun.rotation.eulerAngles.z;

            // Set the velocity based on the gun's rotation
            Vector2 direction = new Vector2(Mathf.Cos(zRotation * Mathf.Deg2Rad), Mathf.Sin(zRotation * Mathf.Deg2Rad));
            rb.velocity = direction.normalized * force;
        }
        else
        {

        }
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
