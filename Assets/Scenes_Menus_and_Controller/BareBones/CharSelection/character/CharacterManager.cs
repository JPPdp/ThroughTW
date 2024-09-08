using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//access unity UI configurations via code

public class CharacterManager : MonoBehaviour
{
    public Character_DataBase characterDb;

    //referrence for unity Heirchy
    public Text charNameText;   // reference Text(Legacy), Text(TMP)
    public SpriteRenderer charSprite;   // character /SpriteRenderer


    // selected Character on Choosing
    private int selectedCharacter = 0;  // --internal

    // Start --start with the first character
    void Start()
    {
        //verify if theres no previous selected character
        if (!PlayerPrefs.HasKey("selectedCharacter"))
        {
            selectedCharacter = 0;//return to zero 
        } else
        {
            //if already selected character then just select that character
            Load();
        }
        UpdateCharacter(selectedCharacter);
    }

    // function for button --internal
    public void NextOption()
    {
        //move through character selection
        selectedCharacter++;

        //if reached end of characters
        if(selectedCharacter >= characterDb.CharacterCount) 
        { 
            selectedCharacter = 0;//return to zero
        }

        UpdateCharacter(selectedCharacter);
        Save();//stores last selected item
    }

    public void PrevOption()//reverse of next option
    {
        //move through character selection
        selectedCharacter--;

        //if reached end of characters
        if (selectedCharacter < 0)
        {
            selectedCharacter = characterDb.CharacterCount - 1;//return to Last (-1 since this returns as whole numbers)
        }

        UpdateCharacter(selectedCharacter);

        Save();//stores last selected item
    }

    //--hybrid (--internal /v\ --external) Explanation
    /*
     * --internal
     *      character
     *      
     * --external
     *      file        function       int
     *      characterDb/GetCharacter(key Int)
     *      
     *      ===RETURNS == 
     *      file        Array of char
     *      characterDB/Character[characterNumber] 
    */

    private void UpdateCharacter(int selectedCharacter)
    {
        //reference char        CharacterDb function GetCharacter on Character Database use the index here of "selectedCharacter" as index
        Character character = characterDb.GetCharacter(selectedCharacter);
                                //gets info [currently 2]
                                // Sprite & Name

                                // function on CharacterDB
        charSprite.sprite = character.characterSprite;
        charNameText.text = character.characterName;
    }//After call it inside the Next Option

    //

    private void Load()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
    }

    private void Save()
    {
        //                                      store selectedCharacter var to
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        //              to    ^selected Character keyname
    }
}
