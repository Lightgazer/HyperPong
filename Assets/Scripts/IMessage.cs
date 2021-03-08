using UnityEngine;

internal interface IMessage
{
    void Show(Message name);
}

public enum Message {
    Win,
    Lose
}