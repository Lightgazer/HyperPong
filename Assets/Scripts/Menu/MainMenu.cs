using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        TeamSettings.withPlayer = true;
        var index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void disablePlayer() {
        TeamSettings.withPlayer = false;
    }
}
