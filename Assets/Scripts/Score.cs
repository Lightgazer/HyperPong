using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitStatus {
    Hit,
    Other
}

public class Score : MonoBehaviour
{
    [SerializeField, Range(0, 100)] int winScore;

    public HitStatus CheckScore(GameObject hit) {
        var name = hit.name;
        if (name == "Player Wall" || name == "Enemy Wall") {
            return HitStatus.Hit;
        }
        return HitStatus.Other;
    }
}
