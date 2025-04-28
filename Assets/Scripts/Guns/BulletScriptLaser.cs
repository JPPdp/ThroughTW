using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptLaser : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float bullettime;
    public float damage;
    private float timer;
    


    // Start is called before the first frame update

         
    private void OnTriggerStay2D(Collider2D collision){
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Bush bush = collision.GetComponent<Bush>();

        if (bush != null)
        {
            bush.TakeDamage(1);
        }
        if(collision.gameObject.tag == "Wall") //needs to collide with a tag 
        {
            Destroy(gameObject);
        }        
    }

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //rotate object by direction int/float Zed + 90
        transform.rotation = Quaternion.Euler(0, 0, rot +90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bullettime){
            Destroy(gameObject);
        }
    }
}
