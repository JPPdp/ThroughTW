using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_TS : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GoToGame()
    {
        SceneManager.LoadSceneAsync("Game_Only");
    }
}
