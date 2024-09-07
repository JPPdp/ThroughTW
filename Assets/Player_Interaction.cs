using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{

    //CURRENT TELEPORTER standing in
    private GameObject currentTpObject;

    public void interact_Now()
    {
        if (currentTpObject != null)
        {
            transform.position = currentTpObject.GetComponent<Teleport>().GetDestination().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //verify if currently on teleporter
        if (collision.CompareTag("Teleporter"))
        {
            // if TRUE
            currentTpObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //verify if in the same teleporter 
        if (collision.gameObject == currentTpObject)
        {
            //remove the mark on the other TP
            currentTpObject = null;
        }
    }
}
