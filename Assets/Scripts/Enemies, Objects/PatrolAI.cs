using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{

    public float speed, waitTime, minimumDistance, health;
    public Transform[] patrolPoints;
    int currentPointIndex;
    bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
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
    void Update()
    {
        float distance = Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position);//this needs to check if patrol point is a INT number not a float number
        if (distance > minimumDistance)//semi fix so it doesnt have to be exactly there
        {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
            once = true;
            StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }
}
