using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamsMenu : MonoBehaviour
{
    private void StartGame() {
        var index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }
    public void StartOneOnOneGame() {
        TeamSettings.teamSize = 1;
        StartGame();
    }

    public void StartTwoOnTwoGame() {
        TeamSettings.teamSize = 2;
        StartGame();
    }
}
