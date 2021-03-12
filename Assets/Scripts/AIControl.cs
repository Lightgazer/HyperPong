using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour, ISphereControl
{
    Vector2 direction = new Vector2(0, 0);
    GameObject ball;
    public Vector2 getDesiredDirection()
    {
        var pos = transform.position - ball.transform.position;

        if (pos.x > 0)
        {
            if (pos.x > 0.9)
            {
                direction.x = -1;
            }
            if (pos.z > 0)
                direction.y = -1;
            else
                direction.y = 1;
        }
        else
        {
            direction.x = 1;
            if (Mathf.Abs(pos.z) < 0.5)
                direction.y = -1;
        }
        return direction;
    }

    public bool isAbilityActive()
    {
        var pos = transform.position - ball.transform.position;
        if(pos.x < 0) return true;
        return false;
    }

    void Awake()
    {
        ball = GameObject.Find("Ball");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(transform.position);
            Debug.Log(ball.transform.position);
        }
    }
}
