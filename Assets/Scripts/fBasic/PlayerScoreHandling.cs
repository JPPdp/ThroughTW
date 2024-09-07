using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScoreHandling : MonoBehaviour
{

    public static PlayerScoreHandling instance;

    public Text numberText;
    public int currentCoins = 0;


    private void Awake()
    {
        instance = this;
    }
    public void add_Coins_More(int v)
    {
        currentCoins += v;
        numberText.text = "Coins: "+ currentCoins.ToString();
    }
}
