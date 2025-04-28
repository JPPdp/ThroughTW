using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    // Get parent 
    //public Transform weaponSlot;
    public GameObject activeWeapon;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //PREV CODE
        //finds player by id
        player = GameObject.FindGameObjectWithTag("Player");

        //PREV CODE
        //var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        var weapon = Instantiate(activeWeapon, player.transform.position, player.transform.rotation);

        //PREV CODE
        //weapon.transform.parent = weaponSlot.transform;
        weapon.transform.parent = player.transform;        
    }

    // Update is called once per frame
    public void UpdateWeapon(GameObject newWeapon)
    {
        activeWeapon = newWeapon;

        //PREV CODE
        //var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        //weapon.transform.parent = weaponSlot.transform;     
        
        var weapon = Instantiate(activeWeapon, player.transform.position, player.transform.rotation);
        weapon.transform.parent = player.transform;     
    }
}
