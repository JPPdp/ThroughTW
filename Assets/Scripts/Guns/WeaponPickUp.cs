using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject weaponToGive;

    void OnTriggerStay2D(Collider2D other)
    {
         if (Input.GetKeyDown(KeyCode.E))
         {
            if (other.gameObject.tag == "Player")
            {
            other.gameObject.GetComponent<WeaponSwap>().UpdateWeapon(weaponToGive);
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
            Destroy(gameObject);
            }
         }
    }
}
