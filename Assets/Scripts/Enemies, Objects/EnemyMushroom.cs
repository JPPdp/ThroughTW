using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : MonoBehaviour
{
    public Transform f1, f2, f3, f4, f5, f6, f7, f8;
    public float fireRate, nextTimeToFire, bulletSpeed, bullettime;
    Rigidbody2D rb;
    public GameObject bullet;
    public bool shooting;
    private Animator animator;

    //sprite
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //sprite checker
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // Store the original color
    }


    public void dead()
    {
        spriteRenderer.color = Color.gray;
        GetComponent<Collider2D>().enabled = false;
        
        //Destroy(gameObject, 2f); <---- if you want the thing to delete after a while
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShootCoroutine());
            shooting = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the object exiting is tagged as "enemy"
        {
            shooting = false;
            Animation();
            StopAllCoroutines( );
        }
    }

    
    void Update()
    {

        //if (hp = 0) for anim> ("ShootDie", Die)
            //die = true;
            //dead();
        if (shooting)
        {
            StartCoroutine(ShootCoroutine());
        
        }
    }
private IEnumerator ShootCoroutine()
    {
        // Play shooting animation
        Animation(); // Ensure this method triggers the animation

        // Wait for the duration of the shooting animation
        // Assuming you have an animation length (replace with your actual animation duration)
        float animationDuration = 0.8f; // Adjust this value based on your animation
        yield return new WaitForSeconds(animationDuration);

        // Fire only if it's time
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }
void Animation()
{
    animator.SetBool("ShootAnim", shooting);
}
    
void Shoot()
    {
        shooting = true;
        GameObject b1 = Instantiate(bullet, f1.position, f1.rotation);
        Rigidbody2D rb1 = b1.GetComponent<Rigidbody2D>();
        rb1.velocity = f1.up * bulletSpeed;
        Destroy(b1, bullettime);

        GameObject b2 = Instantiate(bullet, f2.position, f2.rotation);
        Rigidbody2D rb2 = b2.GetComponent<Rigidbody2D>();
        rb2.velocity = f2.up * bulletSpeed;
        Destroy(b2, bullettime);

        GameObject b3 = Instantiate(bullet, f3.position, f3.rotation);
        Rigidbody2D rb3 = b3.GetComponent<Rigidbody2D>();
        rb3.velocity = f3.up * bulletSpeed;
        Destroy(b3, bullettime);

        GameObject b4 = Instantiate(bullet, f4.position, f4.rotation);
        Rigidbody2D rb4 = b4.GetComponent<Rigidbody2D>();
        rb4.velocity = f4.up * bulletSpeed;
        Destroy(b4, bullettime);

        GameObject b5 = Instantiate(bullet, f5.position, f5.rotation);
        Rigidbody2D rb5 = b5.GetComponent<Rigidbody2D>();
        rb5.velocity = f5.up * bulletSpeed;
        Destroy(b5, bullettime);

        GameObject b6 = Instantiate(bullet, f6.position, f6.rotation);
        Rigidbody2D rb6 = b6.GetComponent<Rigidbody2D>();
        rb6.velocity = f6.up * bulletSpeed;
        Destroy(b6, bullettime);

        GameObject b7 = Instantiate(bullet, f7.position, f7.rotation);
        Rigidbody2D rb7 = b7.GetComponent<Rigidbody2D>();
        rb7.velocity = f7.up * bulletSpeed;
        Destroy(b7, bullettime);

        GameObject b8 = Instantiate(bullet, f8.position, f8.rotation);
        Rigidbody2D rb8 = b8.GetComponent<Rigidbody2D>();
        rb8.velocity = f8.up * bulletSpeed;
        Destroy(b8, bullettime);

    }
}
