using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1 : MonoBehaviour
{
    public PlayerCtrl playerctrl; //script and variable
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private float Level;
    public int enemies;

    private List<int> numbers;
    private System.Random random;

    public int minValue = 0;
    public int maxValue = 4;
    private GameObject playerUI;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI");
        playerctrl = player.GetComponent<PlayerCtrl>();
    }
    private void Awake()
    {
        random = new System.Random();
        InitializeRandomizer();
    }

    public void ShowPlayerUI()
    {
        if (playerUI != null)
        {
            playerUI.SetActive(true);
        }
        else
        {
            Debug.Log("No Object was found");
        }
    }
    private void InitializeRandomizer()
    {
        numbers = new List<int>();
        for (int i = minValue; i < maxValue; i++)
        {
            numbers.Add(i);
        }
        Shuffle(numbers);
    }

    public int GetNextRandom()
    {
        if (numbers.Count == 0) 
        {
            Debug.LogError("No more unique numbers available.");
            return -1;
        }

        int index = random.Next(numbers.Count);
        int value = numbers[index];
        numbers.RemoveAt(index);
        return value;
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
    if (enemies <= 0)
        if(collision.gameObject.tag == "Player"){
    {
        
        Level = GetNextRandom();
        Debug.Log(Level);
        
        //change something on player
        playerctrl.StageValue();
        playerctrl.GameStart();

        ShowPlayerUI();       
        if (Level == 0 || Level == 1)
        {


        SceneManager.LoadSceneAsync("L1");
        }
        if (Level == 2)
        {

        SceneManager.LoadSceneAsync("L2");
        }
        if (Level == 3)
        {

        SceneManager.LoadSceneAsync("L3");
        }
        if (Level == 4)
        {

        SceneManager.LoadSceneAsync("L4");
        }

    }
        }}  
    void Update(){
    if (AreNoEnemiesLeft())
    {
        spriteRenderer.sprite = newSprite;
        enemies = -1;
    }
    }
    

// Method to check for enemies
private bool AreNoEnemiesLeft()
{
    GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

    return enemiesArray.Length == 0;
}
}