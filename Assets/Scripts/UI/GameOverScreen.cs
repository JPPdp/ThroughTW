using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("L1");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("L1");
    }
}
