using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Coin : MonoBehaviour
{
    public GameObject CoinEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        //CoinEffect.SetActive(true);
        //Invoke("deleterSelf", .2f);
    }

    void deleteSelf()
    {
        
        //CoinEffect.SetActive(false);
    }
}
