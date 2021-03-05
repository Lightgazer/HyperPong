using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 disabledPostion = new Vector3(0f, 3f, 0f);
    Score manager;
    Rigidbody body; 
    void Awake()
    {
        startPosition = transform.localPosition;
        var managerObject = GameObject.Find("ScoreManager");
        manager = managerObject.GetComponent<Score>();
        body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        var res = manager.CheckScore(collision.gameObject);

        if (res == HitStatus.Hit)
        {
            transform.localPosition = startPosition;
            body.velocity = new Vector3(0f, 0f, 0f);
        } else if (res == HitStatus.EndGame) {
            transform.localPosition = disabledPostion;
            body.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
