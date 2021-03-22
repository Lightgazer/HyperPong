using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject menu;

    bool isPaused => Time.timeScale == 0;

    void Awake()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
