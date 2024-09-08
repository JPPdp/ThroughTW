using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{

    //CURRENT TELEPORTER standing in
    private GameObject currentTpObject;
    public  Camera Camera;
    public GameObject LoadScreen;
    private float waitTime;

    public GameObject Optional_Obj;
    public void interact_Now()
    {
        LoadScreen.SetActive(true);
        while(waitTime != 2) {
            waitTime += Time.deltaTime;
        }
        if (currentTpObject != null)
        {   
            //transfrom current player position INTO(=) current TP objbect Get component(Script) <ScriptName>(run) -Method- [.Get -type- Destination()] DOT -type-(position)
            transform.position = currentTpObject.GetComponent<Teleport>().GetDestination().position;
            //transform current player position into teleport Destination

            //transfrom current camera position INTO(=) current TP objbect Get component(Script) <ScriptName>(run) -Method- [.Get -type- Destination()] DOT -type-(position)
            Camera.transform.position = currentTpObject.GetComponent<Teleport>().GetDestination().position;
            //follow player with camera

            LoadScreen.SetActive(false);
            //currentTpObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //verify if currently on teleporter
        if (collision.CompareTag("Teleporter"))
        {
            // if TRUE
            currentTpObject = collision.gameObject;
            Optional_Obj.SetActive(true);
        }

        // verify if infront of shop
        if (collision.CompareTag("TeleporterToShop"))
        {
            // if TRUE
            currentTpObject = collision.gameObject;
            Optional_Obj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //verify if in the same teleporter 
        if (collision.gameObject == currentTpObject)
        {
            //remove the mark on the other TP
            currentTpObject = null;
            Optional_Obj.SetActive(false);
        }
    }


}
