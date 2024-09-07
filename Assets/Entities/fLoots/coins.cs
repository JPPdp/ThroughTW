using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{

    public int value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            PlayerScoreHandling.instance.add_Coins_More(value);
        }
        
    }

}
