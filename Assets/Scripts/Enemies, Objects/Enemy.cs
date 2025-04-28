using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    
    private GameObject player;
    public float health;
    public float speed;
    Rigidbody2D rb;
    private bool hasLineofSight = false;
    public L1 Level;

    [SerializeField] private GameObject[] dropItems;
    [SerializeField] private float dropChance = 0.5f;

    private bool move=false, Die=false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Collider2D enemyCollider;


    //player
    public PlayerCtrl playerctrl; //script and variable

    //if hit by bullet take damage
    public int score = 50;
    public void TakeDamage(float damage){
    health -= damage;
    if (health <= 0)
    {

        if (Random.value <= dropChance)
        {
            DropItem();
            Destroy(gameObject);
        }

        Dead();
        //Destroy(gameObject);
    }

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerctrl = player.GetComponent<PlayerCtrl>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate(){
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if(ray.collider != null)
        {
            hasLineofSight = ray.collider.CompareTag("Player");
            if (!Die){
            if(hasLineofSight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                move = true;
                animator.SetBool("Move", move);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.blue);
                move = false;
                animator.SetBool("Move", move);
            }}
        }
    }

    // Update is called once per frame
    void Update()
    {if(hasLineofSight)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    if (Die)
    {
        speed = 0;
        enemyCollider.enabled = false;
    }

}
    void Dead()
    {
        // Remove collider to prevent further collisions
        if (enemyCollider != null) //needs fix <-----------------------------------------------------------
        {
            enemyCollider.enabled = false;
            Debug.Log("Turned off colldier");
            //gameObject.GetComponent<CapsuleCollider2D>.SetActive
        }
        // Change color to gray
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.gray;
        }
        // Change the tag to "Dead"
        gameObject.tag = "Dead";

        Die=true;
        animator.SetBool("Dead", Die);
        playerctrl.ScoreValue(score);

        //Destroy(gameObject, 2f);
}
}
