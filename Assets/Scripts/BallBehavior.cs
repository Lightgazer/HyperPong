using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Vector3 startPosition;
    Score manager;
    void Awake()
    {
        startPosition = transform.localPosition;
        var managerObject = GameObject.Find("ScoreManager");
        manager = managerObject.GetComponent<Score>();
        // body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        var res = manager.CheckScore(collision.gameObject);

        if (res == HitStatus.Hit)
        {
            transform.localPosition = startPosition;
        }
    }
}
