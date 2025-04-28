using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTest : MonoBehaviour
{
    public float patrolAreaWidth = 5f;   // Width of the patrol area
    public float patrolAreaHeight = 5f;  // Height of the patrol area
    public float speed = 2f;              // Speed of the enemy
    public bool isPatrolling = true, idle = false, Die = false; // Bool to control patrolling

    private Vector2 targetPosition;       // Current target position
    public float waitTime;                 // Time to wait before choosing a new target
    private float waitTimer;               // Timer to track wait time
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Collider2D enemyCollider;
    private Coroutine wallCollisionCoroutine;
    //Stats

    public float health;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <=0)
        {
            Dead();

        }
    }
    void Start()
    {
        // Set the initial target position
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomTargetPosition();
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!Die)
        {        
            if (isPatrolling)
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        // Move towards the target position
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = newPosition;
        
        // Check if the enemy has reached the target position
        if (Vector2.Distance(transform.position, targetPosition) < 1f)
        {
            // Start the wait timer
            waitTimer += Time.deltaTime;
            idle = true;
            animator.SetBool("Idle", idle);
            // If the wait time has passed, choose a new target
            if (waitTimer >= waitTime)
            {
                SetRandomTargetPosition();
                waitTimer = 0f; // Reset the timer
            }
        }
        else
        {
            idle = false;
            FlipSprite(newPosition);
            animator.SetBool("Idle", idle);
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
        Die=true;
        animator.SetBool("Dead", Die);

        //Destroy(gameObject, 2f);
    }
    void FlipSprite(Vector2 newPosition)
    {
        
        if (targetPosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (targetPosition.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    void SetRandomTargetPosition()
    {
        Vector2 randomPosition;
        int attempts = 0;

        // Try to find a valid position that does not collide with walls
        do
        {
            float randomX = Random.Range(-patrolAreaWidth / 2, patrolAreaWidth / 2);
            float randomY = Random.Range(-patrolAreaHeight / 2, patrolAreaHeight / 2);
            randomPosition = (Vector2)transform.position + new Vector2(randomX, randomY);
            attempts++;

            // Limit the number of attempts to avoid an infinite loop
            if (attempts > 10)
            {
                return;
            }

        } while (IsCollidingWithWall(randomPosition));

        targetPosition = randomPosition;
    }

    bool IsCollidingWithWall(Vector2 position)
    {
        // Check if the target position is colliding with any walls
        Collider2D hit = Physics2D.OverlapCircle(position, 0.1f); // Small radius for checking
        return hit != null && hit.CompareTag("Wall");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {

            // Start the coroutine when entering the wall
            if (wallCollisionCoroutine == null)
            {
                wallCollisionCoroutine = StartCoroutine(SetRandomTargetPositionContinuously());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {

            // Stop the coroutine when exiting the wall
            if (wallCollisionCoroutine != null)
            {
                StopCoroutine(wallCollisionCoroutine);
                wallCollisionCoroutine = null;
            }
        }
    }

    private IEnumerator SetRandomTargetPositionContinuously()
    {
        while (true)
        {
            SetRandomTargetPosition();
            yield return new WaitForSeconds(1f); // Adjust the delay as needed
        }
    }
}