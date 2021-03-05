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
    [SerializeField, Range(0, 100)] int winScore;
    int playerScore = 0;
    TextMeshProUGUI playerText;
    int enemyScore = 0;
    TextMeshProUGUI enemyText;

    private void Awake()
    {
        playerText = GameObject.Find("Player Score").GetComponent<TextMeshProUGUI>();
        enemyText = GameObject.Find("Enemy Score").GetComponent<TextMeshProUGUI>();
    }

    public HitStatus CheckScore(GameObject hit)
    {
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
        var endGame = CheckWin();
        if(endGame) status = HitStatus.EndGame;

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
            ShowMessage("Win Message");
            return true;
        }
        else if (enemyScore >= winScore)
        {
            ShowMessage("Lose Message");
            return true;
        }
        return false;
    }

    // где-то здесь нужно начать выделать отдельный класс
    private void ShowMessage(string name)
    {
        var transform = GameObject.Find(name).GetComponent<RectTransform>();
        StartCoroutine(AnimationCoroutine(transform));
    }


    IEnumerator AnimationCoroutine(RectTransform transform)
    {
        float speed = 4;
        while (transform.anchoredPosition.x != 0)
        {
            if (transform.anchoredPosition.x > 0) transform.anchoredPosition = new Vector2(transform.anchoredPosition.x - speed, 0);
            else transform.anchoredPosition = new Vector2(transform.anchoredPosition.x + speed, 0);
            yield return new WaitForFixedUpdate();
        }
    }
}
