using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //============COPIED FROM CHARACTERMANAGER AS REFERENCE=======================
    //REFERENCE FROM CHARACTER MANAGER
    public Character_DataBase characterDb;
                //referrence for unity Heirchy
    //public Text charNameText;   // reference Text(Legacy), Text(TMP)
    public SpriteRenderer charSprite;   // character /SpriteRenderer
    private int selectedCharacter = 0;  // selected Character on Choosing
                                        //COPY FROM CHARACTER MANAGER AS REFERENCE
    //============COPIED FROM CHARACTERMANAGER AS REFERENCE=======================





    //============COPIED FROM CHARACTERMANAGER AS REFERENCE=======================
    private void UpdateCharacter(int selectedCharacter)
    {
        //reference char        CharacterDb function GetCharacter on Character Database use the index here of "selectedCharacter" as index
        Character character = characterDb.GetCharacter(selectedCharacter);
        //gets info [currently 2]
        // Sprite & Name

        // function on CharacterDB
        charSprite.sprite = character.characterSprite;
        //charNameText.text = character.characterName;
    }//After call it inside the Next Option

    //

    private void Load()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
    }

    // Start is called before the first frame update
    void Start()
    {
        //verify if theres no previous selected character
        if (!PlayerPrefs.HasKey("selectedCharacter"))
        {
            selectedCharacter = 0;//return to zero 
        }
        else
        {
            //if already selected character then just select that character
            Load();
        }
        UpdateCharacter(selectedCharacter);
    }
    //============COPIED FROM CHARACTERMANAGER AS REFERENCE=======================
}
