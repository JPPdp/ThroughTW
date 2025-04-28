using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.Networking;
public class PlayerCtrl : MonoBehaviour
{
    // timer
    float timeRemaining = 0;
    bool timeIsRunning = false;
    public Text timeText;
    string timeInternal;
    float timeInt = 0;

    // health sprite
    public Image imageOfHpOnUi;
    public List<Sprite> Healthsprites;
    private int currentSprite;

    private float score = 0, finalscore, finalcoin, finalkey, finalstage;

    //
    public static PlayerCtrl Instance;
    public float movSpeed;
    public int health;
    public int maxHealth;
    Vector2 velocity;
    Rigidbody2D rb;
    public SpriteRenderer playerSr;
    public PlayerCtrl playerctrl;
    public int coin = 0, stage =0;
    public int key = 0;
    public Text coinText, keyText, scoreText;    
    public Text finalcoinText, finalkeyText, stageText, finalitemsText, finalscoreText;
    public string finalcoinText1, finalkeyText1, stageText1, finalitemsText1, finalscoreText1;
    public string Pusername = "Default1";

    //David's
    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 5f; 
    public float dashcooldown = 1f;//Remove if no cooldown
    private float dashCounter;
    private float dashCDCounter; //Remove if no cooldown

    //invisibility
    public float invincibilityDuration = 1.5f; // Duration of immunity frames in seconds (go to EnemyDamage n set the same value if u mess with this)
    public bool isInvincible = false, gamestart = false;
    private float invincibilityTimer;

    //Sprite Bling Bling
    public SpriteRenderer sprite;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;
    private Color originalColor;

    //
    public GameObject Restart;
    public GameObject PlayerUI;
    //
    /*public string Lobby;*/
    //sqlite

    private string dbName = "URI=file:PlayerCtrl.db";

    void Start()
    {
        
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();  
        activeMoveSpeed = movSpeed; //Replace "moveSpeed" with player movement speed in script 
        sprite = GetComponent<SpriteRenderer>();
        Color originalColor = sprite.color;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PJ = player.GetComponent<PlayerJoystick>();

        /*if (SceneManager.GetActiveScene().name == Lobby)
        {
            // Disable the GameObject
            PlayerUI.SetActive(false);
        }*/

        //

        //sqlite


        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        if (sprite != null)
        {
            originalColor = sprite.color; // Store the original color
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }

    }
    public void GameStart()
    {
        if (!gamestart)
        {
            score = 500;
        }
        gamestart = true;
    }
    public void TakeDamage(int amount)
    {//amount is damage received
        if (isInvincible)
        {
        return;
        }

        else
        {
            Debug.Log("You took Damage");
            health -= amount;
            isInvincible = true;
            StartCoroutine(FlashCoroutine());

        }
    }
    public void StageValue()
    {
        stage++;
    }
    public void ScoreValue(int scoreamount)
    {
        score += scoreamount;
    }
    
    void iframes()
    {

            isInvincible = true;
            if (invincibilityTimer <=0)
            {
            Debug.Log("I ran iframes");
            invincibilityTimer = invincibilityDuration;
            }
    }
    public void SetInvincible()
    {
        Debug.Log("Setting Invis");
        iframes();

    }    

    private void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        sprite.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        sprite.color = originalColor;
        yield return new WaitForSeconds(flashDuration);
        
    }



    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == ("Coin") && collision.gameObject.activeSelf == true) //needs to collide with a tag
        {
            collision.gameObject.SetActive(false);
            coin+=1;
            score+=20;
            coinText.text = coin.ToString();
        }
        if(collision.gameObject.tag == ("Key") && collision.gameObject.activeSelf == true)//needs to collide with a tag
        {
            collision.gameObject.SetActive(false);
            key+=1;
            score+=50;
            keyText.text = key.ToString();
        }
        if(collision.gameObject.tag == ("Heart") && collision.gameObject.activeSelf == true)//needs to collide with a tag
        {
            if(health != maxHealth)
            {
            collision.gameObject.SetActive(false);
            health++;
            }
            else
            {
                return;
            }
            
        }

    }



    void Update()
    {
        if (health <=0)
        {
        health = 0;
        //
        finalscore = score; finalcoin = coin; finalkey = key; finalstage = stage;
        finalkeyText.text = finalkey.ToString();
        finalcoinText.text = finalcoin.ToString();
        stageText.text ="Stage:" + finalstage.ToString();
        finalscoreText.text = ((int)finalscore).ToString();

             
            GameStoped__UploadToDB();

            health = 1;
        Restart.SetActive(true);
        }
        //
        if (health != 0)
        {
            //on update
                //[image swatch]currentHp sprite is equal to player health
                currentSprite = health;
        
                //UI health sprite is going to look like health sprite# number
                imageOfHpOnUi.sprite = Healthsprites[currentSprite];

            if (gamestart)
            {
                if (timeRemaining >= 0)
                {
                    timeInt += Time.deltaTime;
                    
                    timeRemaining += Time.deltaTime;
                    DisplayTime(timeRemaining);
                
                }
                if (score >=1)
                {
                score -= Time.deltaTime;
                scoreText.text = ((int)score).ToString();
                }
            }

        } else{/*FindObjectOfType<GameManager>().EndGame();    mainControls.SetActive(false);    LostScreen.SetActive(true);   AfterGameLost.instance.timeSave(timeInt);*/}

        //
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity.Normalize();
        rb.velocity = velocity * movSpeed;

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Handle the key press
            Debug.Log("Healing!");
            health++;
        }

    //score

    //David's
    rb.velocity = velocity * activeMoveSpeed; //Replace "Player" with actual player name in project




    if (dashCounter > 0) //if dash reaches 0 then reset back to original speed
    {
        dashCounter -= Time.deltaTime; //Updates every frame (Frame base, could be an issue)

        if(dashCounter <=0)
        {
            activeMoveSpeed = movSpeed; //Player movespeed
            dashCDCounter = dashcooldown;
        }
    }
    if (dashCDCounter > 0) //Just counts down until dash is available again
    {
        dashCDCounter -= Time.deltaTime;
    }
    if (isInvincible)
    {
        StartCoroutine(FlashCoroutine());
        invincibilityTimer -= Time.deltaTime;
        if (invincibilityTimer <= 0)
        {
            
            isInvincible = false;
            StopCoroutine(FlashCoroutine());
            sprite.color = originalColor;
        }
    }

    if (!isInvincible)
    {   
        StopCoroutine(FlashCoroutine());
        sprite.color = originalColor;

    }
    }

public void lobby()
{
    gamestart = false;
    score = 1;
    health = maxHealth;
    coin = 0;
    key = 0;
    timeRemaining = 0;
    SceneManager.LoadSceneAsync("Lobby");
}
PlayerJoystick PJ;
    public void dashingInButton()
    {
        if (dashCDCounter <= 0 && dashCounter <= 0) //Perform a dash
        {
            Debug.Log("Dashing");
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
            if (!isInvincible)
            {
                isInvincible = true;
                invincibilityTimer = invincibilityDuration;
            }
            PJ.DashButton();
            
        }
    }
    public void Dash()
    {
        if (dashCDCounter <=0 && dashCounter <=0) //Perform a dash
        {
            Debug.Log("Dashing");
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
            if (!isInvincible)
            {
                isInvincible = true;    
                invincibilityTimer = invincibilityDuration;
            }
        }

    }

    
    void DisplayTime(float x)
    {
        x += 1;
        float mins = Mathf.FloorToInt(x / 60); // divided whole
        float secs = Mathf.FloorToInt(x % 60); // remainder
        timeText.text = "\bTime:  "+string.Format("{0:00} : {1:00}", mins, secs);
        timeInternal = (timeText.text =  string.Format("{0:00} : {1:00}", mins, secs)).ToString(); // TIME INTERNAL STRING
    }

    /*
    void Sqlite()

    id
    username

    finalscore
    finalcoin
    finalkey
    finalstage

    */

    
    public  void GameStoped__UploadToDB(){
        
        
        StartCoroutine(NewScore(Pusername ,finalscore.ToString(), finalcoin.ToString(), finalkey.ToString(),finalstage.ToString()));
        Debug.Log("Successfully converted");
        
    }

    IEnumerator NewScore(string username, string finalscore, string finalcoin, string finalkey, string finalstage)
    {
        // a form to Web
        WWWForm form = new WWWForm();

        // gets the values of login User & Password -- Predefined above the Update method
        // the values is added to "form" with Fields representing (internal variable , server variable) - server variable should exist on server
        // else it wont work
        form.AddField("loginUser", username); 
        form.AddField("finalscore", finalscore);
        form.AddField("finalcoin", finalcoin);
        form.AddField("finalkey", finalkey);
        form.AddField("finalstage", finalstage);

        // make a web request using variable "www" command [method(POST) this {link} on form]
        // on Xampp files "htdocs" - Add new Folder "BackEndFolder" -- Add the scripts
        // Method Get use The command Php on server named "GetUser.php"

        //using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.43.220:8080/BackEndFolder/NewScore.php", form))
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/BackEndFolder/TestAddUser.php", form))
        {
            // hold return
            yield return www.SendWebRequest();

            //CONNECTION CHECK [check if theres error in connection]
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error on Web.cs file ::: Function GetText ::: Network-Web error");
            }
            else
            {
                // shows www request contents as Text
                Debug.Log(www.downloadHandler.text);
                Debug.Log("Connection Confirmed: User Status: User Exist on DB: " + username);

                // shows www request contents as binary data
                //byte[] results = www.downloadHandler.data;
            }
        }
    }

}