using System.Collections;
using UnityEngine;

public class SpikeTrap2 : MonoBehaviour
{
    public float popOutDelay = 1.0f, nextDamageTime = 0.0f, damageInterval = 0.5f;  // Time before the trap pops out  // Time when the trap can deal damage next // How often the trap deals damage
    public int damage = 1; // Amount of damage dealt
    public bool isActive = false; // Indicates if the trap is active
    private Animator anim; // Reference to the Animator component

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isActive", isActive);
    }

    private void Update()
    {
        if (isActive)
        {
            // Checks if it's time to deal damage
            if (Time.time >= nextDamageTime)
            {
                DealDamage();
                Debug.Log("Taking Spike damage"); //wwwwww
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    private IEnumerator PopOutCoroutine()
    {
        yield return new WaitForSeconds(popOutDelay);
        isActive = true;
        anim.SetBool("isActive", isActive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isActive)
            {
                StartCoroutine(PopOutCoroutine());
            }
        }
        if (isActive && other.CompareTag("Player"))
        {
            nextDamageTime = Time.time; // Start the damage interval
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Optionally, you can also set isActive to false if you want to deactivate the trap
            StopCoroutine(PopOutCoroutine());
            StopAllCoroutines();
            isActive = false;
            Debug.Log("Exited");
            anim.SetBool("isActive", isActive);
        }
    }

    private void DealDamage()
    {
        // Assuming the player has a Player Health script
        PlayerCtrl playerHealth = FindObjectOfType<PlayerCtrl>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
