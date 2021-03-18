using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour, ISphereControl
{
    [SerializeField] public GameObject ballTarget;
    float targetX => ballTarget.transform.position.x;
    Vector2 direction = new Vector2(0, 0);
    Transform ball;
    public Vector2 GetDesiredDirection()
    {
        var pos = transform.position - ball.position;
        var ballToWallDist = targetX - ball.position.x;
        var distToWall = targetX - transform.position.x;
        var foward = distToWall > 0 ? 1 : -1;
        var distToBall = Mathf.Abs(distToWall) - Mathf.Abs(ballToWallDist);


        if (distToBall > 0)
        {
            if (distToBall > 0.9)
            {
                direction.x = foward;
            }
            if (pos.z > 0)
                direction.y = -1;
            else
                direction.y = 1;
        }
        else
        {
            direction.x = -foward;
            if (Mathf.Abs(pos.z) < 0.5)
                direction.y = -1;
        }
        return direction;
    }

    public bool IsAbilityActive()
    {
        var ballToWallDist = targetX - ball.position.x;
        var distToWall = targetX - transform.position.x;
        if (Mathf.Abs(ballToWallDist) > Mathf.Abs(distToWall)) 
            return true;
        return false;
    }

    void Awake()
    {
        ball = GameObject.Find("Ball").transform;
    }
}
