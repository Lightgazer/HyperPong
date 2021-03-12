using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum HitStatus
{
    Hit,
    EndGame,
    Other
}

public class Score : MonoBehaviour
{
    [SerializeField, Range(0, 30)] int winScore;
    int playerScore = 0;
    TextMeshProUGUI playerText;
    int enemyScore = 0;
    TextMeshProUGUI enemyText;
    IMessage message;
    bool isEndGame = false;

    private void Awake()
    {
        playerText = GameObject.Find("Player Score").GetComponent<TextMeshProUGUI>();
        enemyText = GameObject.Find("Enemy Score").GetComponent<TextMeshProUGUI>();
        message = GetComponent<IMessage>();
    }

    public HitStatus CheckScore(GameObject hit)
    {
        if (isEndGame) return HitStatus.EndGame;

        var status = HitStatus.Other;
        var name = hit.name;
        if (name == "Player Wall")
        {
            enemyScore++;
            status = HitStatus.Hit;
        }
        else if (name == "Enemy Wall")
        {
            playerScore++;
            status = HitStatus.Hit;
        }

        ShowScore();
        isEndGame = CheckWin();

        if (isEndGame) return HitStatus.EndGame;
        return status;
    }

    private void ShowScore()
    {
        playerText.text = playerScore.ToString();
        enemyText.text = enemyScore.ToString();
    }

    private bool CheckWin()
    {
        if (playerScore >= winScore)
        {
            message.Show(Message.Win);
            return true;
        }
        else if (enemyScore >= winScore)
        {
            message.Show(Message.Lose);
            return true;
        }
        return false;
    }
}