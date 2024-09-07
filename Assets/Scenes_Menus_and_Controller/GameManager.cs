using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    // array class character contains characters
    public Character[] characters;//LIST OF CHARACTER

    // item on Character that currently Player selected
    public Character currentCharacter; //CHARACTER SELECTED

    //verifier if GameManager is already created to be deleted
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Dont destroy on Game Launch
        DontDestroyOnLoad(gameObject);
    }


    //verify if no character selected then use the first one
    private void Start()
    {
        if(characters.Length > 0 && currentCharacter == null) {
            currentCharacter = characters[0];
        }
    }

    public void SetCharacter(Character character)
    {
        currentCharacter = character;
    }
}
