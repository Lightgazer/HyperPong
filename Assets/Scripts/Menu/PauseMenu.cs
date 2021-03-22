using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Restart()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume() {
        
    }
}
