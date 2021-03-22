using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEndGameMenu : MonoBehaviour, IMessage
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject blueLabel;
    [SerializeField] GameObject yellowLabel;

    public void Show(Message name)
    {
        menu.SetActive(true);
        if (name == Message.Win)
        {
            blueLabel.SetActive(true);
        }
        else if (name == Message.Lose)
        {
            yellowLabel.SetActive(true);
        }
    }
}
