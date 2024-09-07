using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerVer2 : MonoBehaviour
{
    public GameObject[] playerList;
    int characterIndex;
    private void Awake()
    {
        //Check if selected Character has value if not the default is Zero
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerList[characterIndex]);
    }
    // Start is called before the first frame update
    void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
}
