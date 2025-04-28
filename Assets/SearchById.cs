using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchById : MonoBehaviour
{
    //CURRENT Range standing in
    private GameObject CurrentInRange;


    //public GameObject Indicator;

    //private float waitTime;
    //private bool nowLoading = false;

    //public GameObject Optional_Obj;

    public Behaviour parentObj; //for script

    public GameObject Player;
    //public GameObject ParentOBJ;

    public bool TheresPlayer = false;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //verify if currently on teleporter
        if (collision.CompareTag("Player"))
        {
            // if TRUE
            CurrentInRange = collision.gameObject;
            parentObj.enabled = true;
            TheresPlayer = true;
            //Optional_Obj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == CurrentInRange)
        {
            TheresPlayer=false;
            //Destroy(gameObject);
            parentObj.enabled=false;
                
        }
        
        // verify if out of range
        //Ai needs to slowdown stop
    }
}
