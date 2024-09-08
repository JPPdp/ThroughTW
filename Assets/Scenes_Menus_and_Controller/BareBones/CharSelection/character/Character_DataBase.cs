using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]//unity option create assets

public class Character_DataBase : ScriptableObject
{
    // character array
    public Character[] character;
    
    public int CharacterCount
    {
        get
        {
            // number of characters in array
            return character.Length;
        }
    }

    //get character infos--data
    public Character GetCharacter(int index)
    {
        return character[index];
    }


}
